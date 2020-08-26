using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace C20_Ex02
{
    class Program
    {
        public static void Main()
        {

            string[,] arr = new string[8, 8];

            int rowLength = arr.GetLength(0);
            int colLength = arr.GetLength(1);
            string letter = "O";

            for (int i = 0; i < (rowLength/2) -1; i++)
            {
                Console.WriteLine("=======================================");
                for (int j = 0; j < colLength; j++)
                {
                    Console.Write(string.Format("|"));
                    if ((i % 2) == 0)
                    {
                        if ((j % 2) != 0)
                        {
                            //Console.Write(string.Format("|"));
                            Console.Write(string.Format("  {0}  ", letter));
                        }
                        else
                        {
                            //Console.Write(string.Format("|"));
                            Console.Write(string.Format("    "));
                        }

                    }
                    else
                    {
                          if ((j % 2) == 0)
                        {
                            //Console.Write(string.Format("|"));
                            Console.Write(string.Format("  {0}  ", letter));
                        }
                        else
                        {
                            //Console.Write(string.Format("|"));
                            Console.Write(string.Format("    "));
                        }
                    }
                    Console.Write(string.Format("|"));
                }

                Console.Write(Environment.NewLine); 
            }
            Console.WriteLine("=======================================");

     

        }
    }
}
