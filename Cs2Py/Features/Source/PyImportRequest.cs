namespace Cs2Py.Source
{
    public class PyImportRequest
    {
        public PyImportRequest(string relativeModulePath, string alias = null)
        {
            RelativeModulePath = relativeModulePath;
            Alias  = alias;
        }

        public string RelativeModulePath { get; }
        public string Alias  { get;  }

        public string GetPyCode()
        {
            return string.IsNullOrEmpty(Alias) 
                ? $"import {RelativeModulePath}"
                : $"import {RelativeModulePath} as {Alias}";
        }
    }
}