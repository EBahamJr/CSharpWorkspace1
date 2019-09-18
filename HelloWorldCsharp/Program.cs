using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorldCsharp
{
    class Program
    {
        static void Main(String[] args)
        {
            TacoOB taco = new TacoOB();
            
            Console.WriteLine("Choose a number between 1 and 100: ");
            Class1 test = new Class1(5, 12);
            try
            {
                string userInput = Console.ReadLine();
                int boxSize = Convert.ToInt32(userInput);
                
                if (boxSize > 100 || boxSize < 1)
                {
                    throw new Exception("Out of bounds");
                }
                for (int i = 0; i < boxSize; i++)
                {
                    for (int j = 0; j < boxSize - i; j++)
                    {
                        Console.Write("*");
                    }
                    for (int j = 0;  j < i; j++)
                    {
                        Console.Write(" ");
                    }
                    for (int j = 0; j < boxSize - i; j++)
                    {
                        Console.Write("/");
                    }
                    for (int j = 0; j < i; j++)
                    {
                        Console.Write("\\");
                    }
                    for (int j = 0; j < i; j++)
                    {
                        Console.Write(" ");
                    }
                    for (int j = 0; j < boxSize - i; j++)
                    {
                        Console.Write("*");
                    }
                    Console.WriteLine("");
                }
                Console.WriteLine("{0}", test);
                Console.ReadLine();

            }
            catch(Exception ex)
            {
                Console.ReadLine();
            }
        }
    }
}
