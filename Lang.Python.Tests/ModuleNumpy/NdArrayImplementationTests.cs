using Xunit;
using Lang.Python.Numpy;
    
namespace Lang.Python.Tests.ModuleNumpy
{
    public class NdArrayImplementationTests
    {
        [ Fact]
        public void T01() {
            var a = Np.Array1(new [] {2, 4, 6});
            Assert.Equal(4.0, a.Mean());
        } 
    }
}