using System.Reflection;

namespace Lang.Python.Tests
{
    public class Info
    {
        public Info()
        {
        }

        public Info(string compare)
        {
            Compare = compare;
        }

        public string Compare { get; set; }
        public Assembly[] Ref { get; set; }
    }
}