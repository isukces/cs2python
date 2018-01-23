using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Cs2Py.Emit;
using Cs2Py.Source;

namespace Cs2Py.Compilation
{
    public class PyCodeModule : ICodeRelated, IEmitable
    {
        /// <summary>
        ///     Tworzy instancję obiektu
        ///     <param name="moduleName">nazwa pliku</param>
        /// </summary>
        public PyCodeModule(PyCodeModuleName moduleName)
        {
            ModuleName = moduleName;
        }
        // Private Methods 

        private static void EmitWithNamespace(PyNamespace ns, PySourceCodeEmiter emiter,
            PySourceCodeWriter                            writer,
            PyEmitStyle                                   style, IEnumerable<IEmitable> classesInNamespace)
        {
            if (classesInNamespace == null)
                return;
            var inNamespace = classesInNamespace as IEmitable[] ?? classesInNamespace.ToArray();
            if (!inNamespace.Any())
                return;
            style.CurrentNamespace = ns;
            try
            {
                if (ns.IsRoot)
                    writer.OpenLn("namespace {");
                else
                    writer.OpenLnF("namespace {0} {{", ns.Name.Substring(1));
                foreach (var cl in inNamespace)
                    cl.Emit(emiter, writer, style);
                writer.CloseLn("}");
            }
            finally
            {
                style.CurrentNamespace = null;
            }
        }

        private static string GetNamespace(string name)
        {
            var a = PathUtil.MakeUnixPath(PathUtil.UNIX_SEP + name);
            var g = a.LastIndexOf(PathUtil.UNIX_SEP, StringComparison.Ordinal);
            return a.Substring(0, g);
        }

        private static string GetShortName(string name)
        {
            var a = PathUtil.MakeUnixPath(PathUtil.UNIX_SEP + name);
            var g = a.LastIndexOf(PathUtil.UNIX_SEP, StringComparison.Ordinal);
            return a.Substring(g + 1);
        }

        // Public Methods 

        public void Emit(PySourceCodeEmiter emiter, PyEmitStyle style, string filename)
        {
            if (string.IsNullOrEmpty(filename))
                throw new ArgumentNullException(nameof(filename));

            var writer                = new PySourceCodeWriter();
            var styleCurrentNamespace = style.CurrentNamespace;
            try
            {
                Emit(emiter, writer, style);

                {
                    var fi = new FileInfo(filename);
                    if (fi.Directory != null) fi.Directory.Create();
                    var codeStr = writer.GetCode();
                    var binary  = Encoding.UTF8.GetBytes(codeStr);
                    File.WriteAllBytes(fi.FullName, binary);
                }
            }
            finally
            {
                style.CurrentNamespace = styleCurrentNamespace;
            }
        }

        public void Emit(PySourceCodeEmiter emiter, PySourceCodeWriter writer, PyEmitStyle style)
        {
            var nsManager          = new PyModuleNamespaceManager();
            style.CurrentNamespace = null;
            if (!string.IsNullOrEmpty(_topComments))
                writer.WriteLn("'''\r\n" + _topComments.Trim() + "\r\n'''");
            var module = this;
            {
                // var noBracketStyle = PyEmitStyle.xClone(style, ShowBracketsEnum.Never);

                {
                    // top code
                    var collectedTopCodeBlock = new PyCodeBlock();
                    collectedTopCodeBlock.Statements.AddRange(ConvertRequestedToCode());
                    collectedTopCodeBlock.Statements.AddRange(ConvertDefinedConstToCode());
                    if (TopCode != null)
                        collectedTopCodeBlock.Statements.AddRange(TopCode.Statements);
                    nsManager.Add(collectedTopCodeBlock.Statements);
                }

                {
                    var classesGbNamespace = module.Classes.GroupBy(u => u.Name.Namespace);
                    foreach (var classesInNamespace in classesGbNamespace.OrderBy(i => !i.Key.IsRoot))
                    foreach (var c in classesInNamespace)
                        nsManager.Add(c);
                }
                if (BottomCode != null)
                    nsManager.Add(BottomCode.Statements);
                if (!nsManager.Container.Any())
                    return;
                if (nsManager.OnlyOneRootStatement)
                    foreach (var cl in nsManager.Container[0].Items)
                        cl.Emit(emiter, writer, style);
                else
                    foreach (var ns in nsManager.Container)
                        EmitWithNamespace(ns.Name, emiter, writer, style, ns.Items);
            }
        }

        public PyClassDefinition FindOrCreateClass(PyQualifiedName PyClassName, PyQualifiedName baseClass)
        {
            var c = Classes.FirstOrDefault(i => PyClassName == i.Name);
            if (c != null) return c;
            c = new PyClassDefinition(PyClassName, baseClass);
            Classes.Add(c);
            return c;
        }

        public IEnumerable<ICodeRequest> GetCodeRequests()
        {
            var a = PyStatementBase.GetCodeRequests(TopCode, BottomCode);
            var b = PyStatementBase.GetCodeRequests(Classes);
            return a.Union(b);
        }

        /// <summary>
        ///     Zwraca tekstową reprezentację obiektu
        /// </summary>
        /// <returns>Tekstowa reprezentacja obiektu</returns>
        public override string ToString()
        {
            return string.Format("Module {0}", ModuleName);
        }
        // Private Methods 

        private IEnumerable<IPyStatement> ConvertDefinedConstToCode()
        {
            var result         = new List<IPyStatement>();
            var alreadyDefined = new List<string>();
            if (!DefinedConsts.Any()) return result.ToArray();
            var grouped = DefinedConsts.GroupBy(u => GetNamespace(u.Key)).ToArray();

            var useNamespaces = grouped.Length > 1 || grouped[0].Key != PathUtil.UNIX_SEP;
            foreach (var group in grouped)
            {
                List<IPyStatement> container;
                if (useNamespaces)
                {
                    var ns1   = new PyNamespaceStatement((PyNamespace)group.Key);
                    container = ns1.Code.Statements;
                    result.Add(ns1);
                }
                else
                {
                    container = result;
                }

                foreach (var item in group)
                {
                    var shortName = GetShortName(item.Key);
                    if (alreadyDefined.Contains(item.Key))
                        continue;
                    alreadyDefined.Add(item.Key);
                    var defined     = new PyMethodCallExpression("defined", new PyConstValue(shortName));
                    var notDefined  = new PyUnaryOperatorExpression(defined, "!");
                    var define      = new PyMethodCallExpression("define", new PyConstValue(shortName), item.Value);
                    var ifStatement = new PyIfStatement(notDefined, new PyExpressionStatement(define), null);
                    container.Add(ifStatement);
                }
            }

            return result.ToArray();
        }

        private IEnumerable<IPyStatement> ConvertRequestedToCode()
        {
            var result         = new List<IPyStatement>();
            var alreadyDefined = new List<string>();
            foreach (PyImportRequest item in RequiredFiles.Distinct())
            {
                var code = item.GetPyCode(); //rozróżniam je po wygenerowanym kodzie
                if (alreadyDefined.Contains(code))
                    continue;
                alreadyDefined.Add(code);
                var req = new PyImportStatement(item.RelativeModulePath, item.Alias);
                result.Add(req);
            }

            return result.ToArray();
        }

        public bool IsEmpty
        {
            get
            {
                if (Classes.Any(i => !i.IsEmpty))
                    return false;
                return DefinedConsts.Count == 0 && !PyCodeBlock.HasAny(TopCode) && !PyCodeBlock.HasAny(BottomCode);
            }
        }

        /// <summary>
        ///     nazwa pliku; własność jest tylko do odczytu.
        /// </summary>
        public PyCodeModuleName ModuleName { get; }

        /// <summary>
        ///     komentarz na szczycie pliku
        /// </summary>
        public string TopComments
        {
            get => _topComments;
            set => _topComments = (value ?? string.Empty).Trim();
        }

        /// <summary>
        /// </summary>
        public PyCodeBlock TopCode { get; set; } = new PyCodeBlock();

        /// <summary>
        /// </summary>
        public PyCodeBlock BottomCode { get; set; } = new PyCodeBlock();

        /// <summary>
        ///     classes in this module; własność jest tylko do odczytu.
        /// </summary>
        public List<PyClassDefinition> Classes { get; } = new List<PyClassDefinition>();

        /// <summary>
        ///     Pliki dołączane do require; własność jest tylko do odczytu.
        /// </summary>
        public List<PyImportRequest> RequiredFiles { get; } = new List<PyImportRequest>();

        /// <summary>
        ///     Własność jest tylko do odczytu.
        /// </summary>
        public List<KeyValuePair<string, IPyValue>> DefinedConsts { get; } =
            new List<KeyValuePair<string, IPyValue>>();

        private string _topComments = "Generated with cs2py";
    }
}