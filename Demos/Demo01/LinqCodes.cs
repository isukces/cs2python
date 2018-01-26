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
        
        public static void Enumerable2()
        {
            var a = Enumerable.Range(start: 2, count: 10).ToList();
            var b = Enumerable.Range(count: 10, start: 2).ToList();
        }        
        
    }
}