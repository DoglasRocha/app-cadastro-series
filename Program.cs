using System;
using System.Data.SqlClient;

namespace Series
{
    class Program
    {
        static SeriesRepository repository = new SeriesRepository();
        static DatabaseMessenger databaseMessenger = new DatabaseMessenger();
        
        static void Main()
        {
            string userOption = GetUserOption();

            while (userOption != "X")
            {
                switch (userOption)
                {
                    case "1":
                        ListSeries();
                        break;
                    case "2":
                        InsertSerie();
                        break;
                    case "3":
                        UpdateSerie();
                        break;
                    case "4":
                        RemoveSerie();
                        break;
                    case "5":
                        ShowSerie();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    
                    default:
                        Console.WriteLine("Digite uma opção válida. ");
                        break;
                }

                userOption = GetUserOption();
            } 
        }

        private static void ShowSerie()
        {
            Console.Write("Digite o id da série: ");
            int serieIndex = int.Parse(Console.ReadLine());

            ProgramMessenger.GetSerieInformation(serieIndex);
        }

        private static void RemoveSerie()
        {
            Console.Write("Digite o id da série: ");
            int serieIndex = int.Parse(Console.ReadLine());

            ProgramMessenger.DeleteSerie(serieIndex);
        }

        private static void UpdateSerie()
        {
            Console.Write("Digite o id da série: ");
            int serieId = int.Parse(Console.ReadLine());

            string[] serieData = GetSerieData();

            ProgramMessenger.UpdateSerie(serieId, serieData);
        }

        private static void InsertSerie()
        {
            Console.WriteLine("Inserir nova série");

            string[] serieData = GetSerieData();

            ProgramMessenger.InsertSerie(serieData);
        }

        private static void ListSeries()
        {
            Console.WriteLine("Listar Séries");

            string seriesList = ProgramMessenger.GetSeriesList();

            Console.WriteLine(seriesList);
        }

        private static string GetUserOption()
        {
            Console.WriteLine();
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1 - Listar séries");
            Console.WriteLine("2 - Inserir nova série");
            Console.WriteLine("3 - Atualizar série");
            Console.WriteLine("4 - Excluir série");
            Console.WriteLine("5 - Visualizar série");
            Console.WriteLine("C - Limpar tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string userOption = Console.ReadLine().ToUpper();
            
            Console.WriteLine();

            return userOption;
        }

        private static string[] GetSerieData()
        {
            string[] array = new string[4];

            foreach (int i in Enum.GetValues(typeof(Genre)))
            {
                Console.WriteLine($"{i} - {Enum.GetName(typeof(Genre), i)}");
            }

            Console.Write("Digite o gênero entre as opções acima: ");
            int genreInput = int.Parse(Console.ReadLine());
            array[0] = genreInput.ToString();

            Console.Write("Digite o título da Série: ");
            string titleInput = Console.ReadLine();
            array[1] = titleInput;

            Console.Write("Digite o ano de início da série: ");
            int yearInput = int.Parse(Console.ReadLine());
            array[2] = yearInput.ToString();

            Console.Write("Digite a descrição da série: ");
            string descriptionInput = Console.ReadLine();   
            array[3] = descriptionInput;

            return array;
        } 
    }
}
