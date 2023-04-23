using Microsoft.AspNetCore.Mvc;
using Models;
using Services;

namespace projAndreTurismoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PackageController : ControllerBase
    {
        public readonly static string INSERT = "insert into Package (IdHotel, IdTicket, IdClient, RegisterDate, Value) " +
            "values (@IdHotel, @IdTicket, @IdClient, @RegisterDate, @Value); Select cast(scope_Identity() as int)";

        public readonly static string GETALL = "select package.[Id], " +
            "package.[Value], package.[RegisterDate], " +
            "hotel.[Id], hotel.[Name], hotel.[Value], hotel.[RegisterDate], " +
            "addressHotel.[Id], addressHotel.[Street], " +
            "addressHotel.[Number], addressHotel.[District], " +
            "addressHotel.[ZipCode], addressHotel.[Complement], addressHotel.[RegisterDate], " +
            "cityHotel.[Id], cityHotel.[Name], cityHotel.[RegisterDate], " +
            "ticket.[Id], ticket.[Value], ticket.[RegisterDate], " +
            "addressDeparture.[Id], addressDeparture.[Street], addressDeparture.[Number], " + 
            "addressDeparture.[District], addressDeparture.[ZipCode], addressDeparture.[Complement], " + 
            "cityDeparture.[Id], cityDeparture.[Name], cityDeparture.[RegisterDate], " +
            "addressArrival.[Id], addressArrival.[Street], addressArrival.[Number], " +
            "addressArrival.[District], addressArrival.[ZipCode], addressArrival.[Complement], " +
            "cityArrival.[Id], cityArrival.[Name], cityArrival.[RegisterDate], " +
            "client.[Id], client.[Name], client.[Phone], client.[RegisterDate], " +
            "[addressClient].[Id], [addressClient].[Street], " +
            "[addressClient].[Number], " +
            "[addressClient].[District], " +
            "[addressClient].[ZipCode], " +
            "[addressClient].[Complement], " +
            "[addressClient].[RegisterDate], " +
            "cityClient.[Id], cityClient.[Name], cityClient.[RegisterDate] " +
            "from [Package] package join [Hotel] hotel on package.[IdHotel] = hotel.[Id] " +
            "join [Address] addressHotel on hotel.[IdAddress] = addressHotel.[Id] " +
            "join [City] cityHotel on cityHotel.[Id] = addressHotel.[IdCity] " +
            "join [Ticket] ticket on package.[IdTicket] = ticket.[Id] " +
            "join [Address] addressArrival on ticket.[Arrival] = addressArrival.[Id] " +
            "join [City] cityArrival on addressArrival.[IdCity] = cityArrival.[Id] " +
            "join [Address] addressDeparture on ticket.[Departure] = addressDeparture.[Id] " +
            "join [City] cityDeparture on addressDeparture.[IdCity] = cityDeparture.[Id] " +
            "join [Client] client on package.[IdClient] = client.[Id] " +
            "join [Address] [addressClient] on client.[IdAddress] = [addressClient].[Id] " +
            "join [City] cityClient on cityClient.[Id] = [addressClient].[IdCity]";

        public readonly static string DELETE = "delete from Package where Id = @Id";

        public readonly static string UPDATE = "update Package set Value = @Value where Id = @Id";

        private PackageService _packageService;

        public PackageController()
        { 
            _packageService = new PackageService();
        }

        [HttpPost(Name = "Insert Package")]
        public bool Insert(Package package)
        {
            bool status = false;

            try
            {
                package.Hotel.Id = new HotelController().Insert(package.Hotel);

                package.Client.Id = new ClientController().Insert(package.Client);

                package.Ticket.Id = new TicketController().Insert(package.Ticket);

                _packageService.Insert(package, INSERT);

                status = true;
            }
            catch (Exception)
            {
                status = false;
                throw;
            }

            return status;
        }

        [HttpPut(Name = "Update Package")]
        public bool Update(Package package)
        {
            new HotelController().Update(package.Hotel);
            new ClientController().Update(package.Client);
            new TicketController().Update(package.Ticket);
            return _packageService.Update(package, UPDATE);
        }

        [HttpDelete(Name = "Delete Package By {id}")]
        public bool Delete(int id)
        {
            return _packageService.Delete(id, DELETE);
        }

        [HttpGet(Name = "List Package")]
        public List<Package> FindAll()
        {
            return _packageService.FindAll(GETALL);
        }
    }
}