namespace Lang.Python.Tensorflow
{
    //[ScriptName("tensorflow.nn")]
    [Module("tensorflow.nn", true, ClassIsModule = true, ImportModule="tensorflow")]
    public class TfNn
    {
        [DirectCall("relu")]
        public static Tensor<T> Relu<T>(Tensor<T> src)
        {
            throw new System.NotImplementedException();
        }
    }
}