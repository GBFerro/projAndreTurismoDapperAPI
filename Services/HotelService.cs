using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using Models;

namespace Services
{
    public class HotelService
    {
        readonly string strConn = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;AttachDbFileName=C:\Users\adm\source\repos\projAndreTurismo\Database\AndreTurismo.mdf";
        readonly SqlConnection conn;

        public HotelService()
        {
            conn = new SqlConnection(strConn);
            conn.Open();
        }

        public Hotel Insert(Hotel hotel, string INSERT)
        {
            try
            {
                SqlCommand commandInsert = new SqlCommand(INSERT, conn);

                commandInsert.Parameters.Add(new SqlParameter("@Name", hotel.Name));
                commandInsert.Parameters.Add(new SqlParameter("@RegisterDate", hotel.RegisterDate));
                commandInsert.Parameters.Add(new SqlParameter("@Value", hotel.Value));
                commandInsert.Parameters.Add(new SqlParameter("@IdAddress", hotel.Address.Id));

                int id = (int)commandInsert.ExecuteScalar();
                hotel.Id = id;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }

            return hotel;
        }

        public bool Update(Hotel hotel, string UPDATE)
        {
            bool status = false;

            try
            {
                SqlCommand commandUpdate = new SqlCommand(UPDATE, conn);

                commandUpdate.Parameters.Add(new SqlParameter("@Id", hotel.Id));
                commandUpdate.Parameters.Add(new SqlParameter("@Name", hotel.Name));
                commandUpdate.Parameters.Add(new SqlParameter("@Value", hotel.Value));

                commandUpdate.ExecuteNonQuery();

                status = true;
            }
            catch (Exception)
            {
                throw;
            }

            return status;
        }

        public bool Delete(int id, string DELETE)
        {
            bool status = false;

            try
            {
                SqlCommand commandDelete = new SqlCommand(DELETE, conn);

                commandDelete.Parameters.Add(new SqlParameter("@Id", id));

                commandDelete.ExecuteNonQuery();

                status = true;
            }
            catch (Exception)
            {
                throw;
            }

            return status;
        }

        public List<Hotel> FindAll(string GETALL)
        {
            List<Hotel> hotels = new List<Hotel>();

            SqlCommand commandSelect = new SqlCommand(GETALL, conn);

            SqlDataReader reader = commandSelect.ExecuteReader();

            while (reader.Read())
            {
                Hotel hotel = new Hotel();

                hotel.Id = (int)reader["IdHotel"];
                hotel.Name = (string)reader["NameHotel"];
                hotel.Value = (decimal)reader["ValueHotel"];
                hotel.Address = new Address()
                {
                    Id = (int)reader["IdAddress"],
                    Street = (string)reader["StreetAddress"],
                    Number = (int)reader["NumberAddress"],
                    District = (string)reader["DistrictAddress"],
                    ZipCode = (string)reader["ZipAddress"],
                    Complement = (string)reader["ComplementAddress"],
                    City = new City()
                    {
                        Id = (int)reader["IdCity"],
                        Name = (string)reader["NameCity"],
                        RegisterDate = (DateTime)reader["RegisterCity"]
                    },
                    RegisterDate = (DateTime)reader["RegisterAddress"]
                };
                hotel.RegisterDate = (DateTime)reader["RegisterHotel"];

                hotels.Add(hotel);
            }
            return hotels;
        }
    }
}
