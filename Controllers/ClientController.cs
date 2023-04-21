using System;
using System.Collections.Generic;
using System.Linq;
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

        public readonly static string GETALL = "select client.[Id] as IdClient, client.[Name] as NameClient, client.[Phone] as PhoneClient, " +
            "address.[Id] as IdAddress, address.[Street] as StreetAddress, address.[Number] as NumberAddress, address.[District] as DistrictAddress, " +
            "address.[ZipCode] as ZipAddress, address.[Complement] as ComplementAddress, city.[Id] as IdCity, city.[Name] as NameCity, " +
            "city.[RegisterDate] as RegisterCity, address.[RegisterDate] as RegisterAddress, " +
            "client.[RegisterDate] as RegisterClient " +
            "from[Client] client join[Address] address on client.[IdAddress] = address.[Id]" +
            "join[City] city on city.[Id] = address.[IdCity]";

        private readonly static string DELETE = "delete from Client where Id = @Id";

        private readonly static string UPDATE = "update Client set Name = @Name, Phone = @Phone where Id = @Id";

        private ClientService _clientService;
        //private AddressService _addressService;
        //private CityService _cityService;

        public ClientController()
        {
            _clientService = new ClientService();
            //_addressService = new AddressService();
            //_cityService = new CityService();
        }
        public bool Insert(Client client)
        {
            bool status = false;
            try
            {
                //client.Address.City = _cityService.InsertCity(client.Address.City);
                //client.Address = _addressService.InsertAddress(client.Address);
                new AddressController().Insert(client.Address);

                _clientService.Insert(client, INSERT);

                status = true;
            }
            catch (Exception)
            {
                status = false;
                throw;
            }
            return status;
        }

        public bool Update(Client client)
        {
            new CityController().Update(client.Address.City);
            new AddressController().Update(client.Address);
            return _clientService.Update(client, UPDATE);
        }

        public bool Delete(int id)
        {
            return _clientService.Delete(id, DELETE);
        }

        public List<Client> FindAll()
        {
            return _clientService.FindAll(GETALL);
        }
    }
}
