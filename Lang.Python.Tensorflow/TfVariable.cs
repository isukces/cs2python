using System;

namespace Lang.Python.Tensorflow
{
    [PyName("tensorflow.Variable")]
    // tensorflow.python.ops.variables.Variable
    public class TfVariable<T>
    {
        // https://www.tensorflow.org/api_docs/python/tf/Variable
        /*
         * __init__(
    initial_value=None,
    trainable=True,
    collections=None,
    validate_shape=True,
    caching_device=None,
    name=None,
    variable_def=None,
    dtype=None,
    expected_shape=None,
    import_scope=None,
    constraint=None
)
         */

        
        internal TfVariable(
            [PyName("initial_value")]  T      initialValue,
            [PyName("trainable")]      bool   trainable      = true,
            [PyName("collections")]    object collections    = null,
            [PyName("validate_shape")] bool   validateShape = true,
            [PyName("caching_device")] object cachingDevice = null,
            [PyName("name")]           object name           = null,
            [PyName("variable_def")]   object variableDef   = null,
            [PyName("dtype")]          object dtype          = null,
            [PyName("expected_shape")] object expectedShape = null,
            [PyName("import_scope")]   object importScope   = null,
            [PyName("constraint")]     object constraint     = null
        )
        {
        }

        
        [DirectCall(null)]
        public static implicit operator T(TfVariable<T> src)
        {
            throw new NotImplementedException();
        }
    }
}