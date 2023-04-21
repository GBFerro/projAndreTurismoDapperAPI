using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Repositories.Interfaces
{
    internal interface IClientRepository
    {
        bool Insert(Client client);

        bool Update(Client client);

        bool Delete(int id);

        List<Address> FindAll();
    }
}
