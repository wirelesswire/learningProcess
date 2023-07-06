using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace macierze
{
    class Program
    {
     
    
        static void Main(string[] args)
        {
            
            int[,] ar1 = new int[,] { { 1, 2, 3 }, { 1, 34, 2 }, { 1, 5, 7 } };
            int[,] ar2 = new int[,] { { 4, 4, 6 }, { 3, 55, 3 }, { 123, 32, 12 } };

            Console.WriteLine(matrixAdd(ar1,ar2,"+"));
            Console.WriteLine("\n odejmoawnie \n");
             ar1 = new int[,] { { 1, 2, 3 }, { 1, 34, 2 }, { 1, 5, 7 } };
             ar2 = new int[,] { { 4, 4, 6 }, { 3, 55, 3 }, { 123, 32, 12 } };

            Console.WriteLine(matrixAdd(ar1, ar2, "-"));
            ar1 = new int[,] { { 1, 2, 3 }, { 1, 34, 2 }, { 1, 5, 7 } };
            ar2 = new int[,] { { 4, 4, 6 }, { 3, 55, 3 }, { 123, 32, 12 } };

            Console.WriteLine(matrixAdd(ar1, ar2, "*"));
            Console.ReadLine();
        }
        static string matrixAdd(int[,] arr1, int[,] arr2,string znak)
        {
            string outp = "";
            int[,] outTab = new int[arr1.GetLength(0),arr1.GetLength(1)];
            for (int i = 0; i < arr1.GetLength(0); i++)
            {
                for (int j = 0; j < arr1.GetLength(1); j++)
                {
                    if (znak == "+")
                    {
                        outTab[i, j] = arr1[i, j] + arr2[i,j];
                        outp += outTab[i, j]+ " ";
                    }
                    else if(znak == "-")
                    {
                        outTab[i, j] = arr1[i, j] - arr2[i, j];
                        outp += outTab[i, j]+" ";
                    }
                    else if(znak == "*")
                    {
                       
                    }
                }
                outp += "\n";
            }



            return outp;
        }

    }
   
}
