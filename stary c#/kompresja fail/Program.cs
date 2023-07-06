using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace komprsja
{
    class Program
    {
        public static  Dictionary<string, int> xdict = new Dictionary<string, int>();
        static void Main(string[] args)
        {
            //int i = 0;
            //foreach (byte item in )
            //{
            //    Console.WriteLine(Convert.ToString( item));
            //    i++;
            //}
            //byte[] bajty = tounicode("ąćęłóąśćżźdźąśńęńóńżź€ćąś€€śąśą");

            //Console.WriteLine(bajty.Length);
            ////Console.WriteLine(Convert.ToString(bajty[0,2]))
            //for (int i = 0; i < bajty.Length; i+=2)
            //{



            //    int suma = 0;
            //    //char[] x = .ToCharArray() ;
            //    string str = Convert.ToString(bajty[i], 16);
            //    //dodaj zera wiodące 
            //    while (str.Length < 4)
            //    {
            //        str = "0" + str;
            //    }
            //    Console.WriteLine(str);
            //    //str = str.Reverse();

            //    for (int j = 0; j < str.Length;j++)
            //    {
            //        Console.WriteLine(str[j]);
            //    }
            //    //Console.WriteLine(" ");
            //    int idx = 0;
            //    for (int d = 1; d <=65536; d*=2)
            //    {
            //        //Console.WriteLine(d);
            //        suma += d * Convert.ToInt32(str[str.Length - idx]);
            //        idx++;
            //        Console.WriteLine(suma);
            //    }


            //    Console.WriteLine("suma wyosi " + suma+" "+bajty[i+1]);

            //}




            //return;

            //ZapiszBitowo(Koduj("a28391bbcabc"), args[0]);
            //zapisznormalnie(Dekoduj(OdczytajBitowo( args[0])), args[0] + "dekom");


            //recznie
            //string xbd = "abcdefghijklmnoprstuvxxyzasdaszxcwqdasdasdwdasdjhskgkfdhoprtgkyopttjiewoeywuiwgac";
            //PoliczWystapienia(xbd);
            //Console.WriteLine();
            //Console.WriteLine(Koduj(xbd));
            //Console.WriteLine(Dekoduj(Koduj(xbd)));

            //Console.WriteLine("koduj \n" + Koduj("abcdavbbc"));
            //Console.WriteLine("pomoc " + Dekoduj("001010001000010010000001010001"));
            //Console.WriteLine("koddekod  " + Dekoduj(Koduj("abcdavbbc")));





            string path = "";
            string dane = ""; // tekst do szyfrowania 
            if (File.Exists(args[0] + ".txt"))
            {
                path = args[0];
            }
            else
            {
                string abd = Console.ReadLine();
                if (File.Exists(abd + ".txt"))
                {
                    Console.WriteLine("totalnie nie masz pojęcia jak kożystać z danego ci software-u bożego ");
                    return;
                }
                path = abd;
            }

            Console.WriteLine("oruginalny" + " " + odczytajnormalnie(path));


            dane = odczytajnormalnie(path);
            ZapiszBitowo(Koduj(dane), path + "zipped");
            //Console.WriteLine("pierwsze "+ odczytajnormalnie(path + "zipped"));


            zapisznormalnie(Dekoduj(OdczytajBitowo(path + "zipped")), path + "zippedunzipped");
            //Console.WriteLine("drugie " + odczytajnormalnie(path + "zippedunzipped"));
            foreach (var item in xdict)
            {
                Console.WriteLine(item.Key + " " + item.Value + " oryginalnyn ");
            }




            Console.WriteLine("\n\n");
            Console.WriteLine(odczytajnormalnie(path) == odczytajnormalnie(path + "zippedunzipped") ? "UDAŁO SIE " : "nie udało sie ");
            Console.WriteLine(odczytajnormalnie(path) + " " + odczytajnormalnie(path + "zippedunzipped"));
        }
        public static void zapisznormalnie(string co,string gdzie)
        {
            File.WriteAllText(gdzie+".txt",co);
        }

        public static  string odczytajnormalnie(string zx)
        {
            var a = File.ReadAllText(zx + ".txt");
            

            return a;
        }

        public static byte[]  tounicode(string znak)
        {
            var myarray2 = Encoding.Unicode.GetBytes(znak);
            return myarray2;
        }
        public static string fromunicode(byte[] bajty)
        {
            var mystring = Encoding.Unicode.GetString(bajty);
            return mystring;
        }




        public static byte[] ConvertIntToByteArray(Int16 I16)

        {

            return BitConverter.GetBytes(I16);

        }

        public static byte[] ConvertIntToByteArray(Int64 I64)

        {

            return BitConverter.GetBytes(I64);

        }

        public static byte[] ConvertIntToByteArray(int I)

        {

            return BitConverter.GetBytes(I);

        }

        public static int ConvertByteArrayToInt32(byte[] b)

        {

            return BitConverter.ToInt16(b, 0); // tu mozna zmienić na jakiego inta w wzaleznosci ile bitow 

        }























        /// <summary>
        /// pobiera plain text zwraca dictionry i ustawia go globalnie 
        /// </summary>
        /// <param name="dane"></param>
        /// <returns></returns>
        /// 
        public static Dictionary<string, int> PoliczWystapienia(string dane) 
        {
            Dictionary<string, int> wystapienia = new Dictionary<string, int>();

            foreach (var znak in dane)
            {
                string litera = znak.ToString();
                if (wystapienia.ContainsKey(litera))
                    wystapienia[litera] += 1;
                else
                    wystapienia.Add(litera, 1);
            }

            Dictionary<string,int> sortedDictionary = new Dictionary<string, int>(from entry in wystapienia orderby entry.Value descending select entry);

            foreach (var item in sortedDictionary)
            {
                Console.WriteLine(item.Key +"  " + item.Value + " z funkcji policz ");
            }


            return xdict = sortedDictionary;
        }
        /// <summary>
        /// zwraca string 0  i jedynek bez zer koncowych 
        /// </summary>
        /// <param name="nieskompresowane"></param>
        /// <returns></returns>       
        public static string Koduj(string nieskompresowane) 
        {
            PoliczWystapienia(nieskompresowane);
            string result = "";
            foreach (var znak in nieskompresowane)
            {
                string litera = znak.ToString();
                result += "0" ;
                int idx = 0;

                foreach (var kv in xdict)
                {
                    if (idx == xdict.Count - 1) 
                    {
                        break;
                    }
                    if (kv.Key != litera)
                        result += "0";
                    else 
                    {
                        
                        result += "1";
                        break;
                    }
                    idx++;
                }
            }
            return result;
        }

        /// <summary>
        /// bierze string w formacie bez zer 
        /// zwraca zrekonstuowany string 
        /// </summary>
        /// <param name="skompresowane"></param>
        /// <returns></returns>
        public static string Dekoduj( string skompresowane) 
        {
            string result = "";
            int dlugosc = 0;
            List<string> a = new List<string>(xdict.Keys);

            foreach (var znak in skompresowane)
            {
                string kod = znak.ToString();
             
                
                if (kod == "0")
                {
                    if (dlugosc == xdict.Count - 1)
                    {
                        dlugosc = 0;
                        result += a[xdict.Count - 1];
                        continue;
                    }


                    dlugosc++;
                }
                else 
                {
                    result += a[dlugosc-1 ];
                    dlugosc = 0;
                }

            }
            Console.Write(skompresowane + " \n");
            Console.WriteLine(result);
            return result;
        }
        /// <summary>
        /// pobiera już zakodowany string i zapisuje do stringa 
        /// </summary>
        /// <param name="dane"></param>
        /// <param name="nazwa"></param>
        public static void ZapiszBitowo(string dane,string nazwa ) 
        {
            //dopisuje zera na końcu żeby ilość znaków była wielokrotnością 8
            var x = Dekoduj(dane);

            var a = PoliczWystapienia(x);
            int iloscZer = 0;
            while (dane.Length % 8 != 0) 
            {
                iloscZer++;
                dane += "0";
            }
            //dzieli na paczki po 8 znaków
            List<string> paczki = new List<string>();
            while (dane.Length != 0) 
            {
                paczki.Add(dane.Substring(0, 8));
                dane = dane.Substring(8);
            }
            //konwertuje paczki na bajty 
            List<byte> bajty = new List<byte>();
            for (int i = 0; i< paczki.Count; i++) 
            {
                byte bit = Convert.ToByte(Convert.ToInt32(paczki[i],2).ToString());
                bajty.Add(bit);
            }


            //dodaje na koniec bajt mowiacy o tym ile jest dodatkowych zer 
            bajty.Add(Convert.ToByte(iloscZer.ToString()));
            //zapisuje do pliku 
            //dodaje drzewo wp ostaci bajtow

            foreach (var item in a  )
            {
                char abc = item.Key.ToCharArray()[0];
                int cde = (byte)abc;

                //bajty.Add(Convert.ToByte((Convert.ToInt32 (((byte)(item.Key.ToCharArray()[0])).ToString(),2)).ToString())); // zamienia cały dictionary na bajty i dodaje w kolejnośc litera - ilosc // to jest jakaśkurwa herezja 
                //bajty.Add(Convert.ToByte(Convert.ToInt32(((byte)item.Key.ToCharArray()[0]).ToString(), 2).ToString()));

                //bajty.AddRange(Encoding.Unicode.GetBytes(cde.ToString()));

                //bajty.Add(Convert.ToByte(cde));
                bajty.AddRange(tounicode(item.Key));
                //bajty.Add(Convert.ToByte( item.Value));
                bajty.AddRange(ConvertIntToByteArray(Convert.ToInt16( item.Value)));//tu na razie bedą tylko 2 bajty na jedną liczbe 
            }

            //ile dodał bajtow na drzewo // ile przejsc petli trzeba zrobić//później trzeba pamietać o tym żeby każdy z nich wyjąc przy otwieraniu pliku
            bajty.Add(Convert.ToByte(a.Count));


            File.WriteAllBytes(nazwa + ".txt", bajty.ToArray());
        }


        /// <summary>
        /// rekonstruuje dictionary i zwraca 
        /// </summary>
        /// <param name="nazwa"></param>
        /// <returns></returns>
        public static string OdczytajBitowo(string nazwa) 
        {
            //Console.WriteLine("\n\n\n\n\n\n");
            string result = "";
            List<byte> bajty = new List<byte>(File.ReadAllBytes(nazwa + ".txt"));

            //bajty na drzewo 
            int ost = Convert.ToInt32(bajty[bajty.Count - 1]); // wez ostatni i go usun i przekonwertuj na inta 
            bajty.RemoveAt(bajty.Count - 1);
            Dictionary<string, int> tmpdict = new Dictionary<string, int>();
            //rekonstruuj dict z pliku 
            for(int i = 0; i< ost; i++)
            {
                int tmpilosc = Convert.ToInt32(bajty[bajty.Count - 1]); // wez ostatni i go usun i przekonwertuj na inta 
                List<byte> liczby = new List<byte>();
                liczby.Insert(0, bajty[bajty.Count - 1]);
                bajty.RemoveAt(bajty.Count - 1);
                liczby.Insert(0, bajty[bajty.Count - 1]);
                bajty.RemoveAt(bajty.Count - 1);









                //bajty.RemoveAt(bajty.Count - 1);
                List<byte> litery = new List<byte>();
                litery.Insert(0, bajty[bajty.Count - 1]);
                bajty.RemoveAt(bajty.Count - 1);
                litery.Insert(0, bajty[bajty.Count - 1]);
                bajty.RemoveAt(bajty.Count - 1);
                //tmpdict.Add(fromunicode(x.Reverse()), tmpilosc);

                //string  tmplitera1 = Convert.ToString((char)bajty[bajty.Count - 1]); // wez ostatni i go usun i przekonwertuj na inta 
                //bajty.RemoveAt(bajty.Count -1);
                //string tmplitera2 = Convert.ToString((char)bajty[bajty.Count - 1]); // wez ostatni i go usun i przekonwertuj na inta 
                //bajty.RemoveAt(bajty.Count - 1);
                tmpdict.Add(fromunicode(litery.ToArray()),(int) ConvertByteArrayToInt32(liczby.ToArray()));// głupia konversja na inta 

            }
            xdict = new Dictionary<string, int>( tmpdict.Reverse());

            //wywala ostatniego i wywala fałszywe zera 
            int ostatni = Convert.ToInt32(bajty[bajty.Count - 1]);
            bajty.RemoveAt(bajty.Count - 1);
            foreach (var bajt in bajty)
            {
                //konwertuje do binarnego 
                string tmp = Convert.ToString(bajt,2);
                // dopełnia zer do 8 
                while (tmp.Length < 8)
                {
                    tmp = "0" + tmp;
                }

                result += tmp;
            }
            //zwraca string bez fałszywych zer 
            result = result.Substring(0, result.Length - ostatni);
            Console.WriteLine("resultat \n" + Dekoduj( result));
            return result;
        }
        


    }
}
