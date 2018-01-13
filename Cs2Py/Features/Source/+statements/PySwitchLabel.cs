using System.Collections.Generic;

namespace Cs2Py.Source
{
    public class PySwitchLabel : ICodeRelated
    {
        /// <summary>
        ///     Tworzy instancję obiektu
        /// </summary>
        public PySwitchLabel()
        {
        }

        /// <summary>
        ///     Tworzy instancję obiektu
        ///     <param name="value"></param>
        /// </summary>
        public PySwitchLabel(IPyValue value)
        {
            Value = value;
        }
        // Public Methods 

        public IEnumerable<ICodeRequest> GetCodeRequests()
        {
            if (Value != null)
                return Value.GetCodeRequests();
            return new ICodeRequest[0];
        }

        public PySwitchLabel Simplify(IPySimplifier s, out bool wasChanged)
        {
            wasChanged = false;
            if (IsDefault)
                return this;
            var e1     = s.Simplify(Value);
            wasChanged = !PySourceBase.EqualCode(e1, Value);
            if (wasChanged)
                return new PySwitchLabel(e1);
            return this;
        }


        /// <summary>
        /// </summary>
        public IPyValue Value { get; set; }

        /// <summary>
        /// </summary>
        public bool IsDefault { get; set; }
    }
}