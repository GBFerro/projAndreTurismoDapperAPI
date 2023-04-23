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
                list = (List<Package>)Conn.Query<Package, Hotel, Address, City, Client, Address, City, Package>(GETALL, (package, hotel, addressH, cityH, client, addressC, cityC)
                    => { package.Hotel = hotel; package.Hotel.Address = addressH; package.Hotel.Address.City = cityH; package.Client = client;
                        package.Client.Address = addressC; package.Client.Address.City = cityC; return package;
                    });
                //(GETALL, (package, hotel, addressHotel, cityHotel, client, addressClient, cityClient, ticket, departure, cityD, arrival, cityA) =>
                //{ package.Hotel = hotel; package.Hotel.Address = addressHotel; package.Hotel.Address.City = cityHotel; package.Client = client;
                //package.Client.Address = addressClient; package.Client.Address.City = cityClient; ticket.Departure = departure; 
                //ticket.Departure.City = cityD; ticket.Arrival = arrival; ticket.Arrival.City = cityA; return package; });
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
