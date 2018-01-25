using Lang.Python;

namespace Demo01
{
    [PyModule("demo", false)]
    [ExportAsPyModule]
    public static class ClassAsModuleDemo
    {
        [PyName("sum")]
        public static int Sum(int a, int b)
        {
            return a + b;
        } 
    }
}