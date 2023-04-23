using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Models;
using Services;

namespace Controllers
{
    public class ClientController
    {
        public readonly static string INSERT = "insert into Client (Name, Phone, RegisterDate, IdAddress) " +
            "values (@Name, @Phone, @RegisterDate, @IdAddress); Select cast(scope_Identity() as int)";

        public readonly static string GETALL = "select client.*, address.*, city.*" +
            "from[Client] client join[Address] address on client.[IdAddress] = address.[Id]" +
            "join[City] city on city.[Id] = address.[IdCity]";

        private readonly static string DELETE = "delete from Client where Id = @Id";

        private readonly static string UPDATE = "update Client set Name = @Name, Phone = @Phone where Id = @Id";

        private ClientService _clientService;

        public ClientController()
        {
            _clientService = new ClientService();
        }
        public int Insert(Client client)
        {
            client.Address.Id = new AddressController().Insert(client.Address);
            return _clientService.Insert(client, INSERT);
        }

        public bool Update(Client client)
        {
            new AddressController().Update(client.Address);
            return _clientService.Update(client, UPDATE);
        }

        public bool Delete(int id)
        {
            new AddressController().Delete(id);
            return _clientService.Delete(id, DELETE);
        }

        public List<Client> FindAll()
        {
            return _clientService.FindAll(GETALL);
        }
    }
}
