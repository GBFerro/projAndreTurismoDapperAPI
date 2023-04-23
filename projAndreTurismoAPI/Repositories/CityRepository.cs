using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Models;
using Repositories.Interfaces;

namespace Repositories
{
    public class CityRepository : ConnectionDBRepository, ICityRepository
    {
        public bool Delete(int id, string DELETE)
        {
            try
            {
                using (Conn)
                {
                    Conn.Open();
                    Conn.Execute(DELETE, new {@Id = id});
                }
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<City> FindAll(string GETALL)
        {
            List<City> list = new List<City>();
            try
            {
                using (Conn)
                {
                    Conn.Open();
                    list = (List<City>) Conn.Query<City>(GETALL);
                }
                return list;
            }
            catch (Exception)
            {

                throw;
            }        
        }

        public int Insert(City city, string INSERT)
        {
            try
            {
                int id;

                using (Conn)
                {
                    Conn.Open();
                    id = Conn.ExecuteScalar<int>(INSERT, city);
                }
                return id;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Update(City city, string UPDATE)
        {
            try
            {
                using (Conn)
                {
                    Conn.Open();
                    Conn.Execute(UPDATE, city);
                }
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
