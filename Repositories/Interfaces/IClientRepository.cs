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
        int Insert(Client client, string INSERT);

        bool Update(Client client, string UPDATE);

        bool Delete(int id, string DELETE);

        List<Client> FindAll(string GETALL);
    }
}
