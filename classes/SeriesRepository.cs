using System.Collections.Generic;
using Series.Interfaces;

namespace Series
{
    public class SeriesRepository : IRepository<Serie>
    {
        private List<Serie> seriesList = new List<Serie>();
        public void Insert(Serie entity)
        {
            seriesList.Add(entity);
        }

        public List<Serie> List()
        {
            return seriesList;
        }

        public int NextId()
        {
            return seriesList.Count;
        }

        public void Remove(int id)
        {
            seriesList[id].Remove();
        }

        public Serie ReturnById(int id)
        {
            return seriesList[id];
        }

        public void Update(int id, Serie entity)
        {
            seriesList[id] = entity;
        }
    }
}