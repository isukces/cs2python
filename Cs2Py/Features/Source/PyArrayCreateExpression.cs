using System;
using System.Collections.Generic;
using Cs2Py.Emit;

namespace Cs2Py.Source
{
    public class PyArrayCreateExpression : PyValueBase, ICodeRelated
    {
        /// <summary>
        ///     Tworzy instancję obiektu
        ///     <param name="initializers">wartości inicjujące</param>
        /// </summary>
        public PyArrayCreateExpression(params IPyValue[] initializers)
        {
            Initializers = initializers;
        }


        /// <summary>
        ///     Tworzy instancję obiektu
        /// </summary>
        public PyArrayCreateExpression()
        {
        }

        public static PyArrayCreateExpression MakeKeyValue(params IPyValue[] keyValues)
        {
            if (keyValues.Length % 2 == 1)
                throw new ArgumentException("key_values");
            var a = new List<IPyValue>();
            for (var i = 1; i < keyValues.Length; i += 2)
            {
                if (keyValues[i] == null)
                    continue;
                var g = new PyAssignExpression(keyValues[i - 1], keyValues[i]);
                a.Add(g);
            }

            return new PyArrayCreateExpression(a.ToArray());
        }

        // Public Methods 

        public override IEnumerable<ICodeRequest> GetCodeRequests()
        {
            if (Initializers == null || Initializers.Length == 0)
                return new ICodeRequest[0];
            var l = new List<ICodeRequest>();
            foreach (var i in Initializers)
            {
                var ll = i.GetCodeRequests();
                l.AddRange(ll);
            }

            return l;
        }

        public override string GetPyCode(PyEmitStyle style)
        {
            if (Initializers == null || Initializers.Length == 0)
                return "array()";
            style         = style ?? new PyEmitStyle();
            var przecinek = style.Compression == EmitStyleCompression.Beauty ? ", " : ",";
            var www       = style.Compression == EmitStyleCompression.Beauty ? " => " : "=>";

            var list = new List<string>();
            foreach (var initializeValue in Initializers)
                if (initializeValue is PyAssignExpression)
                {
                    var assignExpression = initializeValue as PyAssignExpression;
                    if (!string.IsNullOrEmpty(assignExpression.OptionalOperator))
                        throw new NotSupportedException();

                    if (assignExpression.Left is PyArrayAccessExpression)
                    {
                        var left = assignExpression.Left as PyArrayAccessExpression;
                        if (left.PyArray is PyThisExpression)
                        {
                            var o = left.Index + www + assignExpression.Right;
                            list.Add(o);
                        }
                        else
                        {
                            throw new NotSupportedException();
                        }
                    }
                    else if (assignExpression.Left is PyInstanceFieldAccessExpression)
                    {
                        var l1 = assignExpression.Left as PyInstanceFieldAccessExpression;
                        var fn = new PyConstValue(l1.FieldName);
                        var o  = fn.GetPyCode(style) + www + assignExpression.Right;
                        list.Add(o);
                    }
                    else
                    {
                        var o = assignExpression.Left.GetPyCode(style) + www + assignExpression.Right;
                        list.Add(o);
                    }
                }
                else
                {
                    list.Add(initializeValue.GetPyCode(style));
                }

            return "array(" + string.Join(przecinek, list) + ")";
        }


        /// <summary>
        ///     wartości inicjujące
        /// </summary>
        public IPyValue[] Initializers { get; set; }
    }
}