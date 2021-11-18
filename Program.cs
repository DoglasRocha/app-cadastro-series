using System;
using System.Collections.Generic;

namespace Series
{
    class Program
    {
        static SeriesRepository repository = new SeriesRepository();
        static DatabaseMessager databaseMessager = new DatabaseMessager();
        
        static void Main()
        {
            //databaseMessager.Insert((Genre)1, "lalala", "lalalala", 2018, false);
            //Console.WriteLine(databaseMessager.Select().ToString());
            Console.WriteLine(databaseMessager.SelectWhere(4));
            databaseMessager.Update(4, (Genre)1, "lalala", "lalalalala", 2018, false);
            databaseMessager.Delete(5);
            Console.WriteLine(databaseMessager.SelectWhere(4));

            /* string userOption = GetUserOption();

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
            } */
        }

        private static void ShowSerie()
        {
            Console.Write("Digite o id da série: ");
            int serieIndex = int.Parse(Console.ReadLine());

            Serie serie = repository.ReturnById(serieIndex);

            Console.WriteLine(serie);
        }

        private static void RemoveSerie()
        {
            Console.Write("Digite o id da série: ");
            int serieIndex = int.Parse(Console.ReadLine());

            repository.Remove(serieIndex);
        }

        private static void UpdateSerie()
        {
            Console.Write("Digite o id da série: ");
            int serieId = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genre)))
            {
                Console.WriteLine($"{i} - {Enum.GetName(typeof(Genre), i)}");
            }

            Console.Write("Digite o gênero entre as opções acima: ");
            int genreInput = int.Parse(Console.ReadLine());

            Console.Write("Digite o título da Série: ");
            string titleInput = Console.ReadLine();

            Console.Write("Digite o ano de início da série: ");
            int yearInput = int.Parse(Console.ReadLine());

            Console.Write("Digite a descrição da série: ");
            string descriptionInput = Console.ReadLine();

            Serie updatedSerie = new Serie(id: serieId,
                                           genre: (Genre)genreInput,
                                           title: titleInput,
                                           year: yearInput,
                                           description: descriptionInput);
        
            repository.Update(serieId, updatedSerie);
        }

        private static void InsertSerie()
        {
            Console.WriteLine("Inserir nova série");

            foreach (int i in Enum.GetValues(typeof(Genre)))
            {
                Console.WriteLine($"{i} - {Enum.GetName(typeof(Genre), i)}");
            }

            Console.Write("Digite o gênero entre as opções acima: ");
            int genreInput = int.Parse(Console.ReadLine());

            Console.Write("Digite o título da Série: ");
            string titleInput = Console.ReadLine();

            Console.Write("Digite o ano de início da série: ");
            int yearInput = int.Parse(Console.ReadLine());

            Console.Write("Digite a descrição da série: ");
            string descriptionInput = Console.ReadLine();

            Serie newSerie = new Serie(id: repository.NextId(),
                                       genre: (Genre)genreInput,
                                       title: titleInput,
                                       year: yearInput,
                                       description: descriptionInput);

            repository.Insert(newSerie);
        }

        private static void ListSeries()
        {
            Console.WriteLine("Listar Séries");
            
            List<Serie> list = repository.List();

            if (list.Count == 0)
            {
                Console.WriteLine("Nenhuma série cadastrada");
                return;
            }

            foreach (Serie serie in list)
            {
                bool removed = serie.returnRemoved();

                Console.WriteLine($"# ID {serie.returnId()}: - {serie.returnTitle()} - {(removed ? "Excluído" : "")}");
            }
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
    }
}
