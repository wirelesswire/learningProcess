using System;
using System.Collections.Generic;
using System.IO;

namespace file
{
    class Program
    {
        static void Main(string[] args)
        {

            bool shouldRun = true;
            string basePath = "C:/";
            string rozszezenie = ".txt";
            while (shouldRun)
            {
                Console.WriteLine("komenda:   ");
                string input  = Console.ReadLine();
                string[] x =  input.Split(" ");
                if (x.Length >= 2)
                {

                    switch (x[0])
                    {
                        case "crt":
                            if (x[1] != null && x[1] != "")
                            {

                                if (File.Exists(basePath + x[1] + rozszezenie))
                                {



                                    while (true)
                                    {
                                        Console.WriteLine("nadpisać ? t/n");
                                        string odp = Console.ReadLine();
                                        if (odp == "t")
                                        {
                                            Console.WriteLine("no to nadpisuje");
                                            File.Create(basePath + x[1].ToString()).Close();
                                            break;
                                        }
                                        else if (odp == "n")
                                        {
                                            Console.WriteLine("no to nie nadpisuje");
                                            break;
                                        }
                                        else
                                        {
                                            Console.WriteLine("to nie jest poprawna komenda");
                                        }
                                    }

                                }
                                else
                                {
                                    File.Create(basePath + x[1].ToString() + rozszezenie).Close();

                                }
                            }
                            else
                            {
                                Console.WriteLine("coś poszło źle");
                            }
                            break;
                        case "move":
                            if (x.Length == 3) {
                                if (File.Exists(basePath + x[1] + rozszezenie)) {
                                    File.Move(basePath + x[1] + rozszezenie, basePath + x[2] + rozszezenie);

                                }
                                else
                                {
                                    Console.WriteLine("nie ma takiego pliku do przeniesienia");
                                }
                            }
                            else
                            {
                                Console.WriteLine("zła składnia , nie zadziała");
                            }
                            break;
                        case "cpy":
                            if (x.Length == 2)
                            { 
                                if (File.Exists(basePath + x[1] + rozszezenie))
                                {
                                    
                                    File.Copy(basePath + x[1] + rozszezenie, basePath + x[1] + " kopia" + rozszezenie);
                                }
                               
                            }
                            else
                            {
                                Console.WriteLine("zla skaldnia nie przejdzie");

                            }
                            break;

                        case "max":
                            if (x.Length == 2)
                            {
                                if (File.Exists(basePath + x[1] + rozszezenie))
                                {
                                    
                                    string[] arr  = File.ReadAllLines(basePath + x[1] + rozszezenie);
                                    if (arr.Length != 0)
                                    {
                                        int max =Int32.Parse( arr[0]);
                                        foreach (var i in arr)
                                        {
                                             int z = Int32.Parse(i);
                                            if (z > max)
                                            {
                                                max = z;
                                            }
                                        }
                                        Console.WriteLine("max : " +max);
                                    }
                                    else
                                    {
                                        Console.WriteLine("nie ma długosci");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("nie ma takiego pliku ");
                                }
                            }
                            else
                            {
                                Console.WriteLine("zla skaldnia nie przejdzie");
                            }
                            break;
                        case "min":
                            if (x.Length == 2)
                            {
                                if (File.Exists(basePath + x[1] + rozszezenie))
                                {

                                    string[] arr = File.ReadAllText(basePath + x[1] + rozszezenie).Split(",");
                                    if (arr.Length != 0)
                                    {
                                        int min = Int32.Parse(arr[0]);
                                        foreach (var i in arr)
                                        {
                                            int z = Int32.Parse(i);
                                            if (z < min)
                                            {
                                                min = z;
                                            }
                                        }
                                        Console.WriteLine("min : " + min);
                                    }
                                    else
                                    {
                                        Console.WriteLine("nie ma długosci");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("nie ma takiego pliku ");
                                }
                            }
                            else
                            {
                                Console.WriteLine("zla skaldnia nie przejdzie");
                            }
                            break;
                        case "obiekty":
                            if (x.Length == 3)
                            {
                                int ilosc = Int32.Parse(x[1]);
                                List<Vector2> lista = new List<Vector2>();
                                while(ilosc > 0)
                                {
                                    Console.WriteLine("Podaj x,y");
                                    string[] ar = Console.ReadLine().Split(",");
                                    if (ar.Length == 2)
                                    {
                                        int vx = Int32.Parse(ar[0]);
                                        int vy = Int32.Parse(ar[1]);
                                        lista.Add(new Vector2(vx, vy));

                                        

                                        ilosc--;

                                    }
                                    else
                                    {
                                        Console.WriteLine("zła ilosc argumentow");
                                    }

                                }
                                File.Create(basePath + x[2] + rozszezenie).Close();
                                foreach (Vector2 v in lista)
                                {
                                    File.AppendAllText(basePath + x[2] + rozszezenie, v.serializeSelf());
                                    

                                }
                                Console.WriteLine("wykonano Pomyślnie");


                            }
                            else
                            {
                                Console.WriteLine("zla skaldnia nie przejdzie");
                            }
                            break;
                        case "q":
                            shouldRun = false;
                            break;
                        default:
                            Console.WriteLine("nie wykryto polecenia");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("nie wykryto polecnia");
                }
                


            }
        
        }
    }
}

public class Vector2
{
    int x;
    int y;
    public Vector2(int x ,int y)
    {
        this.x = x;
        this.y = y;
    }
    public string serializeSelf()
    {
        return "Vector2(" + x +","+ y + ")\n";
    }
}