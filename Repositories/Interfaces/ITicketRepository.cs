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
        bool Insert(Ticket ticket);

        bool Update(Ticket ticket);

        bool Delete(int id);

        List<Address> FindAll();
    }
}
