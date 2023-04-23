using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Repositories.Interfaces
{
    internal interface ITicketRepository
    {
        int Insert(Ticket ticket, string INSERT);

        bool Update(Ticket ticket, string UPDATE);

        bool Delete(int id, string DELETE);

        List<Ticket> FindAll(string GETALL);
    }
}
