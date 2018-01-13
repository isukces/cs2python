using System.Collections.Generic;
using Cs2Py.Emit;

namespace Cs2Py.Source
{
    public class PySwitchStatement : PyStatementBase
    {
        // Public Methods 

        public override void Emit(PySourceCodeEmiter emiter, PySourceCodeWriter writer, PyEmitStyle style)
        {
            writer.OpenLnF("switch ({0}) {{", Expression.GetPyCode(style));
            foreach (var sec in Sections)
            {
                foreach (var l in sec.Labels)
                    writer.WriteLnF("{0}{1}:",
                        l.IsDefault ? "" : "case ",
                        l.IsDefault ? "default" : l.Value.GetPyCode(style));
                writer.IncIndent();
                sec.Statement.Emit(emiter, writer, style);
                writer.DecIndent();
            }

            writer.CloseLn("}");
        }

        public override IEnumerable<ICodeRequest> GetCodeRequests()
        {
            var result = new List<ICodeRequest>();
            if (Expression != null)
                result.AddRange(Expression.GetCodeRequests());
            foreach (var sec in Sections)
                result.AddRange(sec.GetCodeRequests());
            return result;
        }

        public override IPyStatement Simplify(IPySimplifier s)
        {
            var changed = false;
            var e1      = s.Simplify(Expression);
            if (!EqualCode(e1, Expression))
                changed = true;

            var s1 = new List<PySwitchSection>();
            foreach (var i in Sections)
            {
                bool wasChanged;
                var  n = i.Simplify(s, out wasChanged);
                if (wasChanged)
                    changed = true;
                s1.Add(n);
            }

            if (!changed)
                return this;
            return new PySwitchStatement
            {
                Expression = e1,
                Sections   = s1
            };
        }


        /// <summary>
        /// </summary>
        public IPyValue Expression { get; set; }

        /// <summary>
        /// </summary>
        public List<PySwitchSection> Sections { get; set; } = new List<PySwitchSection>();
    }
}