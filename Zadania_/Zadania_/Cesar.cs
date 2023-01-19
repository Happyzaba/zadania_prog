using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotOfTasks
{
    class CesarCode
    {   
        public static void Cesar()
        {
            string toCode = "jasdhfkHGFJahsdf hajGGGDdksf jhaHGFHGAGkfhj abcdeZZZ";
            string coded = "";
            if (int.TryParse(Console.ReadLine(), out int a))
            {
                a = a % 26;
                foreach (char ch in toCode)
                {

                    if (ch >= 'a' && ch <= 'z')
                    {
                        if ((char)(ch + a) > 'z')
                        {
                            coded += (char)(ch + a - 26);
                        }
                        else if ((char)(ch + a) < 'a')
                        {
                            coded += (char)(ch + a + 26);
                        }
                        else
                        {
                            coded += (char)(ch + a);
                        }
                    }
                    else if (ch >= 'A' && ch <= 'Z')
                    {
                        if ((char)(ch + a) > 'Z')
                        {
                            coded += (char)(ch + a - 26);
                        }
                        else if ((char)(ch + a) < 'A')
                        {
                            coded += (char)(ch + a + 26);
                        }
                        else
                        {
                            coded += (char)(ch + a);
                        }
                    }
                    else
                    {
                        coded += ch;
                    }
                }
                Console.WriteLine(coded);
            }
        }
    }
}
