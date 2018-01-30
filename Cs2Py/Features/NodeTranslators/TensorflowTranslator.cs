using System;
using System.Reflection;
using Cs2Py.CSharp;
using Cs2Py.Source;
using Lang.Python;
using Lang.Python.Tensorflow;

namespace Cs2Py.NodeTranslators
{
    public class TensorflowTranslator : IPyNodeTranslator<CsharpMethodCallExpression>
    {
        public int GetPriority()
        {
            return -10;
        }

        public IPyValue TranslateToPython(IExternalTranslationContext ctx, CsharpMethodCallExpression src)
        {
            if (!typeof(TfScope).Assembly.Equals(src.MethodInfo.DeclaringType?.Assembly))
                return null;
            var mi = src.GenericMethodInfo;
            if (mi.GetCustomAttribute<DirectCallAttribute>() != null)
                return null;
            var name = mi.ToString();
            var dt = mi.DeclaringType;

            if (mi.GetCustomAttribute<DirectCallAttribute>() != null)
                return null;
            //Lang.Python.Tensorflow.TfScope NameScope(System.String)
            if (dt == typeof(Tf))
            {
                if (name == "Lang.Python.Tensorflow.TfScope NameScope(System.String)")
                {
                   
                }

                if (mi.Name == nameof(Tf.TruncatedNormal))
                {
                    
                }
                
            }

            throw new NotImplementedException(name);
        }
    }
}