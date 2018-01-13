using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using Cs2Py.CodeVisitors;
using Cs2Py.Compilation;
using Cs2Py.CSharp;
using Cs2Py.Emit;
using Cs2Py.Sandbox;
using Cs2Py.Source;
using Lang.Python;

namespace Cs2Py.Translator
{
    public class Translator
    {
        public Translator(TranslationState translationState)
        {
            if (translationState == null)
                throw new ArgumentNullException(nameof(translationState));
#if DEBUG
            if (translationState == null)
                throw new ArgumentNullException(nameof(translationState));

#endif
            _state = translationState; // ?? new TranslationState(new TranslationInfo());
            Info   = translationState.Principles;
        }

        // Private Methods 

        /*
                static IPyStatement[] MkArray(IPyStatement x)
                {
                    return new IPyStatement[] { x };
                }
        */

        // Public Methods 


        public void Translate(AssemblySandbox sandbox)
        {
            var classes            = Info.GetClasses();
            var classesToTranslate = Info.ClassTranslations.Values
                .Where(u => u.Type.Assembly.FullName == Info.CurrentAssembly.FullName).ToArray();
            //            classesToTranslate = (from i in _info.ClassTranslations.Values
            //                                      where i.Type.Assembly.FullName == _info.CurrentAssembly.FullName
            //                                      select this.ge.ToArray();
            var interfaces = Info.GetInterfaces();
            //     var interfacesToTranslate = info.ClassTranslations.Values.Where(u => u.Type.Assembly == info.CurrentAssembly).ToArray();
            foreach (var classTranslationInfo in classesToTranslate)
            {
                if (classTranslationInfo.Skip)
                    Debug.Write("");
                PyClassDefinition PyClass;
                var                PyModule = GetOrMakeModuleByName(classTranslationInfo.ModuleName);
                // var assemblyTI = _info.GetOrMakeTranslationInfo(_info.CurrentAssembly);

                {
                    PyQualifiedName PyBaseClassName;
                    {
                        var netBaseType = classTranslationInfo.Type.BaseType;
                        if ((object)netBaseType == null || netBaseType == typeof(object))
                        {
                            PyBaseClassName = PyQualifiedName.Empty;
                        }
                        else
                        {
                            // _state.Principles.CurrentTyp is null so we will obtain absolute name
                            PyBaseClassName =
                                _state.Principles.GetPyType(netBaseType, true, null); // absolute name
                            var baseTypeTranslationInfo = _state.Principles.GetOrMakeTranslationInfo(netBaseType);
                            if (baseTypeTranslationInfo.Skip)
                                PyBaseClassName = PyQualifiedName.Empty;
                        }
                    }
                    PyClass = PyModule.FindOrCreateClass(classTranslationInfo.ScriptName, PyBaseClassName);
                }
                _state.Principles.CurrentType     = classTranslationInfo.Type;
                _state.Principles.CurrentAssembly = _state.Principles.CurrentType.Assembly;
                Console.WriteLine(classTranslationInfo.ModuleName);

                IClassMember[] members;

                if (classTranslationInfo.Type.IsInterface)
                {
                    var sources = interfaces.Where(i => i.FullName == classTranslationInfo.Type.FullName).ToArray();
                    members     = (from i in sources
                        from j in i.ClassDeclaration.Members
                        select j).ToArray();
                    {
                        var fileNames = classTranslationInfo.Type.GetCustomAttributes<RequireOnceAttribute>()
                            .Select(i => i.Filename).Distinct().ToArray();
                        if (fileNames.Any())
                        {
                            var b = fileNames.Select(u => new PyConstValue(u)).ToArray();
                            PyModule.RequiredFiles.AddRange(b);
                        }
                    }
                }
                else
                {
                    var sources = classes.Where(i => i.FullName == classTranslationInfo.Type.FullName).ToArray();
                    members     = (from i in sources
                        from j in i.ClassDeclaration.Members
                        select j).ToArray();
                    {
                        var fileNames = classTranslationInfo.Type.GetCustomAttributes<RequireOnceAttribute>()
                            .Select(i => i.Filename).Distinct().ToArray();
                        if (fileNames.Any())
                        {
                            var b = fileNames.Select(u => new PyConstValue(u)).ToArray();
                            PyModule.RequiredFiles.AddRange(b);
                        }
                    }
                }

                {
                    var c = members.OfType<ConstructorDeclaration>().ToArray();
                    if (c.Length > 1)
                        throw new Exception("Py supports only one constructor per class");
                    if (c.Any())
                        TranslateConstructor(PyClass, c.First());
                }

                {
                    foreach (var methodDeclaration in members.OfType<MethodDeclaration>())
                        TranslateMethod(PyClass, methodDeclaration);
                }

                {
                    foreach (var pDeclaration in members.OfType<CsharpPropertyDeclaration>())
                        TranslateProperty(PyClass, pDeclaration);
                }

                {
                    foreach (var constDeclaration in members.OfType<FieldDeclaration>())
                        TranslateField(PyModule, PyClass, constDeclaration);
                }

                _state.Principles.CurrentType = null;
                {
                    if (classTranslationInfo.IsPage)
                    {
                        {
                            var mti = MethodTranslationInfo.FromMethodInfo(classTranslationInfo.PageMethod,
                                classTranslationInfo);
                            var callMain = new PyMethodCallExpression(mti.ScriptName);
                            callMain.SetClassName(
                                classTranslationInfo.ScriptName,
                                mti
                            );
                            PyModule.BottomCode.Statements.Add(new PyExpressionStatement(callMain));
                        }
                    }
                }

                {
                    var moduleCodeRequests = new List<ModuleCodeRequest>();
                    var codeRequests       = (PyModule as ICodeRelated).GetCodeRequests().ToArray();
                    {
                        var classCodeRequests = (from request in codeRequests.OfType<ClassCodeRequest>()
                                where request.ClassName != null
                                select request.ClassName.FullName)
                            .Distinct()
                            .ToArray();

                        foreach (var req in classCodeRequests)
                        {
                            var m = Info.ClassTranslations.Values.Where(i => i.ScriptName.FullName == req).ToArray();
                            if (m.Length != 1)
                                throw new NotSupportedException();
                            var mm = m[0];
                            if (mm.DontIncludeModuleForClassMembers)
                                continue;
                            var includeModule = mm.IncludeModule;
                            if (includeModule == null || mm.ModuleName == PyModule.Name)
                                continue;
                            var h = new ModuleCodeRequest(includeModule, "class request: " + req);
                            moduleCodeRequests.Add(h);
                        }
                    }
                    {
                        var moduleRequests = (from i in codeRequests.OfType<ModuleCodeRequest>()
                            where i.ModuleName != null
                            select i).Union(moduleCodeRequests).ToArray();
                        var moduleNames = (from mReq in moduleRequests
                            where mReq.ModuleName != PyModule.Name
                            let mName = mReq.ModuleName
                            where mName != null
                            select mName
                        ).Distinct().ToArray();
                        foreach (var i in moduleNames.Where(x => !PyCodeModuleName.IsFrameworkName(x)))
                            AppendCodeReq(i, PyModule);
                    }
                }
            }

            {
                var emptyModules = Modules.Where(a => a.IsEmpty).ToArray();
                foreach (var module in Modules)
                {
                    // if (module.IsEmpty) 
                }
            }
        }

        public IPyStatement[] TranslateStatement(IStatement x)
        {
            if (!(x is CSharpBase)) throw new Exception("Błąd translacji " + x.GetType().FullName);
            var op = new OptimizeOptions();

            var s      = new PyStatementSimplifier(op);
            var a      = new PyStatementTranslatorVisitor(_state);
            var tmp    = a.Visit(x as CSharpBase);
            var result = new List<IPyStatement>(tmp.Length);
            result.AddRange(tmp.Select(i => s.Visit(i as PySourceBase)));
            return result.ToArray();
        }

        private void AppendCodeReq(PyCodeModuleName req, PyCodeModule current)
        {
            if (req == current.Name)
                return;
            if (req.Name == PyCodeModuleName.CS2Py_CONFIG_MODULE_NAME)
            {
                var PyModule = CurrentConfigModule();
                req           = PyModule.Name;
            }

            if (req.AssemblyInfo != null && !string.IsNullOrEmpty(req.AssemblyInfo.IncludePathConstOrVarName))
            {
                var isCurrentAssembly = Info.CurrentAssembly == req.AssemblyInfo.Assembly;
                if (!isCurrentAssembly)
                {
                    var tmp = req.AssemblyInfo.IncludePathConstOrVarName;
                    if (tmp.StartsWith("$"))
                        throw new NotSupportedException();
                    // leading slash is not necessary -> config is in global namespace
                    // but full name is a key in dictionary
                    var PyModule = CurrentConfigModule();
                    if (PyModule.DefinedConsts.All(i => i.Key != tmp))
                    {
                        KnownConstInfo value;
                        if (Info.KnownConstsValues.TryGetValue(tmp, out value))
                        {
                            if (!value.UseFixedValue)
                            {
                                var expression = PathUtil.MakePathValueRelatedToFile(value, Info);
                                PyModule.DefinedConsts.Add(new KeyValuePair<string, IPyValue>(tmp, expression));
                            }
                            else
                            {
                                throw new NotImplementedException();
                            }
                        }
                        else
                        {
                            Info.Log(MessageLevels.Error,
                                string.Format("const {0} defined in {1} has no known value", tmp, PyModule.Name));
                            PyModule.DefinedConsts.Add(
                                new KeyValuePair<string, IPyValue>(tmp, new PyConstValue("UNKNOWN")));
                        }
                    }
                }
            }

            var fileNameExpression = req.MakeIncludePath(current.Name);
            if (fileNameExpression == null) return;
            if (current.RequiredFiles.Any())
            {
                var s    = new PyEmitStyle();
                var code = fileNameExpression.GetPyCode(s);
                var a    = current.RequiredFiles.Select(i => i.GetPyCode(s)).ToArray();
                if (a.Any(i => i == code))
                    return;
            }

            // if (fileNameExpression1 !=null)
            {
                var fileNameExpressionICodeRelated = fileNameExpression as ICodeRelated;
                // scan nested requests
                var nestedCodeRequests = fileNameExpressionICodeRelated.GetCodeRequests().ToArray();
                if (nestedCodeRequests.Any())
                {
                    var nestedModuleCodeRequests = nestedCodeRequests.OfType<ModuleCodeRequest>();
                    foreach (var nested in nestedModuleCodeRequests)
                        AppendCodeReq(nested.ModuleName, current);
                }
            }
            current.RequiredFiles.Add(fileNameExpression);
        }

        private PyCodeModule CurrentConfigModule()
        {
            var assemblyTranslationInfo = Info.GetOrMakeTranslationInfo(Info.CurrentAssembly);
            var PyCodeModuleName       =
                new PyCodeModuleName(assemblyTranslationInfo.ConfigModuleName, assemblyTranslationInfo);
            var PyModule = GetOrMakeModuleByName(PyCodeModuleName);
            return PyModule;
        }
        // Private Methods 

        /// <summary>
        ///     Gets existing or creates code module for given name
        /// </summary>
        /// <param name="requiredModuleName"></param>
        /// <returns></returns>
        private PyCodeModule GetOrMakeModuleByName(PyCodeModuleName requiredModuleName)
        {
            var mod = Modules.FirstOrDefault(i => i.Name == requiredModuleName);
            if (mod != null) return mod;
            mod = new PyCodeModule(requiredModuleName);
            Modules.Add(mod);
            return mod;
        }

        private void Tranlate_MethodOrProperty(PyClassDefinition PyClass, MethodInfo info, IStatement body,
            string                                                overrideName)
        {
            _state.Principles.CurrentMethod = info;
            try
            {
                var mti       = _state.Principles.GetOrMakeTranslationInfo(info);
                var PyMethod =
                    new PyClassMethodDefinition(string.IsNullOrEmpty(overrideName) ? mti.ScriptName : overrideName);
                PyClass.Methods.Add(PyMethod);

                if (info.IsPublic)
                    PyMethod.Visibility = Visibility.Public;
                else if (info.IsPrivate)
                    PyMethod.Visibility = Visibility.Private;
                else
                    PyMethod.Visibility = Visibility.Protected;

                PyMethod.IsStatic = info.IsStatic;
                {
                    var declaredParameters = info.GetParameters();
                    foreach (var parameter in declaredParameters)
                    {
                        var PyParameter  = new PyMethodArgument();
                        PyParameter.Name = parameter.Name;
                        PyMethod.Arguments.Add(PyParameter);
                        if (parameter.HasDefaultValue)
                            PyParameter.DefaultValue = new PyConstValue(parameter.DefaultValue);
                    }
                }

                if (body != null)
                    PyMethod.Statements.AddRange(TranslateStatement(body));
            }
            finally
            {
                _state.Principles.CurrentMethod = null;
            }
        }

        private void TranslateConstructor(PyClassDefinition PyClass, ConstructorDeclaration md)
        {
            //   state.Principles.CurrentMethod = md.Info;
            try
            {
                // MethodTranslationInfo mti = MethodTranslationInfo.FromMethodInfo(md.Info);
                // state.Principles.CurrentMethod = 
                var PyMethod = new PyClassMethodDefinition("__construct");
                PyClass.Methods.Add(PyMethod);

                if (md.Info.IsPublic)
                    PyMethod.Visibility = Visibility.Public;
                else if (md.Info.IsPrivate)
                    PyMethod.Visibility = Visibility.Private;
                else
                    PyMethod.Visibility = Visibility.Protected;

                PyMethod.IsStatic = md.Info.IsStatic;
                {
                    var declaredParameters = md.Info.GetParameters();
                    foreach (var parameter in declaredParameters)
                    {
                        var PyParameter  = new PyMethodArgument();
                        PyParameter.Name = parameter.Name;
                        PyMethod.Arguments.Add(PyParameter);
                        if (parameter.HasDefaultValue)
                            PyParameter.DefaultValue = new PyConstValue(parameter.DefaultValue);
                    }
                }

                if (md.Body != null)
                    PyMethod.Statements.AddRange(TranslateStatement(md.Body));
            }
            finally
            {
                _state.Principles.CurrentMethod = null;
            }
        }

        private void TranslateField(PyCodeModule module, PyClassDefinition PyClass, FieldDeclaration field)
        {
            PyValueTranslator PyValueTranslator = null;
            foreach (var item in field.Items)
            {
                if (item.OptionalFieldInfo == null) continue;
                var fti = Info.GetOrMakeTranslationInfo(item.OptionalFieldInfo);
                switch (fti.Destination)
                {
                    case FieldTranslationDestionations.DefinedConst:
                        if (item.Value == null)
                            throw new NotSupportedException();
                        if (PyValueTranslator == null)
                            PyValueTranslator = new PyValueTranslator(_state);
                        var definedValue       = PyValueTranslator.TransValue(item.Value);
                    {
                        if (fti.IncludeModule != module.Name) module = GetOrMakeModuleByName(fti.IncludeModule);
                    }
                        module.DefinedConsts.Add(new KeyValuePair<string, IPyValue>(fti.ScriptName, definedValue));
                        break;
                    case FieldTranslationDestionations.GlobalVariable:
                        if (item.Value != null)
                        {
                            IPyValue value;
                            // muszę na chwilę wyłączyć current type, bo to jes poza klasą generowane
                            {
                                var saveCurrentType           = _state.Principles.CurrentType;
                                _state.Principles.CurrentType = null;
                                try
                                {
                                    if (PyValueTranslator == null)
                                        PyValueTranslator = new PyValueTranslator(_state);
                                    value                  = PyValueTranslator.TransValue(item.Value);
                                }
                                finally
                                {
                                    _state.Principles.CurrentType = saveCurrentType;
                                }
                            }

                            var assign = new PyAssignExpression(PyVariableExpression.MakeGlobal(fti.ScriptName),
                                value);
                            module.TopCode.Statements.Add(new PyExpressionStatement(assign));
                        }

                        break;
                    case FieldTranslationDestionations.JustValue:
                        continue; // don't define
                    case FieldTranslationDestionations.NormalField:
                    case FieldTranslationDestionations.ClassConst:
                    {
                        var def = new PyClassFieldDefinition();
                        var cti = _state.Principles.GetTi(_state.Principles.CurrentType, true);
                        if (cti.IsArray)
                            continue;
                        if (field.Modifiers.Has("const") ^
                            (fti.Destination == FieldTranslationDestionations.ClassConst))
                            throw new Exception("beige lion");

                        def.IsConst =
                            fti.Destination ==
                            FieldTranslationDestionations.ClassConst; // field.Modifiers.Has("const");
                        def.Name = fti.ScriptName;

                        def.IsStatic = def.IsConst || field.Modifiers.Has("static");
                        if (field.Modifiers.Has("public"))
                            def.Visibility = Visibility.Public;
                        else if (field.Modifiers.Has("protected"))
                            def.Visibility = Visibility.Protected;
                        else
                            def.Visibility = Visibility.Private;

                        if (item.Value != null)
                        {
                            if (PyValueTranslator == null)
                                PyValueTranslator = new PyValueTranslator(_state);
                            def.ConstValue         = PyValueTranslator.TransValue(item.Value);
                        }

                        PyClass.Fields.Add(def);
                        break;
                    }
                    default:
                        throw new NotSupportedException();
                }
            }
        }

        private void TranslateMethod(PyClassDefinition PyClass, MethodDeclaration md)
        {
            Tranlate_MethodOrProperty(PyClass, md.Info, md.Body, null);
        }

        private void TranslateProperty(PyClassDefinition PyClassDefinition,
            CsharpPropertyDeclaration                     propertyDeclaration)
        {
            var pi  = _state.Principles.CurrentType.GetProperty(propertyDeclaration.PropertyName);
            var pti = PropertyTranslationInfo.FromPropertyInfo(pi);
            if (pti.GetSetByMethod)
            {
                CsharpPropertyDeclarationAccessor accessor;
                if (!string.IsNullOrEmpty(pti.GetMethodName))
                {
                    accessor = propertyDeclaration.Accessors.FirstOrDefault(u => u.Name == "get");
                    if (accessor != null)
                        Tranlate_MethodOrProperty(PyClassDefinition, pi.GetGetMethod(), accessor.Statement,
                            pti.GetMethodName);
                }

                if (string.IsNullOrEmpty(pti.SetMethodName)) return;
                accessor = propertyDeclaration.Accessors.FirstOrDefault(u => u.Name == "set");
                if (accessor != null)
                    Tranlate_MethodOrProperty(PyClassDefinition, pi.GetSetMethod(), accessor.Statement,
                        pti.SetMethodName);
            }
            else
            {
                PyClassDefinition.Fields.Add(new PyClassFieldDefinition
                {
                    Name     = pti.FieldScriptName,
                    IsStatic = pti.IsStatic
                });
            }
        }

        /// <summary>
        ///     Własność jest tylko do odczytu.
        /// </summary>
        public TranslationInfo Info { get; }

        /// <summary>
        ///     Własność jest tylko do odczytu.
        /// </summary>
        public List<PyCodeModule> Modules { get; } = new List<PyCodeModule>();

        private readonly TranslationState _state;
    }
}