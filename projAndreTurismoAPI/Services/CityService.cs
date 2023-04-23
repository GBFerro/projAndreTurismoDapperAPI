using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Repositories;

namespace Services
{
    public class CityService
    {
        public int Insert(City city, string INSERT)
        {
            int id = new CityRepository().Insert(city, INSERT);
            return id;
        }

        public bool Update(City city, string UPDATE)
        {
            return new CityRepository().Update(city, UPDATE);
        }

        public bool Delete(int id, string DELETE)
        {
            return new CityRepository().Delete(id, DELETE);
        }

        public List<City> FindAll(string GETALL)
        {
            return new CityRepository().FindAll(GETALL);
        }
    }
}
