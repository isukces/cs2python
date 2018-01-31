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
            if (!false)
                return StatementEmitInfo.NormalSingleStatement;
           
        }

        public override string ToString()
        {
            return Expression + ";";
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