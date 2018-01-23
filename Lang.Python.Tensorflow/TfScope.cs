using System;

namespace Lang.Python.Tensorflow
{
    public class TfScope : IDisposable
    {
        internal TfScope(string scopeName)
        {
            ScopeName = scopeName;
        }

        public void Dispose()
        {
        }

        public string ScopeName { get; }
    }

    public enum TfDataType
    {
        float32
    }
}