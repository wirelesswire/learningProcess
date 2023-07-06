using System;

namespace sortowania
{
    class Program
    {
        static void Main(string[] args)
        {

            //int[] arr = new int[] {1,23,5,1,12,2,231,123,44 };
            //foreach (var item in przezWybor(arr))
            //{
            //    Console.Write(item+" ");
            //}

            //Console.Write("\n");
            //foreach (var item in bombelki(arr))
            //{
            //    Console.Write(item + " ");
            // }
            int[] arr = new int[] { 1, 23, 5, 1, 12, 2, 231, 123, 44 };
            foreach (var item in quickSort(arr,0,arr.Length-1))
            {
                Console.Write(item + " ");
            }

        }


        static int[] przezWybor(int[] x )
        {       
            for (int i = 0; i < x.Length; i++)
            {
                int min = x[i];
                int minidx = i;
                for (int j = i; j < x.Length; j++)
                {
                    if (x[j] < min)
                    {
                        min = x[j];
                        minidx = j;
                    }
                }
                int tmp = x[i];
                x[i] = x[minidx];
                x[minidx] = tmp;
            }

            return x;
        }

        static int[] bombelki(int[] x )
        {
            for (int i = 0; i < x.Length; i++)
            {
                for (int j = 0; j < x.Length-i-1; j++)
                {
                    if (x[j] > x[j + 1])
                    {
                        int tmp = x[j];
                        x[j] = x[j+1];
                        x[j+1] = tmp;
                        
                    }

                }
            }
            return x;


        }

        static int[] quickSort(int[] tab,int lewy,int prawy)
        {

            int piwotidx = prawy + lewy / 2;
            int piwot = tab[ piwotidx];
            int i = lewy;
            int k = lewy;
            int tmp = tab[prawy];
            tab[prawy] =piwot ;
            tab[piwotidx] = tmp;
            for (; i < prawy; i++)
            {
                if (tab[i] < tab[prawy])
                {
                    int tmp2 = tab[i];
                    tab[i] = tab[k];
                    tab[k] = tmp2;
                    k++;
                }
            }
            foreach (var item in tab)
            {
                Console.Write(item  +" ");
            }
            Console.Write("\n");
            int tmp3 = tab[piwotidx];
            tab[piwotidx] = tab[prawy];
            tab[prawy] = tmp3;
            if (piwot - lewy > 1)
            {
                quickSort(tab,lewy,piwotidx -1);
            }
            if(prawy - piwot > 1)
            {
                quickSort(tab, piwotidx +1, prawy);
            }


            return tab;
        }


    }
}
