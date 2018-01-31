using System.Collections.Generic;
using Cs2Py.Emit;

namespace Cs2Py.Source
{
    public class PyCodeBlock : PySourceBase, IPyStatement, ICodeRelated
    {
        public PyCodeBlock(IPyStatement other)
        {
            Statements.Add(other);
        }

        public PyCodeBlock()
        {
        }

        public static PyCodeBlock Bound(IPyStatement s)
        {
            if (s is PyCodeBlock)
                return s as PyCodeBlock;
            var g = new PyCodeBlock();
            g.Statements.Add(s);
            return g;
        }

        // Public Methods 

        public static bool HasAny(IPyStatement x)
        {
            if (x == null) return false;
            if (x is PyCodeBlock)
            {
                var src = x as PyCodeBlock;
                if (src.Statements.Count == 0) return false;
                if (src.Statements.Count > 1) return true;
                return HasAny(src.Statements[0]);
            }

            return true;
        }

        public static IPyStatement Reduce(IPyStatement x)
        {
            if (x == null) return x;
            if (x is PyCodeBlock)
            {
                var src = x as PyCodeBlock;
                if (src.Statements.Count == 0) return null;
                if (src.Statements.Count > 1) return x;
                return Reduce(src.Statements[0]);
            }

            return x;
        }

        // Public Methods 

        public void Emit(PySourceCodeEmiter emiter, PySourceCodeWriter writer, PyEmitStyle style)
        {
            if (Statements.Count == 0)
                return;
            var bracketStyle = style == null ? ShowBracketsEnum.IfManyItems : style.Brackets;
            var brack        =
                bracketStyle == ShowBracketsEnum.Never
                    ? false
                    : bracketStyle == ShowBracketsEnum.Always
                        ? true
                        : Statements == null || !(Statements.Count == 1);

            if (Statements != null && Statements.Count == 1 &&
                bracketStyle == ShowBracketsEnum.IfManyItems_OR_IfStatement)
                if (Statements[0] is PyIfStatement)
                    brack = true;

            var iStyle = PyEmitStyle.xClone(style, ShowBracketsEnum.Never);
             

            if (brack)
                writer.OpenLn("{");
            foreach (var i in Statements)
                i.Emit(emiter, writer, iStyle);
            if (brack)
                writer.CloseLn("}");
        }

        public IEnumerable<ICodeRequest> GetCodeRequests()
        {
            if (Statements.Count == 0)
                return new ICodeRequest[0];
            var r = new List<ICodeRequest>();
            foreach (var i in Statements)
                r.AddRange(i.GetCodeRequests());
            return r;
        }

        public List<IPyStatement> GetPlain()
        {
            var o = new List<IPyStatement>();
            if (Statements == null || Statements.Count == 0)
                return o;
            foreach (var i in Statements)
                if (i is PyCodeBlock)
                    o.AddRange((i as PyCodeBlock).GetPlain());
                else
                    o.Add(i);
            return o;
        }


        public StatementEmitInfo GetStatementEmitInfo(PyEmitStyle style)
        {
            return StatementEmitInfo.NormalSingleStatement; // sam troszczę się o swoje nawiasy
        }


        /// <summary>
        /// </summary>
        public List<IPyStatement> Statements { get; set; } = new List<IPyStatement>();
    }
}