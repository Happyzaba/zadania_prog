using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotOfTasks
{
    class NDW
    {
        public static void Euqlides() {
            Console.WriteLine("Podaj dwie liczby:");
            if (int.TryParse(Console.ReadLine(), out int a) && int.TryParse(Console.ReadLine(), out int b)) {
                while (a!=b) {
                    if (a > b) {
                        a = a - b;
                    }
                    else if (a < b){
                        b = b - a;
                    }
                }
                Console.WriteLine(a);
            }
        }
    }
}
