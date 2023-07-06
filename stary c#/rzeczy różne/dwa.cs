using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _28032022
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            //Console.WriteLine(czynawiasysazagniezdzone("test nawiasów(()()()"));
            //Console.WriteLine(jestPalindromem("11"));
            //Console.WriteLine(jestPalindromem("121"));
            //Console.WriteLine(jestPalindromem("111"));
            //Console.WriteLine(jestPalindromem("11001"));
            //palindormy(5, 11);
            //Console.WriteLine(QueensAttack("D3","B1"));
            Console.WriteLine(isgoodhexval("#fffa"));
            Console.WriteLine(kebabtocamel("abcd-e-f-abcdef"));
            Console.WriteLine(mirrorlettersinstrings("abc to jest tekst przykładowy "));
            //typtrojkat(3, 3, 6);
            Console.WriteLine(typtrojkat(3,4,5));
            Console.WriteLine(scrabbleValue("adb"));
        }
        public static int scrabbleValue(string slowo)
        {
            slowo = slowo.ToUpper();
            Dictionary<string, int> abc = new Dictionary<string, int>()
            {
                {"AEIOULNRST",1 },
                {"DG",2},
                {"BCMP",3 },
                {"FHVWY",4 },
                {"K",5 },
                {"JX",8 },
                {"QZ",10 },
            };
            int wynik = 0;
            for (int i = 0; i < slowo.Length; i++)
            {
                bool adds = true;
                foreach ( KeyValuePair<string,int> kvp in abc)
                {
                    if (kvp.Key.IndexOf(slowo[i].ToString()) != -1 && adds )
                    {
                        wynik += kvp.Value;
                        adds = false;
                    }

                }
            }
            return wynik;
        }

        static string typtrojkat(int a, int b, int c)
        {
            int[] x = { a, b, c };
            x= x.OrderBy(x => -x).ToArray<int>();
            foreach (var item in x)
            {
                Console.WriteLine(item);
            }
            double cos = ( (x[0] * x[0]) - (x[1] * x[1]) - (x[2] * x[2]) );
            Console.WriteLine(cos);
            if (cos == 0)
            {


                return "prostokątny";

            }
            else if (cos<0)
            {
                return "ostrokątny";

            }
            else if (cos > 0)
            {
                return "rozwartokątny";

            }

            return cos.ToString();
        }

        static string mirrorlettersinstrings(string text)
        {
            string ou = "";
            foreach (var item in text.Split(" "))
            {
                ou += reverse(item) + " ";
            }
            return ou;
        }
        static string reverse(string text)
        {
            string ou = "";
            for (int i = text.Length - 1; i >= 0; i--)
            {
                ou += text[i];
            }
            return ou;
        }
        static string kebabtocamel(string kebab)
        {
            string output = "";
            for (int i = 0; i < kebab.Length; i++)
            {
                if (kebab[i].ToString() == "-")
                {
                    output += kebab[i + 1].ToString().ToUpper();
                    i++;
                    continue;
                }
                output += kebab[i];
            }
            return output;
        }
        static bool isgoodhexval(string hexcolor)
        {
            Regex a = new Regex("[0-9a-f]|#");
            if (hexcolor.Length != 7 && hexcolor.Length != 4)
            {
                return false;
            }

            if (a.Matches(hexcolor).Count == hexcolor.Length)
            {
                return true;
            }

            return false;
        }

        public static bool QueensAttack(string standing, string attacking)
        {
            if (standing.Length != 2 || attacking.Length != 2)
            {
                Console.WriteLine("zły format");
                return false;
            }
            if (standing == attacking)
            {
                Console.WriteLine("nie może zaatakować pola na którym stoi ");
                return false;
            }
            if (standing[0] == attacking[0])
            {
                return true;
            }
            if (standing[1] == attacking[1])
            {
                return true;
            }
            Dictionary<string, int> x = new Dictionary<string, int>() {
                {"A",1 },
                {"B",2 },
                {"C",3 },
                {"D",4 },
                {"E",5 },
                {"F",6 },
                {"G",7 },
                {"H",8 }
            };
            int standinglet = x[standing[0].ToString()];
            int attackinglet = x[attacking[0].ToString()];
            int roznicalet = standinglet - attackinglet;
            int roznicacyfr = int.Parse(standing[1].ToString()) - int.Parse(attacking[1].ToString());
            if (Math.Abs(roznicalet) == Math.Abs(roznicacyfr))
            {
                return true;
            }
            return false;
        }
        public static bool czynawiasysazagniezdzone(string tekst)
        {
            Stack<string> stack = new Stack<string>();
            for (int i = 0; i < tekst.Length; i++)
            {
                if (tekst[i].ToString() == "(")
                {
                    stack.Push("(");
                }
                if (tekst[i].ToString() == ")")
                {
                    if (stack.Count != 0)
                    {
                        stack.Pop();
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            if (stack.Count == 0)
            {
                return true;
            }
            return false;
        }
        public static bool jestPalindromem(string tekst)
        {
            for (int i = 0; i < tekst.Length / 2 + 1; i++)
            {
                if (tekst[i] != tekst[tekst.Length - 1 - i])
                {
                    return false;
                }
            }
            return true;
        }
        public static void palindormy(int min, int max)
        {
            List<string> stringi = new List<string>();
            for (int i = min; i <= max; i++)
            {
                for (int j = min; j <= max; j++)
                {
                    int iloczyn = i * j;
                    if (jestPalindromem(iloczyn.ToString()))
                    {
                        stringi.Add(iloczyn.ToString());
                    }
                }
            }
            foreach (var item in stringi)
            {
                Console.WriteLine(item);
            }

        }
    }
}
