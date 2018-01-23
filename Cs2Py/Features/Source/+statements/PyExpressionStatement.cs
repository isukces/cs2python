using System;
using System.Collections.Generic;
using System.Linq;
using Cs2Py.CodeVisitors;
using Cs2Py.Emit;
using Lang.Python;

namespace Cs2Py.Source
{
    /// <summary>
    ///     Opakowuje expression jako statement, np. postincrementacja, wywołanie metody itp.
    /// </summary>
    public class PyExpressionStatement : PyStatementBase
    {
        /// <summary>
        ///     Tworzy instancję obiektu
        ///     <param name="expression"></param>
        /// </summary>
        public PyExpressionStatement(IPyValue expression)
        {
            Expression = expression;
        }
        // Private Methods 

        private static IPyValue Aaa(IPyValue x)
        {
            var constExpression = x as PyDefinedConstExpression;
            if (constExpression == null) return x;
            return constExpression.DefinedConstName == "Py_EOL" ? new PyConstValue("\r\n") : x;
        }
        // Private Methods 

        private static IEnumerable<string> SplitToLines(string code)
        {
            var result = new List<string>();
            while (code.IndexOf("\r\n", StringComparison.Ordinal) > 0)
            {
                var idx = code.IndexOf("\r\n", StringComparison.Ordinal) + 2;
                result.Add(code.Substring(0, idx));
                code = code.Substring(idx);
            }

            if (code != "")
                result.Add(code);
            return result.ToArray();
        }

        // Public Methods 

        public override void Emit(PySourceCodeEmiter emiter, PySourceCodeWriter writer, PyEmitStyle style)
        {
            style = PyEmitStyle.xClone(style);
            if (!style.AsIncrementor)
            {
                switch (Expression)
                {
                    case PyEmptyExpression _:
                        return;
                    case PyMethodCallExpression methodCallExpression:
                        if (methodCallExpression.CallType == MethodCallStyles.Procedural
                            && methodCallExpression.Name == "echo")
                            if (EmitInlineHtml(writer, style))
                                return;
                        break;
                }
            }

            var code = Expression.GetPyCode(style);
            if (style.AsIncrementor)
                writer.Write(code);
            else
                writer.WriteLn(code);
        }

        public override IEnumerable<ICodeRequest> GetCodeRequests()
        {
            return GetCodeRequests(Expression);
        }

        public override StatementEmitInfo GetStatementEmitInfo(PyEmitStyle style)
        {
            if (!IsEcho)
                return StatementEmitInfo.NormalSingleStatement;
            var a = GetEchoItems(null);
            if (a.Length == 0)
                return StatementEmitInfo.Empty;
            if (a.Length != 1)
                return StatementEmitInfo.ManyItemsOrPlainHtml;
            return a[0].PlainHtml
                ? StatementEmitInfo.ManyItemsOrPlainHtml
                : StatementEmitInfo.NormalSingleStatement;
        }

        public override string ToString()
        {
            return Expression + ";";
        }

        private bool EmitInlineHtml(PySourceCodeWriter writer, PyEmitStyle style)
        {
            // return false;
            var values = GetEchoItems(style);
            //if (Values.Length == 1)
            //    return false;
            {
                foreach (var i in values)
                {
                    if (i.PlainHtml)
                        throw new NotSupportedException();
                    writer.WriteLn("echo " + i.Code + ";");
                }

                return true;
            }
#if VERSION1
            {
                {
                    if (Values.Length == 1)
                    {
                        if (!Values[0].PlainHtml)
                        {
                            return false;
                        }
                    }
                }

                bool isHtml = false;
                int iii = Values.Length;
                bool isFirst = true;
                foreach (var i in Values)
                {
                    bool isLast = --iii == 0;
                    try
                    {
                        var code = i.Code;
                        if (isFirst && !i.PlainHtml)
                        {
                            writer.WriteLn("echo " + code + ";");
                            continue;
                        }

                        if (!i.PlainHtml)
                            code = "<?= " + code + " ?>";
                        if (!isHtml)
                        {
                            code = "?>" + code;
                            isHtml = true;
                        }
                        if (isLast && isHtml)
                            code += "<?Py";
                        if (!isFirst)
                            writer.SkipIndent = true;
                        if (isHtml && !isLast)
                            writer.Write(code);
                        else
                            writer.WriteLn(code);
                    }
                    finally
                    {
                        isFirst = false;
                    }
                }
            } 
#endif
        }

        private EchoEmitItem[] GetEchoItems(PyEmitStyle style)
        {
            var values = new List<IPyValue>();
            {
                var methodCall = Expression as PyMethodCallExpression;
                if (methodCall == null)
                    return
                        null;
                if (methodCall.CallType != MethodCallStyles.Procedural || methodCall.Name != "echo")
                    return null;
                foreach (var xx in methodCall.Arguments)
                    values.AddRange(ExpressionSimplifier.ExplodeConcats(xx, "."));
                values = values.Select(Aaa).ToList();

                for (var i = 1; i < values.Count; i++)
                {
                    var a1 = values[i - 1];
                    var a2 = values[i];
                    if (!(a1 is PyConstValue) || !(a2 is PyConstValue)) continue;
                    var b1 = (a1 as PyConstValue).Value;
                    var b2 = (a2 as PyConstValue).Value;
                    var c1 = PyValues.ToPyCodeValue(b1);
                    var c2 = PyValues.ToPyCodeValue(b2);
                    if (c1.Kind != PyCodeValue.Kinds.StringConstant || c1.Kind != PyCodeValue.Kinds.StringConstant)
                        continue;
                    values[i - 1] = new PyConstValue((string)c1.SourceValue + (string)c2.SourceValue);
                    values.RemoveAt(i);
                    i--;
                }
            }
            {
                IPyValue         echoArguments = null;
                Action<IPyValue> vv            = u =>
                {
                    // ReSharper disable once AccessToModifiedClosure
                    echoArguments = echoArguments == null ? u : new PyBinaryOperatorExpression(".", echoArguments, u);
                };

                var result = new List<EchoEmitItem>();
                foreach (var value in values)
                {
                    if (value is PyConstValue)
                    {
                        var constValue       = (value as PyConstValue).Value;
                        var constStringValue = constValue as string;
                        if (constStringValue != null)
                        {
                            var lines = SplitToLines(constStringValue);
                            foreach (var i in lines)
                                if (i.EndsWith("\r\n"))
                                {
                                    vv(new PyConstValue(i.Substring(0, i.Length - 2)));
                                    vv(new PyDefinedConstExpression("Py_EOL", null));
                                    // ReSharper disable once PossibleNullReferenceException
                                    result.Add(new EchoEmitItem(echoArguments.GetPyCode(style), false));
                                    echoArguments = null;
                                }
                                else
                                {
                                    vv(new PyConstValue(i));
                                }

                            continue;
                        }
                    }

                    vv(value);
                }

                if (echoArguments != null)
                    result.Add(new EchoEmitItem(echoArguments.GetPyCode(style), false));
                return result.ToArray();
            }
        }

        private bool IsEcho
        {
            get
            {
                var callExpression = Expression as PyMethodCallExpression;
                // ProceduralStyleMethodCall checks if expression is PyMethodCallExpression
                // ReSharper disable once PossibleNullReferenceException
                return IsProceduralStyleMethodCall && callExpression.Name == "echo";
            }
        }

        public bool IsProceduralStyleMethodCall
        {
            get
            {
                var callExpression = Expression as PyMethodCallExpression;
                return callExpression != null && callExpression.CallType == MethodCallStyles.Procedural;
            }
        }


        /// <summary>
        /// </summary>
        public IPyValue Expression { get; set; }


        public class EchoEmitItem
        {
            public EchoEmitItem(string code, bool plainHtml)
            {
                Code      = code;
                PlainHtml = plainHtml;
            }

            // Public Methods 

            public override string ToString()
            {
                if (PlainHtml)
                    return Code;
                return "echo " + Code + ";";
            }

            public string Code { get; private set; }

            public bool PlainHtml { get; private set; }
        }
    }
}