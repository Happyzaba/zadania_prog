using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotOfTasks
{
    class NWW
    {
        public static void NWWCals() {
            Console.WriteLine("Podaj dwie liczby:");
            if (double.TryParse(Console.ReadLine(), out double a) && double.TryParse(Console.ReadLine(), out double b))
            {
                double c = a * b;
                double d;
                while (b != 0) {
                    d = a % b;
                    a = b;
                    b = d;
                }
                Console.WriteLine(c/a);
            }
        }
    }
}
