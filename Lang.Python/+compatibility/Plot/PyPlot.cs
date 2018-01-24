using System;
using System.Collections.Generic;

namespace Lang.Python.Plot
{
    [Module("matplotlib.pyplot", true, ClassIsModule = true, ImportModule = "matplotlib")]
    public class PyPlot
    {
        [DirectCall("plot")]
        public static List<Line2D> Plot(List<double> x, List<double> y)
        {
            throw new NotImplementedException();
        }
    }
}