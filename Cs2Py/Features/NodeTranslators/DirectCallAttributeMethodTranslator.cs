using System;
using System.Linq;
using System.Reflection;
using Cs2Py.CSharp;
using Cs2Py.Source;
using Lang.Python;

namespace Cs2Py.NodeTranslators
{
    public class DirectCallAttributeMethodTranslator : BaseCsharpMethodCallExpressionTranslator
    {
        public DirectCallAttributeMethodTranslator() : base(2)
        {
        }


        public override IPyValue TranslateToPython(IExternalTranslationContext ctx, CsharpMethodCallExpression src)
        {
            string GetOperatorName()
            {
                if (!src.MethodInfo.IsSpecialName)
                    return null;

                switch (src.MethodInfo.Name)
                {
                    case "op_Addition":    return "+";
                    case "op_Subtraction": return "-";
                    case "op_Multiply":    return "*";
                    case "op_Division":    return "/";

                    case "op_Equality":    return "==";
                    case "op_Inequality ": return "!=";
                    case "op_Implicit":    return "i";
                }

                return null;
            }

            var ats = src.MethodInfo.GetCustomAttribute<DirectCallAttribute>();
            if (ats == null)
                return null;

            var name                             = ats.Name;
            var opName                           = GetOperatorName();
            if (string.IsNullOrEmpty(name)) name = src.MethodInfo.Name;

            if (opName != null)
                name = opName;

            var cSharpParameters = src.MethodInfo.GetParameters();
            var agrsIndexByName  = Enumerable.Range(0, cSharpParameters.Length)
                .ToDictionary(a => cSharpParameters[a].Name, a => a);
            var argsValues = new Argument[cSharpParameters.Length];
            var info = MapNamedParameters(src);
            for (var index = 0; index < src.Arguments.Length; index++)
            {
                var i = src.Arguments[index];

                var pythonArgName = cSharpParameters[index].Name;
                if (!string.IsNullOrEmpty(i.ExplicitName))
                    pythonArgName = i.ExplicitName;

                var b               = ctx.TranslateValue(i.MyValue);
                var pyIndex         = agrsIndexByName[pythonArgName];
                argsValues[pyIndex] = new Argument
                {
                    Value = b,
                    Name  = cSharpParameters[pyIndex].Name
                };
            }

            if (opName != null)
            {
                if (opName == "i" && argsValues.Length == 1) return argsValues[0].Value;
                switch (argsValues.Length)
                {
                    case 2:
                        return new PyBinaryOperatorExpression(opName, argsValues[0].Value, argsValues[1].Value);
                    case 1:
                        return new PyUnaryOperatorExpression(argsValues[0].Value, opName);
                }

                throw new NotSupportedException("Unable to convert operator " + opName + " with " + argsValues.Length +
                                                " arguments");
            }

            var result  = new PyMethodCallExpression(name);
            var setName = false;
            foreach (var i in argsValues)
            {
                if (i == null)
                {
                    setName = true;
                    continue;
                }

                var item = new PyMethodInvokeValue(i.Value);
                if (setName)
                    item.Name = i.Name;
                result.Arguments.Add(item);
            }

            result.TrySetTargetObjectFromModule(src.MethodInfo.DeclaringType);
            return result;
        }

        private class Argument
        {
            public IPyValue Value { get; set; }
            public string   Name  { get; set; }
        }
    }
}