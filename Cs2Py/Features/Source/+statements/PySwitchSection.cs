using System.Collections.Generic;

namespace Cs2Py.Source
{
    public class PySwitchSection : ICodeRelated
    {
        public IEnumerable<ICodeRequest> GetCodeRequests()
        {
            var result = new List<ICodeRequest>();
            if (Labels != null)
                foreach (var label in Labels)
                    result.AddRange(label.GetCodeRequests());
            if (Statement != null)
                result.AddRange(Statement.GetCodeRequests());
            return result;
        }

        public PySwitchSection Simplify(IPySimplifier s, out bool wasChanged)
        {
            wasChanged  = false;
            var nLabels = new List<PySwitchLabel>();
            foreach (var lab in Labels)
            {
                nLabels.Add(lab.Simplify(s, out var labelWasChanged));
                if (labelWasChanged) wasChanged = true;
            }

            var nStatement = s.Simplify(Statement);
            if (!PySourceBase.EqualCode(nStatement, Statement))
                wasChanged = true;
            if (!wasChanged)
                return this;
            return new PySwitchSection
            {
                Labels    = nLabels.ToArray(),
                Statement = nStatement
            };
        }

        /// <summary>
        /// </summary>
        public PySwitchLabel[] Labels { get; set; }

        /// <summary>
        /// </summary>
        public IPyStatement Statement { get; set; }
    }
}