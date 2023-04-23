using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Models;
using Repositories.Interfaces;

namespace Repositories
{
    public class TicketRepository : ConnectionDBRepository, ITicketRepository
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

        public List<Ticket> FindAll(string GETALL)
        {
            List<Ticket> list = new List<Ticket>();
            using (Conn)
            {
                Conn.Open();
                list = (List<Ticket>)Conn.Query<Ticket, Address, City, Address, City, Ticket>(GETALL, (ticket, departure, cityD, arrival, cityA) => 
                { ticket.Departure = departure; ticket.Departure.City = cityD; ticket.Arrival = arrival; ticket.Arrival.City = cityA; return ticket; });
            }
            return list;
        }

        public int Insert(Ticket ticket, string INSERT)
        {
            try
            {
                int id;
                using (Conn)
                {
                    Conn.Open();
                    id = Conn.ExecuteScalar<int>(INSERT, new
                    {
                        @Departure = ticket.Departure.Id,
                        @Arrival = ticket.Arrival.Id,
                        @RegisterDate = ticket.RegisterDate,
                        @Value = ticket.Value
                    });
                }
                return id;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Update(Ticket ticket, string UPDATE)
        {
            try
            {
                using (Conn)
                {
                    Conn.Open();
                    Conn.Execute(UPDATE, ticket);
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
