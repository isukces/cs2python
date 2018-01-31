using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using Cs2Py.CodeVisitors;
using Cs2Py.Compilation;
using Cs2Py.CSharp;
using Cs2Py.Sandbox;
using Cs2Py.Source;
using JetBrains.Annotations;

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


        private static string AppendImportModuleCodeRequest(PyCodeModuleName import, PyCodeModule targetModule,
            IModuleAliasResolver                                             aliasResolver)
        {
            // returns alias
            if (import == targetModule.ModuleName)
                return null;
            var includePath = import.GetImportPath(targetModule.ModuleName);
            if (string.IsNullOrEmpty(includePath)) return null;
            var alias = aliasResolver.FindModuleAlias(import);
            return targetModule.AddRequiredFile(includePath, alias);
        }


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

        public IPyStatement[] TranslateStatement([NotNull] IStatement x)
        {
            if (x == null)
                throw new ArgumentNullException(nameof(x));
            if (!(x is CSharpBase))
                throw new Exception($"Translation error: {x.GetType().FullName} is not CSharpBase instance");
            var op = new OptimizeOptions();

            var s      = new PyStatementSimplifier(op);
            var a      = new PyStatementTranslatorVisitor(_state);
            var tmp    = a.Visit(x as CSharpBase);
            var result = new List<IPyStatement>(tmp.Length);
            result.AddRange(tmp.Select(i => s.Visit(i as PySourceBase)));
            return result.ToArray();
        }


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

        private void Tranlate_MethodOrProperty(PyCodeModule pyModule, [CanBeNull] PyClassDefinition pyClass,
            MethodInfo                                      info, IStatement                        body,
            string                                          overrideName)
        {
            _state.Principles.CurrentMethod = info;
            try
            {
                var mti      = _state.Principles.GetOrMakeTranslationInfo(info);
                var pyMethod =
                    new PyClassMethodDefinition(string.IsNullOrEmpty(overrideName) ? mti.ScriptName : overrideName);
                if (pyClass == null)
                {
                    pyModule.Methods.Add(pyMethod);
                    pyMethod.Kind = PyMethodKind.OutOfClass;
                }
                else
                {
                    pyClass.Methods.Add(pyMethod);
                    pyMethod.Kind = info.IsStatic ? PyMethodKind.ClassStatic : PyMethodKind.ClassInstance;
                }

                if (info.IsPublic)
                    pyMethod.Visibility = Visibility.Public;
                else if (info.IsPrivate)
                    pyMethod.Visibility = Visibility.Private;
                else
                    pyMethod.Visibility = Visibility.Protected;

                {
                    var declaredParameters = info.GetParameters();
                    foreach (var parameter in declaredParameters)
                    {
                        var pyParameter = new PyMethodArgument
                        {
                            Name = parameter.Name
                        };
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
            var pyModule = GetOrMakeModuleByName(classTranslationInfo.ModuleName);

            // var assemblyTI = _info.GetOrMakeTranslationInfo(_info.CurrentAssembly);
            PyQualifiedName GetBaseClassName()
            {
                var netBaseType = classTranslationInfo.Type.BaseType;
                if ((object)netBaseType == null || netBaseType == typeof(object))
                    return PyQualifiedName.Empty;
                var baseTypeTranslationInfo = _state.Principles.GetOrMakeTranslationInfo(netBaseType);
                if (baseTypeTranslationInfo.Skip)
                    return PyQualifiedName.Empty;
                return _state.Principles.GetPyType(netBaseType, true, null);
            }

            var pyClass = classTranslationInfo.ExportAsModule
                ? null
                : pyModule.FindOrCreateClass(classTranslationInfo.PyName, GetBaseClassName());
            Console.WriteLine(classTranslationInfo.ModuleName);
            _state.Principles.CurrentType = classTranslationInfo.Type;
            try
            {
                _state.Principles.CurrentAssembly = _state.Principles.CurrentType.Assembly;
                var fullname                      = classTranslationInfo.Type.FullName;
                var srcs                          = classTranslationInfo.Type.IsInterface
                    ? interfaces
                        .Where(q => q.FullName == fullname)
                        .Select(q => q.ClassDeclaration)
                        .OfType<IClassOrInterface>().ToArray()
                    : classes
                        .Where(q => q.FullName == fullname)
                        .Select(q => q.ClassDeclaration)
                        .OfType<IClassOrInterface>().ToArray();
                var members = srcs.SelectMany(i => i.Members).ToArray();

                {
                    var constructors = members.OfType<ConstructorDeclaration>().ToArray();
                    if (pyClass == null && constructors.Length > 0)
                        throw new Exception("Class exported as module cannot have constructors");
                    if (constructors.Length > 1)
                        throw new Exception("Python supports only one constructor per class");
                    if (constructors.Any())
                        TranslateConstructor(pyClass, constructors.First());
                }

                foreach (var methodDeclaration in members.OfType<MethodDeclaration>())
                    TranslateMethod(pyModule, pyClass, methodDeclaration);
                foreach (var pDeclaration in members.OfType<CsharpPropertyDeclaration>())
                    TranslateProperty(pyModule, pyClass, pDeclaration);
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
                        classTranslationInfo.PyName,
                        mti
                    );
                    pyModule.BottomCode.Statements.Add(new PyExpressionStatement(callMain));
                }
            }
            TranslateClass_AddModuleRequests(classTranslationInfo, pyModule);
        }

        private void TranslateClass_AddModuleRequests(ClassTranslationInfo classTranslationInfo, PyCodeModule pyModule)
        {
            var moduleCodeRequests = new List<DependsOnModuleCodeRequest>();
            var codeRequests       = (pyModule as ICodeRelated).GetCodeRequests().ToArray();
            {
                var classCodeRequests = (from request in codeRequests.OfType<ClassCodeRequest>()
                        select request.ClassName.FullName)
                    .Distinct()
                    .ToArray();

                foreach (var req in classCodeRequests)
                {
                    var m = Info.ClassTranslations.Values.Where(i => i.PyName.FullName == req).ToArray();
                    if (m.Length != 1)
                        throw new NotSupportedException();
                    var mm = m[0];
                    if (mm.DontIncludeModuleForClassMembers)
                        continue;
                    var includeModule = mm.IncludeModule;
                    if (includeModule == null || mm.ModuleName == pyModule.ModuleName)
                        continue;
                    var h = new DependsOnModuleCodeRequest(includeModule, "class request: " + req);
                    moduleCodeRequests.Add(h);
                }
            }
            {
                // converts DependsOnModuleCodeRequest
                var moduleRequests = (from i in codeRequests.OfType<DependsOnModuleCodeRequest>()
                    where i.ModuleName != null
                    select i).Concat(moduleCodeRequests).ToArray();
                if (moduleRequests.Any())
                    foreach (var mReq in moduleRequests)
                    {
                        var ati = Info.GetOrMakeTranslationInfo(classTranslationInfo.Type.Assembly);
                        if (mReq.ModuleName == null || mReq.ModuleName == pyModule.ModuleName) continue;
                        var usedAliasWhileImport = AppendImportModuleCodeRequest(mReq.ModuleName, pyModule, ati);
                        mReq.UseAlias            = usedAliasWhileImport;
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

                pyMethod.Kind = md.Info.IsStatic ? PyMethodKind.ClassStatic : PyMethodKind.ClassInstance;
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
                        var def = new PyClassFieldDefinition(fti.ScriptName, field.Type.DotnetType);
                        var cti = _state.Principles.GetTi(_state.Principles.CurrentType, true);
                        if (cti.IsArray)
                            continue;
                        if (field.Modifiers.Has("const") ^
                            (fti.Destination == FieldTranslationDestionations.ClassConst))
                            throw new Exception("beige lion");

                        def.IsConst =
                            fti.Destination ==
                            FieldTranslationDestionations.ClassConst; // field.Modifiers.Has("const");                      

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

                            var value = pyValueTranslator.TransValue(item.Value);
                            /*
                            if (!(value is PyConstValue))
                            {
                                // converts to value
                                value = ExpressionEvaluator.Evaluate(value);
                                // dificult to translate-move values to additional class 
                                // var t = new RefactorByMovingToAnotherClass();
                                //value = t.ConvertAndRefactor(value);
                            }
                          
                            */                  
                            def.ConstValue = value;
                        }
                        pyClass.Fields.Add(def);
                        break;
                    }
                    default:
                        throw new NotSupportedException();
                }
            }
        }

        private void TranslateMethod(PyCodeModule pyModule, [CanBeNull] PyClassDefinition pyClass, MethodDeclaration md)
        {
            if (pyClass == null)
                if (!md.Info.IsStatic)
                    throw new Exception(
                        $"Unable to translate {md.Info} method: Module class can contain only static methods");
            Tranlate_MethodOrProperty(pyModule, pyClass, md.Info, md.Body, null);
        }

        private void TranslateProperty(PyCodeModule pyModule, [CanBeNull] PyClassDefinition pyClassDefinition,
            CsharpPropertyDeclaration               propertyDeclaration)
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
                        Tranlate_MethodOrProperty(pyModule, pyClassDefinition, pi.GetGetMethod(), accessor.Statement,
                            pti.GetMethodName);
                }

                if (string.IsNullOrEmpty(pti.SetMethodName)) return;
                accessor = propertyDeclaration.Accessors.FirstOrDefault(u => u.Name == "set");
                if (accessor != null)
                    Tranlate_MethodOrProperty(pyModule, pyClassDefinition, pi.GetSetMethod(), accessor.Statement,
                        pti.SetMethodName);
            }
            else
            {
                pyClassDefinition.Fields.Add(new PyClassFieldDefinition(pti.FieldScriptName, propertyDeclaration.Type.DotnetType)
                {
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