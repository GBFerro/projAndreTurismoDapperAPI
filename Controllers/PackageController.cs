using Models;
using Services;

namespace Controllers
{
    public class PackageController
    {
        public readonly static string INSERT = "insert into Package (IdHotel, IdTicket, IdClient, RegisterDate, Value) " +
            "values (@IdHotel, @IdTicket, @IdClient, @RegisterDate, @Value); Select cast(scope_Identity() as int)";

        public readonly static string GETALL = "select package.[Id] as IdPackage, " +
            "package.[Value] as ValuePackage, package.[RegisterDate] as RegisterPackage, " +
            "hotel.[Id] as IdHotel, hotel.[Name] as NameHotel, hotel.[Value] as ValueHotel, " +
            "addressHotel.[Id] as IdHotelAddress, addressHotel.[Street] as StreetHotelAddress, " +
            "addressHotel.[Number] as NumberHotelAddress, addressHotel.[District] as DistrictHotelAddress, " +
            "addressHotel.[ZipCode] as ZipHotelAddress, addressHotel.[Complement] as ComplementHotelAddress, " +
            "cityHotel.[Id] as IdHotelCity, cityHotel.[Name] as NameHotelCity, " +
            "cityHotel.[RegisterDate] as RegisterHotelCity, " +
            "addressHotel.[RegisterDate] as RegisterHotelAddress, " +
            "hotel.[RegisterDate] as RegisterHotel, ticket.[Id] as TicketId, " +
            "addressDeparture.[Id] as IdAddressDeparture, " +
            "addressDeparture.[Street] as StreetAddressDeparture, " +
            "addressDeparture.[Number] as NumberAddressDeparture, " +
            "addressDeparture.[District] as DistrictAddressDeparture, " +
            "addressDeparture.[ZipCode] as ZipAddressDeparture, " +
            "addressDeparture.[Complement] as ComplementAddressDeparture, " +
            "cityDeparture.[Id] as IdCityDeparture, cityDeparture.[Name] as NameCityDeparture, " +
            "cityDeparture.[RegisterDate] as RegisterCityDeparture, " +
            "addressDeparture.[RegisterDate] as RegisterAddressDeparture, " +
            "addressArrival.[Id] as IdAddressArrival, addressArrival.[Street] as StreetAddressArrival, " +
            "addressArrival.[Number] as NumberAddressArrival, " +
            "addressArrival.[District] as DistrictAddressArrival, " +
            "addressArrival.[ZipCode] as ZipAddressArrival, " +
            "addressArrival.[Complement] as ComplementAddressArrival, " +
            "cityArrival.[Id] as IdCityArrival, cityArrival.[Name] as NameCityArrival, " +
            "cityArrival.[RegisterDate] as RegisterCityArrival, " +
            "addressArrival.[RegisterDate] as RegisterAddressArrival, " +
            "ticket.[Value] as ValueTicket, ticket.[RegisterDate] as RegisterTicket, " +
            "client.[Id] as IdClient, client.[Name] as NameClient, client.[Phone] as PhoneClient, " +
            "[addressClient].[Id] as IdClientAddress, [addressClient].[Street] as StreetClientAddress, " +
            "[addressClient].[Number] as NumberClientAddress, " +
            "[addressClient].[District] as DistrictClientAddress, " +
            "[addressClient].[ZipCode] as ZipClientAddress, " +
            "[addressClient].[Complement] as ComplementClientAddress, " +
            "cityClient.[Id] as IdClientCity, cityClient.[Name] as NameClientCity, " +
            "cityClient.[RegisterDate] as RegisterClientCity, " +
            "[addressClient].[RegisterDate] as RegisterClientAddress, " +
            "client.[RegisterDate] as RegisterClient " +
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


        //private TicketService _ticketService;
        //private AddressService _addressService;
        //private CityService _cityService;
        //private ClientService _clientService;
        //private HotelService _hotelService;
        private PackageService _packageService;

        public PackageController()
        {
            //_cityService = new CityService();
            //_ticketService = new TicketService();
            //_addressService = new AddressService();
            //_hotelService = new HotelService();
            //_clientService = new ClientService();
            _packageService = new PackageService();
        }
        public bool Insert(Package package)
        {
            bool status = false;

            try
            {
                //_cityService.InsertCity(package.Hotel.Address.City);
                //_addressService.InsertAddress(package.Hotel.Address);
                //_hotelService.InsertHotel(package.Hotel);
                new HotelController().Insert(package.Hotel);

                //_cityService.InsertCity(package.Client.Address.City);
                //_addressService.InsertAddress(package.Client.Address);
                //_clientService.InsertClient(package.Client);
                new ClientController().Insert(package.Client);

                //_cityService.InsertCity(package.Ticket.Departure.City);
                //_cityService.InsertCity(package.Ticket.Arrival.City);
                //_addressService.InsertAddress(package.Ticket.Departure);
                //_addressService.InsertAddress(package.Ticket.Arrival);
                //_ticketService.InsertTicket(package.Ticket);
                new TicketController().Insert(package.Ticket);

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

        public bool Update(Package package)
        {
            new HotelController().Update(package.Hotel);
            new ClientController().Update(package.Client);
            new TicketController().Update(package.Ticket);
            return _packageService.Update(package, UPDATE);
        }

        public bool Delete(int id)
        {
            return _packageService.Delete(id, DELETE);
        }

        public List<Package> FindAll()
        {
            return _packageService.FindAll(GETALL);
        }
    }
}