using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using Models;

namespace Services
{
    public class TicketService
    {
        readonly string strConn = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;AttachDbFileName=C:\Users\adm\source\repos\projAndreTurismo\Database\AndreTurismo.mdf";
        readonly SqlConnection conn;

        public TicketService()
        {
            conn = new SqlConnection(strConn);
            conn.Open();
        }

        public Ticket Insert(Ticket ticket, string INSERT)
        {
            try
            {
                SqlCommand commandInsert = new SqlCommand(INSERT, conn);

                commandInsert.Parameters.Add(new SqlParameter("@Departure", ticket.Departure.Id));
                commandInsert.Parameters.Add(new SqlParameter("@Arrival", ticket.Arrival.Id));
                //commandInsert.Parameters.Add(new SqlParameter("@IdClient", ticket.Client.Id));
                commandInsert.Parameters.Add(new SqlParameter("@RegisterDate", ticket.RegisterDate));
                commandInsert.Parameters.Add(new SqlParameter("@Value", ticket.Value));

                int id = (int) commandInsert.ExecuteScalar();
                ticket.Id = id;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }

            return ticket;
        }

        public bool Update(Ticket ticket, string UPDATE)
        {
            bool status = false;

            try
            {
                SqlCommand commandUpdate = new SqlCommand(UPDATE, conn);

                commandUpdate.Parameters.Add(new SqlParameter("@Id", ticket.Id));
                commandUpdate.Parameters.Add(new SqlParameter("@Value", ticket.Value));

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

        public List<Ticket> FindAll(string GETALL)
        {
            List<Ticket> tickets = new List<Ticket>();

            SqlCommand commandSelect = new SqlCommand(GETALL, conn);

            SqlDataReader reader = commandSelect.ExecuteReader();

            while (reader.Read())
            {
                Ticket ticket = new Ticket();

                ticket.Id = (int)reader["TicketId"];
                ticket.Departure = new Address()
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
                };
                ticket.Arrival = new Address()
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
                };
                ticket.Value = (decimal)reader["ValueTicket"];
                ticket.RegisterDate = (DateTime)reader["RegisterTicket"];

                tickets.Add(ticket);
            }
            return tickets;
        }
    }
}
