using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio_Generics
{
    public static class InputValidation
    {
        public static bool ValidateInput(string input)
        {

            foreach (char c in input)
            {
                if (c == '*' || c == '?')
                {

                    Console.WriteLine("Esta palavra/expressão não é válida!");                  
                    Console.ReadKey();
                    Console.Clear();
                    return false;
                }
            }
            return true;
        }
    }
}
