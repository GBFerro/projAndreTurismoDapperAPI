using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using Models;
using Repositories;

namespace Services
{
    public class TicketService
    {
        public int Insert(Ticket ticket, string INSERT)
        {
           return new TicketRepository().Insert(ticket, INSERT);
        }

        public bool Update(Ticket ticket, string UPDATE)
        {
            return new TicketRepository().Update(ticket, UPDATE);
        }

        public bool Delete(int id, string DELETE)
        {
            return new TicketRepository().Delete(id, DELETE);
        }

        public List<Ticket> FindAll(string GETALL)
        {
            return new TicketRepository().FindAll(GETALL);
        }
    }
}
