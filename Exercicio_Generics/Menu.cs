using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyConsole;

namespace Exercicio_Generics
{
    public class Menu
    {
        public static void CreateMenu()
        {
            var menu = new EasyConsole.Menu()
      .Add("Adicionar", () => Dictionary.Include())
      .Add("Buscar", () => Dictionary.Search())
      .Add("Ver todo o dicionário", () => Dictionary.PrintAllDictionary())
      .Add("Sair", () => Environment.Exit(0));


            menu.Display();
        }
    }
}