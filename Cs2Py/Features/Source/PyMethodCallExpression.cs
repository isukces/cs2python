using System.Collections.Generic;
using System.Linq;
using Cs2Py.Compilation;
using Cs2Py.Emit;
using Lang.Python;

namespace Cs2Py.Source
{
    public class PyMethodCallExpression : PyValueBase
    {
        /// <summary>
        ///     Tworzy instancję obiektu
        ///     <param name="name"></param>
        /// </summary>
        public PyMethodCallExpression(string name, params IPyValue[] args)
        {
            _name = name;
            Arguments.AddRange(args.Select(i => new PyMethodInvokeValue(i)));
        }

        /// <summary>
        ///     Tworzy instancję obiektu
        ///     <param name="name"></param>
        /// </summary>
        public PyMethodCallExpression(IPyValue targetObject, string name, params IPyValue[] args)
        {
            _name = name;
            Arguments.AddRange(args.Select(i => new PyMethodInvokeValue(i)));
            TargetObject = targetObject;
        }


        /// <summary>
        ///     Tworzy instancję obiektu
        ///     <param name="name"></param>
        /// </summary>
        public PyMethodCallExpression(string name)
        {
            Name = name;
        }

        // Public Methods 


        public static PyMethodCallExpression MakeConstructor(string constructedClassName,
            MethodTranslationInfo                                   translationInfo, params IPyValue[] args)
        {
            var methodCallExpression = new PyMethodCallExpression(ConstructorMethodName, args);
            methodCallExpression.SetClassName((PyQualifiedName)constructedClassName, translationInfo);
            return methodCallExpression;
        }

        // Public Methods 

        public override IEnumerable<ICodeRequest> GetCodeRequests()
        {
            var requests = PyStatementBase.GetCodeRequests(Arguments.Select(i => i.Expression)).ToList();
            if (!_className.IsEmpty && !DontIncludeClass && _className.EmitName != PyQualifiedName.ClassnameSelf)
                requests.Add(new ClassCodeRequest(_className));
            if (TargetObject != null)
                requests.AddRange(TargetObject.GetCodeRequests());
            return requests;
        }

        public override string GetPyCode(PyEmitStyle style)
        {
            var join      = style == null || style.Compression == EmitStyleCompression.Beauty ? ", " : ",";
            var xstyle    = PyEmitStyle.xClone(style);
            var arguments = string.Join(join, Arguments.Select(i => i.GetPyCode(xstyle)));
            if (IsConstructorCall)
            {
                var a = string.Format("new {0}({1})", _className.NameForEmit(style), arguments);
                return a;
            }

            var name = _name;
            if (!_className.IsEmpty)
            {
                name = _className.NameForEmit(style) + "::" + name;
            }
            else if (TargetObject != null)
            {
                var to = TargetObject;
                if (TargetObject is PyMethodCallExpression &&
                    (TargetObject as PyMethodCallExpression).IsConstructorCall)
                    to = new PyParenthesizedExpression(to);
                name   = to.GetPyCode(style) + "." + name;
            }

            var code = string.Format(SkipBrackets ? "{0} {1}" : "{0}({1})", name, arguments);
            return code;
        }

        public void SetClassName(PyQualifiedName className, MethodTranslationInfo translationInfo)
        {
            _className      = className.MakeAbsolute();
            TranslationInfo = translationInfo;
        }

        public override string ToString()
        {
            return GetPyCode(new PyEmitStyle());
        }

        public MethodCallStyles CallType
        {
            get
            {
                if (TargetObject != null)
                    return MethodCallStyles.Instance;
                return _className.IsEmpty ? MethodCallStyles.Procedural : MethodCallStyles.Static;
            }
        }

        /// <summary>
        /// </summary>
        public string Name
        {
            get => _name;
            private set => _name = (value ?? string.Empty).Trim();
        }

        /// <summary>
        /// </summary>
        public List<PyMethodInvokeValue> Arguments { get; set; } = new List<PyMethodInvokeValue>();

        /// <summary>
        ///     Własność jest tylko do odczytu.
        /// </summary>
        public bool IsConstructorCall => _name == ConstructorMethodName;

        /// <summary>
        /// </summary>
        public IPyValue TargetObject { get; set; }

        /// <summary>
        ///     Nazwa klasy dla konstruktora lub metody statycznej; własność jest tylko do odczytu.
        /// </summary>
        public PyQualifiedName ClassName => _className;

        /// <summary>
        ///     indicates that method is from standard Py class or other framework i.e. Wordpress
        /// </summary>
        public bool DontIncludeClass { get; set; }

        /// <summary>
        /// </summary>
        public MethodTranslationInfo TranslationInfo { get; private set; }

        public bool SkipBrackets { get; set; }

        private string _name = string.Empty;

        private PyQualifiedName _className;

        public const string ConstructorMethodName = "*";
    }
}