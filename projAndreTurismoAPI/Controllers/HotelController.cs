using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services;

namespace projAndreTurismoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        public readonly static string INSERT = "insert into Hotel (Name, IdAddress, RegisterDate, Value) " +
            "values (@Name, @IdAddress, @RegisterDate, @Value); Select cast(scope_Identity() as int)";

        public readonly static string GETALL = "select hotel.[Id], hotel.[Name], " +
            "hotel.[Value],hotel.[RegisterDate], " +
            "address.[Id], address.[Street], " +
            "address.[Number], " +
            "address.[District], address.[ZipCode], " +
            "address.[Complement], address.[RegisterDate], city.[Id], city.[Name], " +
            "city.[RegisterDate] " +
            "from [Hotel] hotel join [Address] address on hotel.[IdAddress] = address.[Id] " +
            "join [City] city on city.[Id] = address.[IdCity]";

        public readonly static string DELETE = "delete from Hotel where Id = @Id";

        public readonly static string UPDATE = "update Hotel set Name = @Name, Value = @Value where Id = @Id";


        private HotelService _hotelService;
        public HotelController()
        {
            _hotelService = new HotelService();
        }

        [HttpPost(Name = "Insert Hotel")]
        public int Insert(Hotel hotel)
        {
            hotel.Address.Id = new AddressController().Insert(hotel.Address);
            return _hotelService.Insert(hotel, INSERT);
        }

        [HttpPut(Name = "Update Hotel")]
        public bool Update(Hotel hotel)
        {
            new CityController().Update(hotel.Address.City);
            new AddressController().Update(hotel.Address);
            return _hotelService.Update(hotel, UPDATE);
        }

        [HttpDelete(Name = "Delete Hotel By {id}")]
        public bool Delete(int id)
        {
            new AddressController().Delete(id);
            return _hotelService.Delete(id, DELETE);
        }

        [HttpGet(Name = "List Hotels")]
        public List<Hotel> FindAll()
        {
            return _hotelService.FindAll(GETALL) ;
        }
    }
}
