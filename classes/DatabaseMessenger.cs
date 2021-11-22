using System;
using System.Data.SqlClient;

namespace Series
{
    public class DatabaseMessenger
    {
        private SqlConnection Connection { get; set; }
        public DatabaseMessenger(){
            this.Connection = Connect();
        }
        private SqlConnection Connect()
        {
            SqlConnection connection;

            connection = new SqlConnection("Server=localhost;Database=SeriesDB;User=SA;Password=****");
            connection.Open();
            
            return connection;
        }

        public void CloseConnection()
        {
            this.Connection.Close();
        }

        public void Insert(Genre genre, string title, string description, int year)
        {
            SqlCommand insertion = new SqlCommand($"INSERT Series (Genero, Titulo, Descricao, Ano, Removido) values ('{genre}', '{title}', '{description}', {year}, 0)", this.Connection);
            insertion.ExecuteNonQuery();
        }

        public void Update(int id, Genre genre, string title, string description, int year)
        {
            SqlCommand update = new SqlCommand($"UPDATE Series set Genero='{genre}', Titulo='{title}', Descricao='{description}', Ano={year}, Removido=0 where ID={id}", this.Connection);
            update.ExecuteNonQuery();
        }

        public void Delete(int Id)
        {
            SqlCommand deletion = new SqlCommand($"UPDATE Series SET Removido=1 where ID={Id}", this.Connection);
            deletion.ExecuteNonQuery();
        }

        public SqlDataReader Select()
        {
            SqlCommand selection = new SqlCommand($"SELECT * FROM Series", this.Connection);
            SqlDataReader reader = selection.ExecuteReader();

            return reader;
        }

        public SqlDataReader SelectWhere(int id)
        {
            SqlCommand selection = new SqlCommand($"SELECT * FROM Series WHERE id={id}", this.Connection);
            SqlDataReader reader = selection.ExecuteReader();

            return reader;
        }
    }
}
