using System;

namespace Series
{
    public class Serie : BaseEntity
    {
        // Attributes

        public Genre Genre { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        private int Year { get; set; }
        private bool Removed { get; set; }

        // Methods

        public Serie(int id, Genre genre, string title, string description, int year)
        {
            this.Id = id;
            this.Genre = genre;
            this.Title = title;
            this.Description = description;
            this.Year = year;
            this.Removed = false;
        }

        public override string ToString()
        {
            string returnString = "";
            
            returnString += "Gênero: " + this.Genre + Environment.NewLine;
            returnString += "Título: " + this.Title + Environment.NewLine;
            returnString += "Descrição: " + this.Description + Environment.NewLine;
            returnString += "Ano: " + this.Year + Environment.NewLine;
            returnString += "Excluído: " + this.Removed + Environment.NewLine;

            return returnString;
        }

        public string returnTitle()
        {
            return this.Title;
        }

        public int returnId()
        {
            return this.Id;
        }

        public bool returnRemoved()
        {
            return this.Removed;
        }

        public void Remove()
        {
            this.Removed = true;
        }
    }
}