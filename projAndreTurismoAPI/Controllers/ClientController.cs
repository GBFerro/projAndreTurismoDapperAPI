using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services;

namespace projAndreTurismoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
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

        [HttpPost(Name = "Insert Client")]
        public int Insert(Client client)
        {
            client.Address.Id = new AddressController().Insert(client.Address);
            return _clientService.Insert(client, INSERT);
        }

        [HttpPut(Name = "Update Client")]
        public bool Update(Client client)
        {
            new AddressController().Update(client.Address);
            return _clientService.Update(client, UPDATE);
        }

        [HttpDelete(Name = "Delete Client By {id}")]
        public bool Delete(int id)
        {
            new AddressController().Delete(id);
            return _clientService.Delete(id, DELETE);
        }

        [HttpGet(Name = "List Clients")]
        public List<Client> FindAll()
        {
            return _clientService.FindAll(GETALL);
        }
    }
}
