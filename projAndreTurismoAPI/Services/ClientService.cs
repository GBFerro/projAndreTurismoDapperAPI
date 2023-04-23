using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Models;
using Repositories;

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

        public int Insert(Client client, string INSERT)
        {
            return new ClientRepository().Insert(client, INSERT);
        }

        public bool Update(Client client, string UPDATE)
        {
            return new ClientRepository().Update(client, UPDATE);
        }

        public bool Delete(int id, string DELETE)
        {
            return new ClientRepository().Delete(id, DELETE);
        }

        public List<Client> FindAll(string GETALL)
        {
            return new ClientRepository().FindAll(GETALL);
        }
    }

}


