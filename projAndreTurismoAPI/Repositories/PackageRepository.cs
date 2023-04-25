using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Models;
using Repositories.Interfaces;

namespace Repositories
{
    public class PackageRepository : ConnectionDBRepository, IPackageRepository
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

        public List<Package> FindAll(string GETALL)
        {
            List<Package> list = new List<Package>();
            using (Conn)
            {
                Conn.Open();

                list = (List<Package>) Conn.Query<Package>(GETALL, new[]
                {
                    typeof(Package),
                    typeof(Hotel),
                    typeof(Address),
                    typeof(City),
                    typeof(Ticket),
                    typeof(Address),
                    typeof(City),
                    typeof(Address),
                    typeof(City),
                    typeof(Client),
                    typeof(Address),
                    typeof(City)
                },
                obj =>
                {
                    Package package = obj[0] as Package;
                    Hotel hotel = obj[1] as Hotel;
                    Address addressHotel = obj[2] as Address;
                    City cityHotel = obj[3] as City;
                    Ticket ticket = obj[4] as Ticket;
                    Address addressDeparture = obj[5] as Address;
                    City cityDeparture = obj[6] as City;
                    Address addressArrival = obj[7] as Address;
                    City cityArrival = obj[8] as City;
                    Client client = obj[9] as Client;
                    Address addressClient = obj[10] as Address;
                    City cityClient = obj[11] as City;

                    //package.Hotel.Address.City = cityHotel;
                    //package.Hotel.Address = addressHotel;
                    //package.Hotel = hotel;
                    //package.Ticket.Departure.City = cityDeparture;
                    //package.Ticket.Departure = addressDeparture;
                    //package.Ticket.Arrival.City = cityArrival;
                    //package.Ticket.Arrival = addressArrival;
                    //package.Ticket = ticket;
                    //package.Client.Address.City = cityClient;
                    //package.Client.Address = addressClient;
                    //package.Client = client;

                    addressHotel.City = cityHotel;
                    hotel.Address = addressHotel;
                    package.Hotel = hotel;
                    addressDeparture.City = cityDeparture;
                    ticket.Departure = addressDeparture;
                    addressArrival.City = cityArrival;
                    ticket.Arrival = addressArrival;
                    package.Ticket = ticket;
                    addressClient.City = cityClient;
                    client.Address = addressClient;
                    package.Client = client;

                    return package;
                });
            }
            return list;
        }

        public int Insert(Package package, string INSERT)
        {
            try
            {
                int id;
                using (Conn)
                {
                    Conn.Open();
                    id = Conn.ExecuteScalar<int>(INSERT, new
                    {
                        @IdHotel = package.Hotel.Id, 
                        @IdClient = package.Client.Id,
                        @IdTicket = package.Ticket.Id,
                        @RegisterDate = package.RegisterDate,
                        @Value = package.Value
                    });
                }
                return id;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Update(Package package, string UPDATE)
        {
            try
            {
                using (Conn)
                {
                    Conn.Open();
                    Conn.Execute(UPDATE, package);
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
