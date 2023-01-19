using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotOfTasks
{
    class AS
    {
        public static void LiczGloski() {
            int sa = 0;
            int sp = 0;
            string samogloski = "aeiou";
            string spolgloski = "bcdfghjklmnpqrstvwxyz";
            string zdanie = Console.ReadLine();
            foreach (char ch in zdanie)
            {
                if (samogloski.Contains(ch))
                {
                    sa += 1;
                }
                else if (spolgloski.Contains(ch)) {
                    sp += 1;
                }
            }
            Console.WriteLine("samogłoski: " + sa + " spółgłoski: " + sp);
        }
    }
}
