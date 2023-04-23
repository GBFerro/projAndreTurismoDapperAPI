using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Services;

namespace Controllers
{
    public class AddressController
    {
        public readonly static string INSERT = "insert into Address (Street, Number, District, ZipCode, Complement, RegisterDate, IdCity) " +
            "values (@Street, @Number, @District, @ZipCode, @Complement, @RegisterDate, @IdCity); Select cast(scope_Identity() as int)";

        public readonly static string GETALL = "select a.Id, a.Street, a.Number, a.District, a.ZipCode, a.Complement, a.RegisterDate, c.Id, c.Name, c.RegisterDate " +
            "from Address a join City c on a.IdCity = c.Id";

        public readonly static string DELETE = "delete from Address where Id = @Id";

        public readonly static string UPDATE = "update Address set Street = @Street, Number = @Number, District = @District, " +
            "ZipCode = @ZipCode, Complement = @Complement where Id = @Id";

        private AddressService _addressService;

        public AddressController() {
            _addressService = new AddressService();
        }  

        public int Insert(Address address)
        {
            address.City.Id = new CityController().Insert(address.City);
            return new AddressService().Insert(address, INSERT);
        }

        public bool Update(Address address)
        {
            new CityController().Update(address.City);
            return _addressService.Update(address, UPDATE);
        }

        public bool Delete(int id)
        {
            new CityController().Delete(id);
            return _addressService.Delete(id, DELETE);
        }

        public List<Address> FindAll()
        {
            return _addressService.FindAll(GETALL);
        }
    }
}
