using System;

namespace Lang.Python.Tensorflow
{
    [ScriptName("tensorflow.Variable")]
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
            [ScriptName("initial_value")]  T      initialValue,
            [ScriptName("trainable")]      bool   trainable      = true,
            [ScriptName("collections")]    object collections    = null,
            [ScriptName("validate_shape")] bool   validateShape = true,
            [ScriptName("caching_device")] object cachingDevice = null,
            [ScriptName("name")]           object name           = null,
            [ScriptName("variable_def")]   object variableDef   = null,
            [ScriptName("dtype")]          object dtype          = null,
            [ScriptName("expected_shape")] object expectedShape = null,
            [ScriptName("import_scope")]   object importScope   = null,
            [ScriptName("constraint")]     object constraint     = null
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