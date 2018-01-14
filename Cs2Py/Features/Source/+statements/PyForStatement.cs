using System.Collections.Generic;
using System.Linq;
using Cs2Py.Emit;

namespace Cs2Py.Source
{
    public class PyForStatement : PyStatementBase
    {
        /// <summary>
        ///     Tworzy instancję obiektu
        ///     <param name="initVariables"></param>
        ///     <param name="condition"></param>
        ///     <param name="statement"></param>
        ///     <param name="incrementors"></param>
        /// </summary>
        public PyForStatement(PyAssignExpression[] initVariables, IPyValue condition, IPyStatement statement,
            IPyStatement[]                          incrementors)
        {
            InitVariables = initVariables;
            Condition     = condition;
            Statement     = statement;
            Incrementors  = incrementors;
        }

        // Private Methods 

        private static string Collect(PySourceCodeEmiter emiter, PyEmitStyle style, IPyStatement[] collection)
        {
            var list             = new List<string>();
            var xStyle           = PyEmitStyle.xClone(style);
            xStyle.AsIncrementor = true;
            foreach (var item in collection)
            {
                var writer = new PySourceCodeWriter();
                writer.Clear();
                item.Emit(emiter, writer, xStyle);
                list.Add(writer.GetCode().Trim());
            }

            return string.Join(", ", list);
        }

        private static string Collect(PySourceCodeEmiter emiter, PyEmitStyle style, IPyValue[] collection)
        {
            var list             = new List<string>();
            var xStyle           = PyEmitStyle.xClone(style);
            xStyle.AsIncrementor = true;
            foreach (var item in collection) list.Add(item.GetPyCode(xStyle));
            return string.Join(", ", list);
        }

        // Public Methods 

        public override void Emit(PySourceCodeEmiter emiter, PySourceCodeWriter writer, PyEmitStyle style)
        {
            var pyIncrementrors = Collect(emiter, style, Incrementors);
            var pyInitVariables = Collect(emiter, style, InitVariables);

            style = style ?? new PyEmitStyle();

            var header =
                style.Compression == EmitStyleCompression.Beauty
                    ? "for({0}; {1}; {2})"
                    : "for({0};{1};{2})";
            header = string.Format(header, pyInitVariables, Condition.GetPyCode(style), pyIncrementrors);

            EmitHeaderStatement(emiter, writer, style, header, Statement);
        }

        public override IEnumerable<ICodeRequest> GetCodeRequests()
        {
            var a = GetCodeRequests<PyAssignExpression>(InitVariables);
            var b = GetCodeRequests<IPyStatement>(Incrementors);
            var c = GetCodeRequests(Condition, Statement);
            return a.Union(b).Union(c);
        }

        public override IPyStatement Simplify(IPySimplifier s)
        {
            var initVariables = InitVariables == null
                ? null
                : InitVariables.Select(u => s.Simplify(u)).Cast<PyAssignExpression>().ToArray();
            var condition    = s.Simplify(Condition);
            var statement    = s.Simplify(Statement);
            var incrementors = Incrementors == null
                ? null
                : Incrementors.Select(u => s.Simplify(u)).ToArray();
            var theSame = EqualCode(condition, Condition) && EqualCode(statement, Statement) &&
                          EqualCode_Array(initVariables, InitVariables) &&
                          EqualCode_Array(incrementors,  Incrementors);
            if (theSame)
                return this;
            return new PyForStatement(initVariables, condition, statement, incrementors);
        }


        /// <summary>
        /// </summary>
        public PyAssignExpression[] InitVariables { get; set; }

        /// <summary>
        /// </summary>
        public IPyValue Condition { get; set; }

        /// <summary>
        /// </summary>
        public IPyStatement Statement { get; set; }

        /// <summary>
        /// </summary>
        public IPyStatement[] Incrementors { get; set; }
    }
}