using System;
using System.Collections.Generic;
using System.Linq;
using Cs2Py.CSharp;
using Cs2Py.Source;
using JetBrains.Annotations;

namespace Cs2Py.Translator
{
    public interface IStatementTranslator
    {
        IPyStatement[] TranslateStatement([NotNull] IStatement x);
        IPyValue TransValue(IValue x);
    }

    public static class StatementTranslatorExtensions
    {
        public static IPyStatement TranslateStatementOne(this IStatementTranslator self, IStatement x)
        {
            if (x == null)
                return null;
            var a = self.TranslateStatement(x);
            if (a.Length == 1)
                return a[0];
            return new PyCodeBlock {Statements = a.ToList()};
        }

        public static IPyStatement[] TranslateStatements(this IStatementTranslator self, IEnumerable<IStatement> x)
        {
            if (x == null)
                return new IPyStatement[0];
            var re    = new List<IPyStatement>();
            var index = -1;
            foreach (var i in x)
            {
                index++;
                if (i == null)
                    throw new NullReferenceException($"statement index={index} is null");
                var j = self.TranslateStatement(i);
                foreach (var tt in j) re.Add(tt);
            }

            return re.ToArray();
        }
    }
}