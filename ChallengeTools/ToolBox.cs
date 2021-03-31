using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeTools
{
    public class ToolBox
    {
        public void CompanyName()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Clear();
            Console.WriteLine("\n	            	          	▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓ \n" +
                            "		                      	▓                                    ▓ \n" +
                            "		          	        ▓     Komodo Software Solutions      ▓ \n" +
                            "		                      	▓                                    ▓ \n" +
                            "		                      	▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓ \n");
        }

        public void AnyKey()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
            Console.Clear();
        }
        public void CoolColors(String text)
        {
            int count = 1;
            char[] letters = text.ToCharArray();
            foreach (char item in letters)
            {
                if (count <= 2)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(item);
                    count++;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write(item);
                    count++;
                }
            }
            Console.WriteLine("\n");
        }
        public string SetInputColor()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            string input = Console.ReadLine();
            if (input.Length > 0)
            {
                string cleanItem = char.ToUpper(input[0]) + input.Substring(1);
                return cleanItem;
            }

            Console.ForegroundColor = ConsoleColor.Blue;
            return input;
        }
    }
}
