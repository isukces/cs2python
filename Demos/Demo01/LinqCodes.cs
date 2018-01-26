using System.Linq;

namespace Demo01
{
    public class LinqCodes
    {
        public static void Enumerable1()
        {
            var a = Enumerable.Range(2, 10).ToList();
            var b = Enumerable.Range(3, 5).ToArray();
        }        
        
    }
}