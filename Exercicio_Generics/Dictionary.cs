using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Sharprompt;
using Newtonsoft.Json;
using BetterConsoleTables;

namespace Exercicio_Generics
{
    public class Dictionary
    {
        public static Dictionary<string, string> dictionary = new Dictionary<string, string>();
        private static string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "data.json");
        public static void Search()
        {
            Load();

            var input = Prompt.Input<string>("Qual palavra/expressão você pretende procurar?");
            int apereancesCount = 0;
            Table table = new Table("Termos", "Significado");

            foreach (var item in dictionary)
            {
                if (item.Key.Contains(input, StringComparison.InvariantCultureIgnoreCase))
                {
                    table.AddRow(item.Key,item.Value);
                    apereancesCount++;
                }              
            }
            if(apereancesCount == 0)
            {
                Console.WriteLine("Nenhum termo encontrado");
            }
            else
            {
                Console.Write(table.ToString());
                Console.ReadKey();
            }

        }

        public static void Include()
        {
            Load();

            bool keyValidation = true;
            bool pairValueValidation = true;
            var key = "";
            var pairValue = "";

            do
            {
                key = Prompt.Input<string>("Qual palavra/expressão você deseja inserir?");

                keyValidation = InputValidation.ValidateInput(key);
            }
            while (!keyValidation);
            do
            {
                pairValue = Prompt.Input<string>("Qual o significado da palavra que você deseja inserir?");

                pairValueValidation = InputValidation.ValidateInput(pairValue);
            }
            while (!pairValueValidation);

            dictionary.Add(key, pairValue);

            Save();

        }

        public static void Save()
        {
            var content = JsonConvert.SerializeObject(dictionary);
            File.WriteAllText(dbPath, content);
        }
        public static void Load()
        {
            if (!File.Exists(dbPath))
                Save();
            var content = File.ReadAllText(dbPath);
            dictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>(content);
        }

        public static void PrintAllDictionary()
        {
            Load();

            Table table = new Table("Termos", "Significado");
            foreach (var item in dictionary)
            {
                table.AddRow(item.Key, item.Value);
            }
            Console.Write(table.ToString());
            Console.ReadKey();
        }
    }
}
