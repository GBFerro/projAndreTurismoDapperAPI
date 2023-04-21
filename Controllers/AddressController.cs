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

        public readonly static string GETALL = "select a.Id as AddressId, a.Street as AddressStreet, " +
            "a.Number as AddressNumber, a.District as AddressDistrict, " +
            "a.ZipCode as AddressZip, " +
            "a.Complement as AddressComplement, c.Id as CityId, c.Name as CityName, " +
            "c.RegisterDate as CityRegister, a.RegisterDate as AddressRegister " +
            "from Address a join City c on a.IdCity = c.Id";

        public readonly static string DELETE = "delete from Address where Id = @Id";

        public readonly static string UPDATE = "update Address set Street = @Street, Number = @Number, District = @District, " +
            "ZipCode = @ZipCode, Complement = @Complement where Id = @Id";

        private AddressService _addressService;
        //private CityService _cityService;
        public AddressController() {
            _addressService = new AddressService();
            //_cityService = new CityService();
        }  

        public bool Insert(Address address)
        {
            bool status = false;
            try
            {
                new CityController().Insert(address.City);
                //address.City = _cityService.InsertCity(address.City);

                _addressService.Insert(address, INSERT);

                status = true;
            }
            catch (Exception)
            {
                status = false;
                throw;
            }
            return status;
        }

        public bool Update(Address address)
        {
            new CityController().Update(address.City);
            return _addressService.Update(address, UPDATE);
        }

        public bool Delete(int id)
        {
            return _addressService.Delete(id, DELETE);
        }

        public List<Address> FindAll()
        {
            return _addressService.FindAll(GETALL);
        }
    }
}
