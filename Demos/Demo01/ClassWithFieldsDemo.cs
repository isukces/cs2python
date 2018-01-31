using System;
using Lang.Python;

namespace Demo01
{
    [IgnoreNamespaceAttribute]
    public class ClassWithFieldsDemo
    {
        [PyName("earth_gravity")] 
        public static double EarthGravity = 9.81;

        public static double AnotherStatic = 12.44;

        public const double Sum = RoundedPi2 + RoundedPi4;
        
        [PyName("rounded_pi_2")] 
        public const double RoundedPi2 = 3.14;

        public const double RoundedPi4 = 3.1415;

        public static void PrintAll()
        {
            Console.WriteLine(EarthGravity);
            Console.WriteLine(AnotherStatic);
            Console.WriteLine(RoundedPi2);
            Console.WriteLine(RoundedPi4);
            Console.WriteLine(Sum);
        }
    }
}