using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Services
{
    public class ClientService
    {
        readonly string strConn = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;AttachDbFileName=C:\Users\adm\source\repos\projAndreTurismo\Database\AndreTurismo.mdf";
        readonly SqlConnection conn;

        public ClientService()
        {
            conn = new SqlConnection(strConn);
            conn.Open();
        }

        public Client Insert(Client client, string INSERT)
        {
            int id = 0;
            try
            {
                SqlCommand commandInsert = new SqlCommand(INSERT, conn);

                commandInsert.Parameters.Add(new SqlParameter("@Name", client.Name));
                commandInsert.Parameters.Add(new SqlParameter("@Phone", client.Phone));
                commandInsert.Parameters.Add(new SqlParameter("@RegisterDate", client.RegisterDate));
                commandInsert.Parameters.Add(new SqlParameter("@IdAddress", client.Address.Id));

                id = (int)commandInsert.ExecuteScalar();
                client.Id = id;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }

            return client;
        }

        public bool Update(Client client, string UPDATE)
        {
            bool status = false;

            try
            {
                SqlCommand commandUpdate = new SqlCommand(UPDATE, conn);

                commandUpdate.Parameters.Add(new SqlParameter("@Id", client.Id));
                commandUpdate.Parameters.Add(new SqlParameter("@Name", client.Name));
                commandUpdate.Parameters.Add(new SqlParameter("@Phone", client.Phone));

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

        public List<Client> FindAll(string GETALL)
        {
            List<Client> clients = new List<Client>();

            SqlCommand commandSelect = new SqlCommand(GETALL, conn);

            SqlDataReader reader = commandSelect.ExecuteReader();

            while (reader.Read())
            {
                Client client = new Client();

                client.Id = (int)reader["IdClient"];
                client.Address = new Address()
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
                client.Name = (string)reader["NameClient"];
                client.Phone = (string)reader["PhoneClient"];
                client.RegisterDate = (DateTime)reader["RegisterClient"];


                clients.Add(client);
            }

            return clients;
        }
    }

}


