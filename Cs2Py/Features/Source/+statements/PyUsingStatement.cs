using System.Collections.Generic;
using Cs2Py.CSharp;
using Cs2Py.Emit;

namespace Cs2Py.Source
{
    public class PyUsingStatement : PyStatementBase, IStatement
    {
        // Public Methods 

        public override void Emit(PySourceCodeEmiter emiter, PySourceCodeWriter writer, PyEmitStyle style)
        {
            //   with tf.name_scope('hidden2') as name:
            writer.WriteLnF("with {0}:", Variable.GetPyCode(style));
            writer.Intent++;
            foreach (var sec in Statements)
                sec.Emit(emiter, writer, style);
            writer.Intent--;
        }

        public override IEnumerable<ICodeRequest> GetCodeRequests()
        {
            var result = new List<ICodeRequest>();
            if (Variable != null)
                result.AddRange(Variable.GetCodeRequests());
            foreach (var sec in Statements)
                result.AddRange(sec.GetCodeRequests());
            return result;
        }


        /// <summary>
        /// </summary>
        public PyUsingStatementVariable Variable { get; set; }

        /// <summary>
        /// </summary>
        public List<IPyStatement> Statements { get; set; } = new List<IPyStatement>();
    }

    public class PyUsingStatementVariable
    {
        public IEnumerable<ICodeRequest> GetCodeRequests()
        {
            if (Value == null)
                return new ICodeRequest[0];
            return Value.GetCodeRequests();
        }

        public string GetPyCode(PyEmitStyle style)
        {
            var tmp = Value?.GetPyCode(style);
            if (string.IsNullOrEmpty(Name))
                return tmp;
            return $"{tmp} as {Name}";
        }

        public string Name
        {
            get => _name;
            set => _name = value?.Trim();
        }

        public  IPyValue Value { get; set; }
        private string   _name;
    }
}