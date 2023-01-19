using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotOfTasks
{
    class Pesel
    {
        public static void GetInfoFromPesel() {
            Console.WriteLine("Podaj pesel:");
            string pesel = Console.ReadLine();
            GetDay(pesel);
            GetYear(pesel, out string rok);
            GetMonth(pesel, rok);
            GetGender(pesel);
        }

        private static void GetGender(string pesel)
        {
            if (pesel[pesel.Length - 2] % 2 == 0)
            {
                Console.WriteLine(" płeć: Kobieta");
            }
            else {
                Console.WriteLine(" płeć: Mężczyzna");
            }
        }

        private static void GetDay(string pesel)
        {
            Console.Write("Urodził*ś się w dniu: "+pesel[4]+pesel[5]);
        }

        private static void GetMonth(string pesel, string rok)
        {
            string month = pesel[2].ToString()+pesel[3].ToString();
            Dictionary<int, string> months = new Dictionary<int, string> {
                {1,"Styczeń" },
                {2,"Luty" },
                {3,"Marzec" },
                {4,"Kwiecień" },
                {5,"Maj" },
                {6,"Czerwiec" },
                {7,"Lipiec" },
                {8,"Sierpień" },
                {9,"Wrzesień" },
                {10,"Październik" },
                {11,"Listopad" },
                {12,"Grudzień" },
            };
            if (rok == "0")
            {
                Console.Write(" w miesiącu:"+ months[int.Parse(month)]);
            }
            else if (rok == "2")
            {
                Console.Write(" w miesiącu:" + months[int.Parse(month)-(int.Parse(rok)*10)]);
            }
        }

        private static void GetYear(string pesel,out string rok)
        {
            if (pesel[2] == '0')
            {
                Console.Write(" w roku: 19" + pesel[0] + pesel[1]);
                rok = "0";
            }
            else if (pesel[2] == '2')
            {
                Console.Write(" w roku: 20" + pesel[0] + pesel[1]);
                rok = "2";
            }
            else 
            {
                rok = "";
                Console.WriteLine(" Nie żyjesz");
            }
        }
    }
}
