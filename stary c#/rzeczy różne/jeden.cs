using System;
using System.Collections.Generic;
using System.IO;

namespace _04042022
{
    class Program
    {
        static Dictionary<string, int> dict = new Dictionary<string, int>() {
                {"krowa",4 },
                {"pająk",8 },
                {"kura",2 },


            };
        static void Main(string[] args)
        {
            //wypisz(zmiennadec( siec(28)));
            //Console.Write("adressieci");

            //wypisz(zmiennadec(adressieci("192.168.0.1",15)));
            //wypisz(pierwszyadres("192.168.0.1", 10));
            //wypisz(broadcast("192.168.0.1", 10));

            Console.WriteLine(odleglosc(1,1,3,2));
            //Console.WriteLine( "najwieksze pole ma trójkąt o wspołrednych na indexie :"+ trojkaty("trojkaty.txt") );
            Console.WriteLine("najwiecej punktów ma drużyna nr :  " + druzyna("druzyna.txt"));



            string input = "";
            while(true)
            {
                input = Console.ReadLine();
                if(input == "exit")
                {
                    break;
                }
                string[] a = input.Split(" ");
                Console.WriteLine(nogi(a[0],int.Parse(a[1])));


            }


        }

        public static int nogi(string nazwa , int ilosc)
        {

            if (dict.ContainsKey(nazwa))
            {
                

            }
            else
            {
                Console.WriteLine("nie ma takiego zwierzecia podaj nazwe ");
                dict.Add(nazwa,int.Parse(Console.ReadLine()));
                //return 
            }
            return dict[nazwa] * ilosc;

        }
        public static string druzyna(string file )
        {
            string[] arr = File.ReadAllLines(file);
            int  maxpunkty = 0;
            int  iddruzyna = 0 ;
            for (int i = 0; i < arr.Length; i++)
            {
                string[] druz = arr[i].Split(";");
                int pkt = int.Parse( druz[1])*3 + int.Parse(druz[2]);
                if (pkt > maxpunkty)
                {
                    maxpunkty = pkt;
                    iddruzyna = i;
                }


            }
            return arr[iddruzyna].Split(";")[0];
        }
        public static double odleglosc(int  xa ,int ya, int xb , int yb )
        {
            return Math.Sqrt(Math.Pow(xa-xb, 2) + Math.Pow(ya-yb, 2));
        }
        public static int trojkaty(string file)
        {
            //File.WriteAllText(file,"asd");
            string[] arr = File.ReadAllLines(file);
            int idxmax = 0;
            double polemax = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                string[] liczby = arr[i].Split(";");
                double a = odleglosc(int.Parse(liczby[0]),int.Parse(liczby[1]), 
                    int.Parse(liczby[2]), int.Parse(liczby[3]));
                double b = odleglosc(int.Parse(liczby[0]), int.Parse(liczby[1]),
                    int.Parse(liczby[4]), int.Parse(liczby[5]));
                double c = odleglosc(int.Parse(liczby[4]), int.Parse(liczby[5]),
                    int.Parse(liczby[2]), int.Parse(liczby[3]));
                double p = (a + b + c) / 2;
                double pole = Math.Sqrt(p*(p-a)*(p-b)*(p-c));
                if (pole > polemax)
                {
                    polemax = pole;
                    idxmax = i;
                }

            }

            return idxmax+1;

        }
        

        public static string[] broadcast(string ip , int maska)
        {
            wypisz(siec(maska));
            string[] mask = zmiennadec( neguj( siec(maska)));
            string[] ips =zmiennadec( adressieci(ip,maska));
            string[] wynik = new string[ips.Length];
            for (int i = 0; i < ips.Length; i++)
            {
                wynik[i] =( int.Parse(mask[i]) + int.Parse(ips[i]) ).ToString();
            }

            //string[] 
            //wypisz(mask);
            return wynik;
        }
        public static string[] neguj(string[] a )
        {
            for (int i = 0; i < a.Length; i++)
            {
                a[i] = a[i].Replace("0", "2").Replace("1","0").Replace("2","1");
                //wypisz(a);

            }
            return a;

        }
        public static string[] pierwszyadres(string ip, int maska)
        {
            string[] a = zmiennadec( adressieci(ip, maska));
            a[a.Length - 1] = (int.Parse(a[a.Length - 1]) + 1).ToString();
            return  a;
        }
        public static string[] adressieci(string ip , int maska )
        {
            string[] ipki = zmiennabin( ip.Split("."));
            string x = "";
            foreach (var item in ipki)
            {
                string a = item;

                    for (int i = 0; i < 8-item.Length; i++)
                    {
                        a = "0" + a;
                    }



                x += a;
            }
            string gotowy = "";
            for (int i = 0; i < 32; i++)
            {
                if (i < maska)
                {
                    gotowy += x[i];
                   
                }
                else
                {
                    gotowy += "0";
                }
                if ((i + 1) % 8 == 0 && i+1!=32)
                {
                    gotowy += ".";
                }

            }
            return gotowy.Split(".") ;

        }


        public  static void wypisz(string[] a)
        {
            foreach (var item in a)
            {
                Console.Write(item+".");
            }
            Console.Write("\n");
        }
        public static string[] zmiennadec(string[] a )
        {
            List<string> b = new List<string>();
            foreach (var item in a)
            {
                b.Add( Convert.ToInt32(item,2).ToString());
            }
            return b.ToArray();

        }
        public static string[] zmiennabin(string[] a)
        {
            List<string> b = new List<string>();
            foreach (var item in a)
            {
                b.Add(Convert.ToString(int.Parse(item), 2).ToString());
            }
            return b.ToArray();

        }
        public static string[] siec(int maska)
        {
            string a = "";
            int b = 1;
            for (int i = 0; i < maska; i++)
            {
                a += "1";
                if(b == 8 )
                {
                    a += " ";
                    b = 0;
                }
                b++;

            }
            for (int i = 0; i < 32-maska; i++)
            {
                a += "0";
                if (b == 8 && i != 32-maska-1)
                {
                    a += " ";
                    b = 0;
                }
                b++;

            }
            return a.Split(" ");
            //a.Split("",8);



        }



    }
}
