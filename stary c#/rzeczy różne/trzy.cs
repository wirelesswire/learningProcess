using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadania
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(konwersja(2102301123,20));
            Console.WriteLine(konwersja(123123, 16));
            
            Console.WriteLine(najdluzszypodciag("abcdddqw1rty","bcd1ddqwert"));
            Console.WriteLine(cezar("abcdef",28));
            Console.WriteLine(Convert.ToString(123123, 16));
            //int  a = null;
            wiekwkosmosie("merkury");
            Console.ReadLine();

        }
        static public double wiekwkosmosie(string planeta)
        {
            Dictionary<string, double> dict = new Dictionary<string, double>() {
                {"mercury",0.2408467},
                {"venus",0.61519726},
                {"Mars",1.8808158},
                {"Jupiter",11.862615},
                {"Saturn",29.447498 },
                {"Uranus",84.016846 },
                {"Neptune",164.79132 },

            };
            TimeSpan a  =  DateTime.Now - DateTime.Parse("18-08-2002");
            Console.WriteLine(a.TotalSeconds);
            double lataziemskie = a.TotalSeconds / (3600 * 24 * 365);
            Console.WriteLine(lataziemskie/dict[planeta.ToLower()]);
            return a.TotalSeconds;
        }
        static public string konwersja(int dziesiętna ,int nasystem)
        {
            string a = "0123456789abcdefghijklmnop";
            string ret = "";
            while (dziesiętna > 0)
            {
                int mod = dziesiętna % nasystem;
                dziesiętna = (dziesiętna-mod)/ nasystem;
                ret += a[mod];
                //Console.WriteLine(mod);
            }
            string x = "";
            for (int i = 0; i < ret.Length; i++)
            {
                x +=  ret[ret.Length - i-1];
            }
            return x;

        }
        public static string  najdluzszypodciag(string a, string b)
        {
            int najdluzszyidxstart = 0;
            int najdluzszydlugosc = 0; 
            for (int i = 0; i < a.Length; i++)
            {
                for (int j = i+1; j <a.Length; j++)
                {
                    if (b.IndexOf(a.Substring(i,j-i)) != -1)
                    {
                        if (j - i > najdluzszydlugosc)
                        {
                            najdluzszyidxstart = i;
                            najdluzszydlugosc = j-i;
                        }
                        
                    }
                }
            }
            string wyn = "";
            for (int i = 0; i < najdluzszydlugosc; i++)
            {
                wyn += a[najdluzszyidxstart + i];
            }
            return wyn;
        }
        public static  string cezar(string doszyfracji,int oile)
        {
            string alph = "abcdefghijklmnopqrstuvwxyz";

            string szyforwany = "";
            for (int i = 0; i < doszyfracji.Length; i++)
            {
                szyforwany+=alph[(alph.IndexOf( doszyfracji[i]) +oile) % alph.Length];
            }
            return szyforwany;


        }
    }




}
