using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Services
{
    public class CityService
    {
        readonly string strConn = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;AttachDbFileName=C:\Users\adm\source\repos\projAndreTurismo\Database\AndreTurismo.mdf";
        readonly SqlConnection conn;

        public CityService()
        {
            conn = new SqlConnection(strConn);
            conn.Open();
        }

        public City Insert(City city, string INSERT)
        {
            int id = 0;

            try
            {
                SqlCommand commandInsert = new SqlCommand(INSERT, conn);

                commandInsert.Parameters.Add(new SqlParameter("@Name", city.Name));
                commandInsert.Parameters.Add(new SqlParameter("@RegisterDate", city.RegisterDate));

                id = (int)commandInsert.ExecuteScalar();
                city.Id = id;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }

            return city;
        }

        public bool Update(City city, string UPDATE)
        {
            bool status = false;

            try
            {
                SqlCommand commandUpdate = new SqlCommand(UPDATE, conn);

                commandUpdate.Parameters.Add(new SqlParameter("@Id", city.Id));
                commandUpdate.Parameters.Add(new SqlParameter("@Name", city.Name));

                commandUpdate.ExecuteNonQuery();

                status = true;
            }
            catch (Exception)
            {
                throw;
            }

            return status;
        }

        public bool Delete(int id, string INSERT)
        {
            bool status = false;
            try
            {
                SqlCommand commandDelete = new SqlCommand(INSERT, conn);

                commandDelete.Parameters.Add(new SqlParameter("@Id", id));

                commandDelete.ExecuteNonQuery();

                status = true;
            }
            catch (Exception)
            {
                status = false;
                throw;
            }

            return status;
        }

        public List<City> FindAll(string GETALL)
        {
            List<City> cities = new List<City>();

            SqlCommand commandSelect = new SqlCommand(GETALL, conn);
            SqlDataReader reader = commandSelect.ExecuteReader();

            while (reader.Read())
            {
                City city = new City();

                city.Id = (int)reader["Id"];
                city.Name = (string)reader["Name"];
                city.RegisterDate = (DateTime)reader["RegisterDate"];

                cities.Add(city);
            }

            return cities;
        }
    }
}
