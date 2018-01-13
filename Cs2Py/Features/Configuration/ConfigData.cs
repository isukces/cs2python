using System;
using System.Collections.Generic;

namespace Cs2Py.Configuration
{
    internal class ConfigData : MarshalByRefObject, IConfigData
    {
        public ConfigData()
        {
            Referenced                 = new List<string>();
            TranlationHelpers          = new List<string>();
            ReferencedPyLibsLocations = new Dictionary<string, string>();
        }

        // ReSharper disable once UnusedAutoPropertyAccessor.Global
        public string                     Configuration              { get; set; }
        public List<string>               Referenced                 { get; private set; }
        public Dictionary<string, string> ReferencedPyLibsLocations { get; set; }
        public List<string>               TranlationHelpers          { get; private set; }
        public string                     CsProject                  { get; set; }
        public string                     OutDir                     { get; set; }
        public string                     BinaryOutputDir            { get; set; }
    }
}