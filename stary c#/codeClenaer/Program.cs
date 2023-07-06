using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace codeClenaer
{
    class Program
    {
        static void Main(string[] args)
        {
            ZapiszDoPliku(args[0] + "_zmienione", new List<string>(File.ReadAllLines(args[0]+".cs")));
        }

        static void ZapiszDoPliku(string path,List<string> content) 
        {
            content = Formatuj(content);
            File.WriteAllLines(path+".cs", content);
        }

        static List<string> Formatuj(List<string> lines) 
        {
            List<string> nowe = new List<string>();
            for (int i = lines.Count-1; i > -1; i--) 
            {
                if (CzyZawieraKomentarz(lines[i])==rodzajkomentarza.liniowy) 
                {
                    lines[i] = UsunKomentarz(lines[i], CzyZawieraKomentarz(lines[i]));
                }

                if (CzyZawieraKomentarz(lines[i]) == rodzajkomentarza.wieloliniowy_koniec) 
                {
                    int j = i;
                    lines[i] = UsunKomentarz(lines[i],rodzajkomentarza.wieloliniowy_koniec);
                    nowe.Add(lines[i]);
                    while (CzyZawieraKomentarz(lines[j])!=rodzajkomentarza.wieloliniowy_poczatek) 
                    {
                        j--;
                    }
                    i = j;
                    lines[i] = UsunKomentarz(lines[i], rodzajkomentarza.wieloliniowy_poczatek);
                    Console.WriteLine("zapisz: " + lines[i]);
                }
                if (CzyPusta(lines[i]))
                    continue;
                nowe.Add(lines[i]);
            }
            nowe.Reverse();
            nowe = UstawWciecia(nowe);

            return nowe;
        }
        static List<string> UstawWciecia(List<string> linie) 
        {
            int wciecia = 0;
            
            for (int i =0; i<linie.Count;i++) 
            {
                string linia = linie[i];
                linia = linia.Trim();
                if (linia.IndexOf("}") != -1)
                {

                    wciecia--;
                }
                for (int j = 0; j < wciecia; j++)
                {
                    linia = "    " + linia;
                }
                if (linia.IndexOf("{") != -1)
                {
                    if(linia.Trim().Length != 1)
                    {
                        linia = linia.Replace("{", "");
                        linie.Insert(i+1,"{");
                        wciecia--;
                        Console.WriteLine("dodaje");
                    }
                    
                    wciecia++;
                }
               
                linie[i] = linia;
            }
            return linie;
        }

        static rodzajkomentarza CzyZawieraKomentarz(string linia)
        {
            Regex liniowy = new Regex("//");
            if (liniowy.IsMatch(linia))
            {
                return rodzajkomentarza.liniowy;
            }

            Regex wieloliniowy_poczatek = new Regex("/\\*");
            if (wieloliniowy_poczatek.IsMatch(linia)) 
            {
                return rodzajkomentarza.wieloliniowy_poczatek;
            }

            string pattern = "\\*/";
            Regex wieloliniowy_koniec = new Regex(pattern);
            if (wieloliniowy_koniec.IsMatch(linia))
            {
                Console.WriteLine("catcha");
                return rodzajkomentarza.wieloliniowy_koniec;
            }

            return rodzajkomentarza.brak;
        }

        static string UsunKomentarz(string linia,rodzajkomentarza rodzaj)
        {
            if (rodzaj == rodzajkomentarza.liniowy) 
            {
                linia = linia.Substring(0, linia.IndexOf("//"));
            }
            if (rodzaj == rodzajkomentarza.wieloliniowy_koniec) 
            {
                linia = linia.Substring(linia.IndexOf("*/")+2);
            }
            if (rodzaj == rodzajkomentarza.wieloliniowy_poczatek) 
            {
                linia = linia.Substring(0, linia.IndexOf("/*"));
            }

            return linia;
        }

        static bool CzyPusta(string linia) 
        {
            linia = linia.Trim();
            if (linia.Length == 0)
                return true;
            else
                return false;
        }
    }

    enum rodzajkomentarza 
    {
    brak = 0,
    liniowy = 1,
    wieloliniowy_poczatek = 2,
    wieloliniowy_koniec = 3,
    }
}
