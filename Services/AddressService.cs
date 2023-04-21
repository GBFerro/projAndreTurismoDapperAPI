using System.Collections.Generic;
using System.Data.SqlClient;
using Models;

namespace Services
{
    public class AddressService
    {
        readonly string strConn = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;AttachDbFileName=C:\Users\adm\source\repos\projAndreTurismo\Database\AndreTurismo.mdf";
        readonly SqlConnection conn;

        public AddressService()
        {
            conn = new SqlConnection(strConn);
            conn.Open();
        }

        public Address Insert(Address address, string INSERT)
        {
            int id = 0;
            try
            {
                SqlCommand commandInsert = new SqlCommand(INSERT, conn);

                commandInsert.Parameters.Add(new SqlParameter("@Street", address.Street));
                commandInsert.Parameters.Add(new SqlParameter("@Number", address.Number));
                commandInsert.Parameters.Add(new SqlParameter("@District", address.District));
                commandInsert.Parameters.Add(new SqlParameter("@ZipCode", address.ZipCode));
                commandInsert.Parameters.Add(new SqlParameter("@Complement", address.Complement));
                commandInsert.Parameters.Add(new SqlParameter("@RegisterDate", address.RegisterDate));
                commandInsert.Parameters.Add(new SqlParameter("@IdCity", address.City.Id));

                id = (int)commandInsert.ExecuteScalar();
                address.Id = id;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }

            return address;
        }


        public bool Update(Address address, string UPDATE)
        {
            bool status = false;

            try
            {
                SqlCommand commandUpdate = new SqlCommand(UPDATE, conn);

                commandUpdate.Parameters.Add(new SqlParameter("@Id", address.Id));
                commandUpdate.Parameters.Add(new SqlParameter("@Street", address.Street));
                commandUpdate.Parameters.Add(new SqlParameter("@Number", address.Number));
                commandUpdate.Parameters.Add(new SqlParameter("@District", address.District));
                commandUpdate.Parameters.Add(new SqlParameter("@ZipCode", address.ZipCode));
                commandUpdate.Parameters.Add(new SqlParameter("@Complement", address.Complement));

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

        public List<Address> FindAll(string GETALL)
        {
            List<Address> addresses = new List<Address>();

            SqlCommand commandSelect = new SqlCommand(GETALL, conn);

            SqlDataReader reader = commandSelect.ExecuteReader();

            while (reader.Read())
            {
                Address address = new Address();

                address.Id = (int)reader["AddressId"];
                address.Street = (string)reader["AddressStreet"];
                address.Number = (int)reader["AddressNumber"];
                address.District = (string)reader["AddressDistrict"];
                address.ZipCode = (string)reader["AddressZip"];
                address.Complement = (string)reader["AddressComplement"];
                address.City = new City() 
                { 
                    Id = (int)reader["CityId"],
                    Name = (string)reader["CityName"],
                    RegisterDate = (DateTime)reader["CityRegister"]
                };
                address.RegisterDate = (DateTime)reader["AddressRegister"];

                addresses.Add(address);
            }

            return addresses;
        }
    }
}