using System;

namespace _11._04._2022_algorytmy
{
    class Program
    {
        static void Main(string[] args)
        {
            wypisz(babelkowe(new int[] { 1, 2, 3, 4, 5, 12, 3, 1, 1,-22 }));
            wypisz(wybor(new int[] { 1, 2, 3, 4, 5, 12, 3, 1, 1, -22 }));
            int[] arr = new int[] { 1, 2, 3, 4, 5, 12, 3, 1, 1, -22 };
            Console.Write("index to :" + binary(wybor( arr),0,arr.Length,3));
            Console.WriteLine("najdluzszy wspolny strign to : "+ longestSString("dababdc","dbabcd"));
            //Console.WriteLine(silniaRek(4));
        }
        static int silniaRek(int ile )
        {
            if(ile == 1)
            {
                return 1;
            }            
            return silniaRek(ile - 1) * ile;
        }
        static string longestSString(string s1, string s2)
        {
            if (s1.Length < s2.Length)
            {
                string tmp = s2;
                s2 = s1;
                s1 = tmp;
            }
            int maxlen = 0;
            int startidxws1 = 0;
            for (int i = 0; i < s1.Length ; i++)
            {
                int ile = 0;
                for (int j = 0; j < s2.Length; j++)
                {
                    if (i + j >= s1.Length)
                    {
                        if (ile > maxlen)
                        {
                            maxlen = ile;
                            startidxws1 = i;
                        }
                        Console.WriteLine("--break--");
                        break;
                    }
                    if(s2[j] == s1[j+i])
                    {
                        ile++;
                        Console.WriteLine();
                        Console.WriteLine("s2"+ s2[j]);
                        Console.WriteLine("s1" + s1[i+j]);

                    }
                    else
                    {
                        if(ile > maxlen)
                        {
                            maxlen = ile;
                            startidxws1 = i;
                           // Console.WriteLine("--break--");
                        }
                        ile = 0;
                    }
                }
            }
            return s1.Substring(startidxws1,maxlen) +"" + maxlen + "" + startidxws1;
        }

        static int binary( int[] arr ,int min ,int max , int szukana)
        {
            
            int mid =  (min + max) / 2;
            if(arr[mid] == szukana)
            {
                return mid;
            }
            else  if (arr[mid] < szukana)
            {
               return binary(arr,min,mid,szukana);
            }
            else 
            {
                return binary(arr, mid+1, max, szukana);

            }
        }


        static void wypisz(int[] a )
        {
            foreach (var item in a)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("\n");
        }
        static int[] babelkowe(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr.Length; j++)
                {
                    if(arr[j] > arr[i])
                    {
                        int tmp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = tmp;
                    }
                }
            }
            return arr;
        }
        static int[] wybor(int[] a )
        {
            for (int i = 0; i < a.Length; i++)
            {
                int min = a[i];
                int minidx = i;
                for (int j = i; j < a.Length; j++)
                {
                    if (a[j] < min)
                    {
                        min = a[j];
                        minidx = j;
                    }
                }
                a[minidx] = a[i];
                a[i] = min;
            }
            return a;
        }

    }
}
