using System;
using System.Collections.Generic;

namespace Lang.Python.Plot
{
    [PyModule("matplotlib.pyplot", true, ImportModule = "matplotlib")]
    [ExportAsPyModule]
    public class PyPlot
    {
        [DirectCall("plot")]
        public static List<Line2D> Plot(List<double> x, List<double> y)
        {
            throw new NotImplementedException();
        }
    }
}