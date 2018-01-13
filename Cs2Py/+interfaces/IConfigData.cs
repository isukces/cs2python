using System.Collections.Generic;

namespace Cs2Py
{
    public interface IConfigData
    {
        string                     Configuration              { get; set; }
        string                     CsProject                  { get; set; }
        string                     OutDir                     { get; set; }
        List<string>               Referenced                 { get; }
        Dictionary<string, string> ReferencedPyLibsLocations { get; }
        List<string>               TranlationHelpers          { get; }
        string                     BinaryOutputDir            { get; set; }
    }
}