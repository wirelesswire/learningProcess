using System;

namespace argumenty
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            switch (args[0])
            {
                case "prostokat":
                    int arg1;
                    int arg2;

                    if (Int32.TryParse(args[1], out arg1) && Int32.TryParse(args[2], out arg2)){
                        if (arg1 >= 0 && arg2 >= 0)
                        {
                            Console.WriteLine("pole prostokątu to" + arg1 * arg2);
                        }
                        else
                        {
                            Console.WriteLine("jakiś błąd");
                        }
                    }
                    else
                    {
                        Console.WriteLine("jakąś literę podałeś");
                    }
                    break;
                case "kolo":
                 

                    if (Int32.TryParse(args[1], out arg1) )
                    {
                        if (arg1 >= 0)
                        {
                            Console.WriteLine("pole koła  to około" + Math.Pow(arg1,2)*3.14);
                        }
                        else
                        {
                            Console.WriteLine("jakiś błąd chyba ujemne ");
                        }
                    }
                    else
                    {
                        Console.WriteLine("jakąś literę podałeś");
                    }
                    break;
                case "minmax":


                default:
                    Console.WriteLine("jakiś błąd");
                    break;
            }



        }
    }
}
