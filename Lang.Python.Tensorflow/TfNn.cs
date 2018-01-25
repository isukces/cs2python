namespace Lang.Python.Tensorflow
{
    //[ScriptName("tensorflow.nn")]
    [PyModule("tensorflow.nn", true, ImportModule="tensorflow")]
    [ExportAsPyModule]
    public class TfNn
    {
        [DirectCall("relu")]
        public static Tensor<T> Relu<T>(Tensor<T> src)
        {
            throw new System.NotImplementedException();
        }
    }
}