using Lang.Python.Tensorflow;
using Xunit;

namespace Lang.Python.Tests.MatplotLibModule
{
    public class PyPlotTests : TestingBase
    {
 

        [Fact]
        public void T01_Should_convert_plot()
        {
            const string cs = @"
       public static void ConvertPyPlot()
        {
            var x = Np.ARange(0, 5, 0.1);
            var y = Np.Sin(x);
            PyPlot.Plot(x, y);
        }
        ";

            const string expected = @"

import numpy
import matplotlib
class Demo:
    @staticmethod
    def ConvertPyPlot(cls):
        x = numpy.arange(0, 5, 0.1)
        y = numpy.sin(x)
        matplotlib.pyplot.plot(x, y)
    

";
            CheckTranslation(WrapClass(cs, "Lang.Python.Numpy", "System", "Lang.Python", "Lang.Python.Plot"), new Info
            {
                Compare = expected,
                Ref     = new[] {typeof(Graph).Assembly}
            });
        }
    }
}