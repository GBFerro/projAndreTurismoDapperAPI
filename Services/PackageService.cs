using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using Models;

namespace Services
{
    public class PackageService
    {
        readonly string strConn = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;AttachDbFileName=C:\Users\adm\source\repos\projAndreTurismo\Database\AndreTurismo.mdf";
        readonly SqlConnection conn;

        public PackageService()
        {
            conn = new SqlConnection(strConn);
            conn.Open();
        }

        public Package Insert(Package package, string INSERT)
        {
            try
            {
                SqlCommand commandInsert = new SqlCommand(INSERT, conn);

                commandInsert.Parameters.Add(new SqlParameter("@IdHotel", package.Hotel.Id));
                commandInsert.Parameters.Add(new SqlParameter("@IdTicket", package.Ticket.Id));
                commandInsert.Parameters.Add(new SqlParameter("@IdClient", package.Client.Id));
                commandInsert.Parameters.Add(new SqlParameter("@RegisterDate", package.RegisterDate));
                commandInsert.Parameters.Add(new SqlParameter("@Value", package.Value));

                int id = (int)commandInsert.ExecuteScalar();
                package.Id = id;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }

            return package;
        }

        public bool Update(Package package, string UPDATE)
        {
            bool status = false;

            try
            {
                SqlCommand commandUpdate = new SqlCommand(UPDATE, conn);

                commandUpdate.Parameters.Add(new SqlParameter("@Id", package.Id));
                commandUpdate.Parameters.Add(new SqlParameter("@Value", package.Value));

                commandUpdate.ExecuteNonQuery();

                status = true;
            }
            catch (Exception)
            {
                throw;
            }

            return status;
        }

        public bool Delete(int id, string DELETE)
        {
            bool status = false;

            try
            {
                SqlCommand commandDelete = new SqlCommand(DELETE, conn);

                commandDelete.Parameters.Add(new SqlParameter("@Id", id));

                commandDelete.ExecuteNonQuery();

                status = true;
            }
            catch (Exception)
            {
                throw;
            }

            return status;
        }

        public List<Package> FindAll(string GETALL)
        {
            List<Package> packages = new List<Package>();

            SqlCommand commandSelect = new SqlCommand(GETALL, conn);

            SqlDataReader reader = commandSelect.ExecuteReader();

            while (reader.Read())
            {
                Package package = new Package();

                package.Id = (int)reader["IdPackage"];
                package.Value = (decimal)reader["ValuePackage"];
                package.Hotel = new Hotel()
                {
                    Id = (int)reader["IdHotel"],
                    Name = (string)reader["NameHotel"],
                    Value = (decimal)reader["ValueHotel"],
                    Address = new Address()
                    {
                        Id = (int)reader["IdHotelAddress"],
                        Street = (string)reader["StreetHotelAddress"],
                        Number = (int)reader["NumberHotelAddress"],
                        District = (string)reader["DistrictHotelAddress"],
                        ZipCode = (string)reader["ZipHotelAddress"],
                        Complement = (string)reader["ComplementHotelAddress"],
                        City = new City()
                        {
                            Id = (int)reader["IdHotelCity"],
                            Name = (string)reader["NameHotelCity"],
                            RegisterDate = (DateTime)reader["RegisterHotelCity"]
                        },
                        RegisterDate = (DateTime)reader["RegisterHotelAddress"]
                    },
                    RegisterDate = (DateTime)reader["RegisterHotel"]
                };
                package.Client = new Client()
                {

                    Id = (int)reader["IdClient"],
                    Address = new Address()
                    {
                        Id = (int)reader["IdClientAddress"],
                        Street = (string)reader["StreetClientAddress"],
                        Number = (int)reader["NumberClientAddress"],
                        District = (string)reader["DistrictClientAddress"],
                        ZipCode = (string)reader["ZipClientAddress"],
                        Complement = (string)reader["ComplementClientAddress"],
                        City = new City()
                        {
                            Id = (int)reader["IdClientCity"],
                            Name = (string)reader["NameClientCity"],
                            RegisterDate = (DateTime)reader["RegisterClientCity"]
                        },
                        RegisterDate = (DateTime)reader["RegisterClientAddress"]
                    },
                    Name = (string)reader["NameClient"],
                    Phone = (string)reader["PhoneClient"],
                    RegisterDate = (DateTime)reader["RegisterClient"]
                };
                package.Ticket = new Ticket()
                {
                    Id = (int)reader["TicketId"],
                    Departure = new Address()
                    {
                        Id = (int)reader["IdAddressDeparture"],
                        Street = (string)reader["StreetAddressDeparture"],
                        Number = (int)reader["NumberAddressDeparture"],
                        District = (string)reader["DistrictAddressDeparture"],
                        ZipCode = (string)reader["ZipAddressDeparture"],
                        Complement = (string)reader["ComplementAddressDeparture"],
                        City = new City()
                        {
                            Id = (int)reader["IdCityDeparture"],
                            Name = (string)reader["NameCityDeparture"],
                            RegisterDate = (DateTime)reader["RegisterCityDeparture"]
                        },
                        RegisterDate = (DateTime)reader["RegisterAddressDeparture"]
                    },
                    Arrival = new Address()
                    {
                        Id = (int)reader["IdAddressArrival"],
                        Street = (string)reader["StreetAddressArrival"],
                        Number = (int)reader["NumberAddressArrival"],
                        District = (string)reader["DistrictAddressArrival"],
                        ZipCode = (string)reader["ZipAddressArrival"],
                        Complement = (string)reader["ComplementAddressArrival"],
                        City = new City()
                        {
                            Id = (int)reader["IdCityArrival"],
                            Name = (string)reader["NameCityArrival"],
                            RegisterDate = (DateTime)reader["RegisterCityArrival"]
                        },
                        RegisterDate = (DateTime)reader["RegisterAddressArrival"]
                    },
                    Value = (decimal)reader["ValueTicket"],
                    RegisterDate = (DateTime)reader["RegisterTicket"]
                };
                package.RegisterDate = (DateTime)reader["RegisterPackage"];

                packages.Add(package);
            }

            return packages;
        }

    }
}

