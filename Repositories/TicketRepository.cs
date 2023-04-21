using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Repositories.Interfaces;

namespace Repositories
{
    internal class TicketRepository : ITicketRepository
    {
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Address> FindAll()
        {
            throw new NotImplementedException();
        }

        public bool Insert(Ticket ticket)
        {
            throw new NotImplementedException();
        }

        public bool Update(Ticket ticket)
        {
            throw new NotImplementedException();
        }
    }
}
