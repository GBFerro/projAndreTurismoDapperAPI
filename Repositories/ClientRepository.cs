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
    public class ClientRepository : ConnectionDBRepository, IClientRepository
    {
        public bool Delete(int id, string DELETE)
        {
            try
            {
                using (Conn)
                {
                    Conn.Execute(DELETE, new { Id = id });
                }

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Client> FindAll(string GETALL)
        {
            List<Client> list = new List<Client>();
            using (Conn)
            {
                Conn.Open();
                list = (List<Client>)Conn.Query<Client, Address, City, Client>(GETALL, (client, address, city) => { client.Address = address; client.Address.City = city; return client; });
            }
            return list;
        }

        public int Insert(Client client, string INSERT)
        {
            try
            {
                int id;
                using (Conn)
                {
                    Conn.Open();
                    id = Conn.ExecuteScalar<int>(INSERT, new
                    {
                        @Name = client.Name,
                        @Phone = client.Phone,
                        @RegisterDate = client.RegisterDate,
                        @IdAddress = client.Address.Id
                    });
                }
                return id;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Update(Client client, string UPDATE)
        {
            try
            {
                using (Conn)
                {
                    Conn.Open();
                    Conn.Execute(UPDATE, client);
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
