using System;
using System.Data.SqlClient;

namespace Series
{
    public class ProgramMessenger
    {
        static DatabaseMessenger databaseMessenger = new DatabaseMessenger();
        public static string GetSerieInformation(int serieIndex)
        {
            string print = "";

            using(SqlDataReader serie = databaseMessenger.SelectWhere(serieIndex))
            {
                while (serie.Read())
                {
                    print += $"Gênero: {serie.GetValue(1)}" + Environment.NewLine;
                    print += $"Título: {serie.GetValue(2)}" + Environment.NewLine;
                    print += $"Descrição: {serie.GetValue(3)}" + Environment.NewLine;
                    print += $"Ano: {serie.GetValue(4)}" + Environment.NewLine;
                    print += $"Removido: {(serie.GetValue(5))}" + Environment.NewLine;
                }
            }

            return print;
        }

        public static void DeleteSerie(int serieIndex)
        {
            databaseMessenger.Delete(serieIndex);
        }

        public static void UpdateSerie(int serieIndex, string[] serieData)
        {
            Genre genre = (Genre)int.Parse(serieData[0]);
            string title = serieData[1];
            string description = serieData[3];
            int year = int.Parse(serieData[2]);
                
            databaseMessenger.Update(id: serieIndex, genre: genre, 
                                    title: title, description: description,
                                    year: year);
        }

        public static void InsertSerie(string[] serieData)
        {
            Genre genre = (Genre)int.Parse(serieData[0]);
            string title = serieData[1];
            string description = serieData[3];
            int year = int.Parse(serieData[2]);
                
            databaseMessenger.Insert(genre: genre, title: title, 
                                    description: description, year: year);
        }

        public static string GetSeriesList()
        {
            string list = "";

            using (SqlDataReader series = databaseMessenger.Select())
            {
                int iterations = 0;

                while (series.Read())
                {
                    bool isRemoved = (bool)series.GetValue(5);
                    if (!isRemoved)
                    {
                        list += $"# ID {series.GetValue(0)}: - {series.GetValue(2)}{Environment.NewLine}";
                        iterations++;
                    }
                }

                if (iterations == 0) list += "Nenhuma série cadastrada";
            }

            return list;
        }
    }
}