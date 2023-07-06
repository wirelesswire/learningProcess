using System;
using System.Collections.Generic;
using System.IO;

namespace sumanstopnia
{
    class Program
    {
        static void Main(string[] args)
        {
            //sumanstopnia();
            //isSuperprime(67);
            //List<int> superpierwsze = new List<int>();
            //for(int z =  1; z < 10000000; z++)
            //{
            //    if (isSuperprime(z))
            //    {
            //        superpierwsze.Add(z);
            //    }
            //}
            //liczb superpierwszych mniejszych od 10000000 jest246980
            //Console.Write("liczb superpierwszych mniejszych od 20000 jest" + superpierwsze.Count);
            //isSuperPrimeBinary("1101"); // 13
            //string[] b = new string[] { "aabbcc","bbccaa","abcabc" };
            //czysaanagramami(b);
            //minimaxzpliku();
            //for (int i = 1; i < 1000; i++)
            // {
            //    primeNStopnia(1, 5, i,i);
            // }
           // bitowydoosemkowego();
            //decToAnysystemConverter(8, 17);
            //decToAnysystemConverter(8, 17);
            for (int i = 0; i < 1000000000; i++)
            {
                string octal = decToAnysystemConverter(8, i);
                if (isNarcistic(i.ToString()))
                {
                    Console.WriteLine(i +" jest narcystyczne");
                }
                if(i% 1000000 == 0)
                {
                    Console.WriteLine(i);
                }
                if (isNarcistic(octal))
                {
                    Console.WriteLine(i +"(" + octal+")"+ " w osemkowym jest narcystyczne");
                }


                
              if (isNarcistic(i.ToString()) && isNarcistic(octal))
                {
                    Console.WriteLine(octal);
                    //Console.WriteLine(" "+i);
                }
            }
        }
        static  void sumanstopnia()
        {
            
            List<int[]> listanstopnia = new List<int[]>();
            int[] x = new int[] { 1, 2, 3, 4, 5, 1 };
            int stopiengora = 4;
            listanstopnia.Add(x);
            while (true)
            {
                int[] wynik = sumastopnia(x);
                listanstopnia.Add(wynik);
                if (wynik.Length >1)
                {
                    x = wynik;
                }
                else
                {
                    
                    int stopien = -1;
                    foreach (var item in listanstopnia)
                    {

                        stopien++;
                        foreach (var it in item)
                        {
                            Console.Write(it + " ");
                        }
                        if(stopien==stopiengora)
                        {
                            Console.Write("maksymalna wartość   "+ stopiengora +" go stopnia :"    + maxOfArray(item));
                        }
                        Console.Write("\n");
                        
                    }

                    break;
                }
            }
           


        }
        static int maxOfArray(int[] x )
        {
            int max = 0;
            foreach (var item in x)
            {
                if(max == 0)
                {
                    max = item;
                }
                else if(item > max)
                {
                    max = item;
                }
            }
            return max;


        }

        static int[] sumastopnia(int[] arr)
        {
            List<int> lista = new List<int>();

            for (int i = 0; i < arr.Length-1; i++)
            {
                lista.Add(arr[i]+arr[i+1]);
            }
            foreach (var item in lista)
            {
                //Console.Write(item+" ");
            }
            return lista.ToArray();

        }

        static bool isSuperprime(int liczba)
        {
            if(isPrime(liczba) && isPrime(sumaCyfr(liczba.ToString())))
            {
                //Console.WriteLine("jest super pierwsza");
                return true;
            }
            else
            {
                //Console.WriteLine("nie jest super pierwsza");
                return false;
            }

        }
        static int convertToDecimal(string liczba,int podstawa)
        {
            int suma = 0;
            int mnoznik = 1;
            foreach (var item in liczba.ToCharArray())
            {
                suma += Int32.Parse(item.ToString());

                mnoznik *= podstawa;
            }



            return suma;
        }
        static bool isSuperPrimeBinary(string liczba)
        {
            if (isPrime(convertToDecimal( liczba,2)) && isPrime(sumaCyfr(liczba)))
            {
                Console.WriteLine("jest super pierwsza");
                return true;
            }
            else
            {
                Console.WriteLine("nie jest super pierwsza");
                return false;
            }
        }
        static int sumaCyfr(string s)
        {
            int suma = 0;
            foreach (var item in s.ToCharArray())
            {

                suma += Int32.Parse(item.ToString()) ;
            }
            Console.WriteLine(suma);
            return suma;
        }
        static bool isPrime(int liczba )
        {
            for(int i =2; i<=Math.Floor(Math.Sqrt(liczba))+1; i++)
            {
                if(liczba%i ==0)
                {
                    return false;
                }
            }
            return true;


        }
        static bool czysaanagramami(string[] x)
        {
            List<string> z = new List<string>();
            foreach (var item in x)
            {
                char[] d =item.ToCharArray();
                Array.Sort(d);
                string y = "";
                for(int e = 0; e < d.Length; e++)
                {
                    y += d[e];
                }
                z.Add(y ); 
            }

            foreach (var item in z)
            {
               
                    if(item == z[0])
                    {

                    }
                    else
                    {
                        Console.WriteLine(" nie są anagramami");
                        return false;
                    }
                
            }
            Console.WriteLine("są anagramami");
            return true;
          

        }
        static void minimaxzpliku()
        {
            string[] sciezka = File.ReadAllLines("C:/minimax.txt");
            List<string> najdluzsza = new List<string>();
            List<string> najkrotsza = new List<string>();
            int dlugoscmax = 0;
            int dlugoscmin = 1000000;
            foreach (var item in sciezka) 
            {
                int dlugosc = item.Length;
                if (dlugosc > dlugoscmax)
                {
                    dlugoscmax = dlugosc;
                    najdluzsza.Clear();
                    najdluzsza.Add(item);
                }
                if (dlugosc == dlugoscmax)
                {
                    najdluzsza.Add(item);
                }
                if (dlugosc < dlugoscmin)
                {
                    dlugoscmin = dlugosc;
                    najkrotsza.Clear();
                    najkrotsza.Add(item);
                }
                if (dlugosc == dlugoscmin)
                {
                    najkrotsza.Add(item);
                }
                
               
            }
            najdluzsza.Sort();
            najdluzsza.Reverse();
            najkrotsza.Sort();
            Console.WriteLine(najdluzsza[0]);
            Console.WriteLine(najkrotsza[0]);
        }
        static string primeNStopnia(int stopien, int maxstopien , int liczba,int liczbaogolna)
        {
            string r = "";
            //List<int> r = new List<int>() { stopien };
            if (isPrime(liczba))
            {
                if (liczba == 1 || stopien == maxstopien)
                {
                    return r;
                }
                else
                {
                    //r.AddRange( primeNStopnia(stopien + 1, maxstopien, sumaCyfr(liczba.ToString())));
                    r += primeNStopnia(stopien + 1, maxstopien, sumaCyfr(liczba.ToString()),liczbaogolna);
                    Console.WriteLine(liczbaogolna + "jest prime" + stopien + " stopnia\n");
                }
            }
            return r;



        }
        static void bitowydoosemkowego()
        {
            string[] x = File.ReadAllLines("C:/osemkowy.txt");
            foreach (var item in x)
            {
                List<char> z = new List<char>(item.ToCharArray());
                string liczba = "";
                switch (z.Count % 3)
                {
                    case 0:
                        break;
                    case 1:
                        liczba += 1;
                        z.RemoveRange(0, 1);
                        break;
                    case 2:
                        liczba += (2 + Int32.Parse(z[1].ToString())).ToString();
                        z.RemoveRange(0, 2);

                        break;
                    default:
                        break;


                }
                while (z.Count >= 3)
                {
                    liczba += (Int32.Parse(z[0].ToString()) * 4 + Int32.Parse(z[1].ToString()) * 2 + Int32.Parse(z[2].ToString())).ToString();
                    //z.RemoveAt(0);
                    //z.RemoveAt(1);
                    //z.RemoveAt(2);
                    z.RemoveRange(0, 3);
                }
                Console.WriteLine(item + "   " + liczba);

            }
        }
        static string BittoOctalConverter(string liczba)
        {
            List<char> z = new List<char>(liczba.ToCharArray());
            string wynik = "";
            switch (z.Count % 3)
            {
                case 0:
                    break;
                case 1:
                    wynik += 1;
                    z.RemoveRange(0, 1);
                    break;
                case 2:
                    wynik += (2 + Int32.Parse(z[1].ToString())).ToString();
                    z.RemoveRange(0, 2);

                    break;
                default:
                    break;


            }
            while (z.Count >= 3)
            {
                wynik += (Int32.Parse(z[0].ToString()) * 4 + Int32.Parse(z[1].ToString()) * 2 + Int32.Parse(z[2].ToString())).ToString();

                z.RemoveRange(0, 3);
            }
            return wynik;
        }

            static bool isNarcistic(string liczba)
            {
                int suma = 0;
                char[] lczby = liczba.ToCharArray();
                foreach (var item in lczby)
                {
                    suma += (int)Math.Pow(Int32.Parse(item.ToString()), lczby.Length);
                }
                if (suma.ToString() == liczba)
                {
                    //Console.Write("jest narcystyczna");
                    return true;
                }
                return false;
            }
            static string decToAnysystemConverter(int system,int liczba)
            {
                string wynik = "";
                while (true)
                {
                    wynik += liczba % system;
                    liczba = (int)MathF.Floor( liczba/system);
                    if(liczba <= system)
                {
                    wynik += liczba;
                    break;
                }
                }
                var d = wynik.ToCharArray();
                Array.Reverse(d);
               
                string wyn = "";
                foreach (var item in d)
                {
                    wyn += item;
                }
                return wyn;
            }

        
    }    
}
