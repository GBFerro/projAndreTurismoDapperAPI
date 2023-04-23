using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Repositories.Interfaces
{
    internal interface IAddressRepository
    {
        int Insert(Address address, string INSERT);

        bool Update(Address address, string UPDATE);

        bool Delete(int id, string DELETE);

        List<Address> FindAll(string GETALL);
    }
}
