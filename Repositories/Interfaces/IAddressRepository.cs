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
        bool Insert(Address address);

        bool Update(Address address);

        bool Delete(int id);

        List<Address> FindAll();
    }
}
