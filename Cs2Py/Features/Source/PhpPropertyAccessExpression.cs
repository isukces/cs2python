using System;
using System.Collections.Generic;
using Cs2Py.Compilation;
using Cs2Py.Emit;

namespace Cs2Py.Source
{
    public class PyPropertyAccessExpression : PyValueBase
    {
        /// <summary>
        ///     Tworzy instancję obiektu
        ///     <param name="translationInfo"></param>
        ///     <param name="targetObject"></param>
        /// </summary>
        public PyPropertyAccessExpression(PropertyTranslationInfo translationInfo, IPyValue targetObject)
        {
            TranslationInfo   = translationInfo;
            this.TargetObject = targetObject;
        }
        // Public Methods 

        public override IEnumerable<ICodeRequest> GetCodeRequests()
        {
            return new ICodeRequest[0];
        }

        public override string GetPyCode(PyEmitStyle style)
        {
            if (TranslationInfo == null)
                throw new ArgumentNullException("translationInfo");
            if (TranslationInfo.IsStatic)
                throw new NotSupportedException();
            // jeśli nic nie podano to zakładam odczyt własności
            var a = MakeGetValueExpression();
            return a.GetPyCode(style);
        }

        public IPyValue MakeGetValueExpression()
        {
            if (TranslationInfo == null)
                throw new ArgumentNullException("translationInfo");
            if (TranslationInfo.IsStatic)
                throw new NotSupportedException();
            if (TranslationInfo.GetSetByMethod)
            {
                var a          = new PyMethodCallExpression(TranslationInfo.GetMethodName);
                a.TargetObject = TargetObject;
                return a;
            }
            else
            {
                var a = new PyInstanceFieldAccessExpression(TranslationInfo.FieldScriptName, TargetObject, null);
                return a;
            }
        }

        public IPyValue MakeSetValueExpression(IPyValue v)
        {
            if (TranslationInfo == null)
                throw new ArgumentNullException("translationInfo");
            if (TranslationInfo.IsStatic)
                throw new NotSupportedException();

            if (TranslationInfo.GetSetByMethod)
            {
                var a = new PyMethodCallExpression(TranslationInfo.SetMethodName);
                a.Arguments.Add(new PyMethodInvokeValue(v));
                a.TargetObject = TargetObject;
                return a;
            }
            else
            {
                var a = new PyInstanceFieldAccessExpression(TranslationInfo.FieldScriptName, TargetObject, null);
                var b = new PyAssignExpression(a, v);
                return b;
            }
        }

        public override IPyValue Simplify(IPyExpressionSimplifier s)
        {
            var to = SimplifyForFieldAcces(TargetObject, s);
            if (EqualCode(TargetObject, to))
                return this;

            return new PyPropertyAccessExpression(TranslationInfo, to);
        }


        /// <summary>
        /// </summary>
        public PropertyTranslationInfo TranslationInfo { get; set; }

        /// <summary>
        /// </summary>
        public IPyValue TargetObject { get; set; }
    }
}