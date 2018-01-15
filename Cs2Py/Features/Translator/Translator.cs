using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using Cs2Py.CodeVisitors;
using Cs2Py.Compilation;
using Cs2Py.CSharp;
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
            var classes = Info.GetClasses();
            if (Info.CurrentAssembly == null)
                throw new Exception("Info.CurrentAssembly is null");
            var fullName           = Info.CurrentAssembly.FullName;
            var classesToTranslate = Info.ClassTranslations.Values
                .Where(u => u.Type.Assembly.FullName == fullName).ToArray();
            //            classesToTranslate = (from i in _info.ClassTranslations.Values
            //                                      where i.Type.Assembly.FullName == _info.CurrentAssembly.FullName
            //                                      select this.ge.ToArray();
            var interfaces = Info.GetInterfaces();
            //     var interfacesToTranslate = info.ClassTranslations.Values.Where(u => u.Type.Assembly == info.CurrentAssembly).ToArray();
            foreach (var classTranslationInfo in classesToTranslate)
                TranslateClass(classTranslationInfo, interfaces, classes);

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

        private static void AppendCodeReq(PyCodeModuleName req, PyCodeModule currentModule)
        {
            if (req == currentModule.ModuleName)
                return;
            /*
            if (req.Name == PyCodeModuleName.CS2PY_CONFIG_MODULE_NAME)
            {
                var pyModule = CurrentConfigModule();
                req          = pyModule.Name;
            }
            */

            /*
            if (!string.IsNullOrEmpty(req.AssemblyInfo?.IncludePathConstOrVarName))
            {
                var isCurrentAssembly = Info.CurrentAssembly == req.AssemblyInfo.Assembly;
                if (!isCurrentAssembly)
                {
                    var tmp = req.AssemblyInfo.IncludePathConstOrVarName;
                    if (tmp.StartsWith("$"))
                        throw new NotSupportedException();
                    // leading slash is not necessary -> config is in global namespace
                    // but full name is a key in dictionary
                    var pyModule = CurrentConfigModule();
                    if (pyModule.DefinedConsts.All(i => i.Key != tmp))
                        if (Info.KnownConstsValues.TryGetValue(tmp, out var value))
                        {
                            if (!value.UseFixedValue)
                            {
                                var expression = PathUtil.MakePathValueRelatedToFile(value, Info);
                                pyModule.DefinedConsts.Add(new KeyValuePair<string, IPyValue>(tmp, expression));
                            }
                            else
                            {
                                throw new NotImplementedException();
                            }
                        }
                        else
                        {
                            
                            Info.Log(MessageLevels.Error,
                                string.Format("const {0} defined in {1} has no known value", tmp, pyModule.Name));
                            pyModule.DefinedConsts.Add(
                                new KeyValuePair<string, IPyValue>(tmp, new PyConstValue("UNKNOWN")));
                        }
                }
            }
*/
         
            string includePath = req.MakeIncludePath(currentModule.ModuleName);
            /*
            if (includePath == null) return;
            if (currentModule.RequiredFiles.Any())
            {
                var s    = new PyEmitStyle();
                var code = includePath.GetPyCode(s);
                var a    = currentModule.RequiredFiles.Select(i => i.GetPyCode()).ToArray();
                if (a.Any(i => i == code))
                    return;
            }

            // if (fileNameExpression1 !=null)
            {
                var fileNameExpressionICodeRelated = includePath as ICodeRelated;
                // scan nested requests
                var nestedCodeRequests = fileNameExpressionICodeRelated.GetCodeRequests().ToArray();
                if (nestedCodeRequests.Any())
                {
                    var nestedModuleCodeRequests = nestedCodeRequests.OfType<ModuleCodeRequest>();
                    foreach (var nested in nestedModuleCodeRequests)
                        AppendCodeReq(nested.ModuleName, currentModule);
                }
            }
            */
            currentModule.RequiredFiles.Add(new PyImportRequest(includePath));
           
        }

        private PyCodeModule CurrentConfigModule()
        {
            var assemblyTranslationInfo = Info.GetOrMakeTranslationInfo(Info.CurrentAssembly);
            var pyCodeModuleName        =
                new PyCodeModuleName(assemblyTranslationInfo.ConfigModuleName, false);
            var pyModule = GetOrMakeModuleByName(pyCodeModuleName);
            return pyModule;
        }
        // Private Methods 

        /// <summary>
        ///     Gets existing or creates code module for given name
        /// </summary>
        /// <param name="requiredModuleName"></param>
        /// <returns></returns>
        private PyCodeModule GetOrMakeModuleByName(PyCodeModuleName requiredModuleName)
        {
            var mod = Modules.FirstOrDefault(i => i.ModuleName == requiredModuleName);
            if (mod != null) return mod;
            mod = new PyCodeModule(requiredModuleName);
            Modules.Add(mod);
            return mod;
        }

        private void Tranlate_MethodOrProperty(PyClassDefinition pyClass, MethodInfo info, IStatement body,
            string                                               overrideName)
        {
            _state.Principles.CurrentMethod = info;
            try
            {
                var mti      = _state.Principles.GetOrMakeTranslationInfo(info);
                var pyMethod =
                    new PyClassMethodDefinition(string.IsNullOrEmpty(overrideName) ? mti.ScriptName : overrideName);
                pyClass.Methods.Add(pyMethod);

                if (info.IsPublic)
                    pyMethod.Visibility = Visibility.Public;
                else if (info.IsPrivate)
                    pyMethod.Visibility = Visibility.Private;
                else
                    pyMethod.Visibility = Visibility.Protected;

                pyMethod.IsStatic = info.IsStatic;
                {
                    var declaredParameters = info.GetParameters();
                    foreach (var parameter in declaredParameters)
                    {
                        var pyParameter  = new PyMethodArgument();
                        pyParameter.Name = parameter.Name;
                        pyMethod.Arguments.Add(pyParameter);
                        if (parameter.HasDefaultValue)
                            pyParameter.DefaultValue = new PyConstValue(parameter.DefaultValue);
                    }
                }

                if (body != null)
                    pyMethod.Statements.AddRange(TranslateStatement(body));
            }
            finally
            {
                _state.Principles.CurrentMethod = null;
            }
        }

        private void TranslateClass(
            ClassTranslationInfo       classTranslationInfo,
            FullInterfaceDeclaration[] interfaces,
            FullClassDeclaration[]     classes)
        {
            if (classTranslationInfo.Skip)
                Debug.Write("");
            PyClassDefinition pyClass;
            var               pyModule = GetOrMakeModuleByName(classTranslationInfo.ModuleName);
            // var assemblyTI = _info.GetOrMakeTranslationInfo(_info.CurrentAssembly);

            {
                PyQualifiedName pyBaseClassName;
                {
                    var netBaseType = classTranslationInfo.Type.BaseType;
                    if ((object)netBaseType == null || netBaseType == typeof(object))
                    {
                        pyBaseClassName = PyQualifiedName.Empty;
                    }
                    else
                    {
                        // _state.Principles.CurrentTyp is null so we will obtain absolute name
                        pyBaseClassName =
                            _state.Principles.GetPyType(netBaseType, true, null); // absolute name
                        var baseTypeTranslationInfo = _state.Principles.GetOrMakeTranslationInfo(netBaseType);
                        if (baseTypeTranslationInfo.Skip)
                            pyBaseClassName = PyQualifiedName.Empty;
                    }
                }
                pyClass = pyModule.FindOrCreateClass(classTranslationInfo.ScriptName, pyBaseClassName);
            }
            Console.WriteLine(classTranslationInfo.ModuleName);
            _state.Principles.CurrentType = classTranslationInfo.Type;
            try
            {
                _state.Principles.CurrentAssembly = _state.Principles.CurrentType.Assembly;
                var fullname = classTranslationInfo.Type.FullName;
                var srcs     = classTranslationInfo.Type.IsInterface
                    ? interfaces
                        .Where(q => q.FullName == fullname)
                        .Select(q => q.ClassDeclaration)
                        .OfType<IClassOrInterface>().ToArray()
                    : classes
                        .Where(q => q.FullName == fullname)
                        .Select(q => q.ClassDeclaration)
                        .OfType<IClassOrInterface>().ToArray();
                var members = srcs.SelectMany(i => i.Members).ToArray();
                var fileNames = classTranslationInfo.Type.GetCustomAttributes<RequireOnceAttribute>()
                    .Select(i => i.Filename).Distinct().ToArray();
                if (fileNames.Any())
                {
                    var b = fileNames.Select(u => new PyImportRequest(u)).ToArray();
                    pyModule.RequiredFiles.AddRange(b);
                }
                 
                var constructors = members.OfType<ConstructorDeclaration>().ToArray();
                if (constructors.Length > 1)
                    throw new Exception("Python supports only one constructor per class");
                if (constructors.Any())
                    TranslateConstructor(pyClass, constructors.First());
                foreach (var methodDeclaration in members.OfType<MethodDeclaration>())
                    TranslateMethod(pyClass, methodDeclaration);
                foreach (var pDeclaration in members.OfType<CsharpPropertyDeclaration>())
                    TranslateProperty(pyClass, pDeclaration);
                foreach (var constDeclaration in members.OfType<FieldDeclaration>())
                    TranslateField(pyModule, pyClass, constDeclaration);
            }
            finally
            {
                _state.Principles.CurrentType = null;
            }

            {
                if (classTranslationInfo.IsPage)
                {
                    var mti = MethodTranslationInfo.FromMethodInfo(classTranslationInfo.PageMethod,
                        classTranslationInfo);
                    var callMain = new PyMethodCallExpression(mti.ScriptName);
                    callMain.SetClassName(
                        classTranslationInfo.ScriptName,
                        mti
                    );
                    pyModule.BottomCode.Statements.Add(new PyExpressionStatement(callMain));
                }
            }

            {
                var moduleCodeRequests = new List<ModuleCodeRequest>();
                var codeRequests       = (pyModule as ICodeRelated).GetCodeRequests().ToArray();
                {
                    var classCodeRequests = (from request in codeRequests.OfType<ClassCodeRequest>()
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
                        if (includeModule == null || mm.ModuleName == pyModule.ModuleName)
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
                        where mReq.ModuleName != pyModule.ModuleName
                        let mName = mReq.ModuleName
                        where mName != null
                        select mName
                    ).Distinct().ToArray();
                    foreach (var i in moduleNames)
                        AppendCodeReq(i, pyModule);
                }
            }
        }

        private void TranslateConstructor(PyClassDefinition pyClass, ConstructorDeclaration md)
        {
            //   state.Principles.CurrentMethod = md.Info;
            try
            {
                // MethodTranslationInfo mti = MethodTranslationInfo.FromMethodInfo(md.Info);
                // state.Principles.CurrentMethod = 
                var pyMethod = new PyClassMethodDefinition("__init__");
                pyClass.Methods.Add(pyMethod);

                if (md.Info.IsPublic)
                    pyMethod.Visibility = Visibility.Public;
                else if (md.Info.IsPrivate)
                    pyMethod.Visibility = Visibility.Private;
                else
                    pyMethod.Visibility = Visibility.Protected;

                pyMethod.IsStatic = md.Info.IsStatic;
                {
                    var declaredParameters = md.Info.GetParameters();
                    foreach (var parameter in declaredParameters)
                    {
                        var pyParameter  = new PyMethodArgument();
                        pyParameter.Name = parameter.Name;
                        pyMethod.Arguments.Add(pyParameter);
                        if (parameter.HasDefaultValue)
                            pyParameter.DefaultValue = new PyConstValue(parameter.DefaultValue);
                    }
                }

                if (md.Body != null)
                    pyMethod.Statements.AddRange(TranslateStatement(md.Body));
            }
            finally
            {
                _state.Principles.CurrentMethod = null;
            }
        }

        private void TranslateField(PyCodeModule module, PyClassDefinition pyClass, FieldDeclaration field)
        {
            PyValueTranslator pyValueTranslator = null;
            foreach (var item in field.Items)
            {
                if (item.OptionalFieldInfo == null) continue;
                var fti = Info.GetOrMakeTranslationInfo(item.OptionalFieldInfo);
                switch (fti.Destination)
                {
                    case FieldTranslationDestionations.DefinedConst:
                        if (item.Value == null)
                            throw new NotSupportedException();
                        if (pyValueTranslator == null)
                            pyValueTranslator = new PyValueTranslator(_state);
                        var definedValue      = pyValueTranslator.TransValue(item.Value);
                    {
                        if (fti.IncludeModule != module.ModuleName) module = GetOrMakeModuleByName(fti.IncludeModule);
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
                                    if (pyValueTranslator == null)
                                        pyValueTranslator = new PyValueTranslator(_state);
                                    value                 = pyValueTranslator.TransValue(item.Value);
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
                            if (pyValueTranslator == null)
                                pyValueTranslator = new PyValueTranslator(_state);
                            def.ConstValue        = pyValueTranslator.TransValue(item.Value);
                        }

                        pyClass.Fields.Add(def);
                        break;
                    }
                    default:
                        throw new NotSupportedException();
                }
            }
        }

        private void TranslateMethod(PyClassDefinition pyClass, MethodDeclaration md)
        {
            Tranlate_MethodOrProperty(pyClass, md.Info, md.Body, null);
        }

        private void TranslateProperty(PyClassDefinition pyClassDefinition,
            CsharpPropertyDeclaration                    propertyDeclaration)
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
                        Tranlate_MethodOrProperty(pyClassDefinition, pi.GetGetMethod(), accessor.Statement,
                            pti.GetMethodName);
                }

                if (string.IsNullOrEmpty(pti.SetMethodName)) return;
                accessor = propertyDeclaration.Accessors.FirstOrDefault(u => u.Name == "set");
                if (accessor != null)
                    Tranlate_MethodOrProperty(pyClassDefinition, pi.GetSetMethod(), accessor.Statement,
                        pti.SetMethodName);
            }
            else
            {
                pyClassDefinition.Fields.Add(new PyClassFieldDefinition
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