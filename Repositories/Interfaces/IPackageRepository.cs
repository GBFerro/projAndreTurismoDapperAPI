using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Repositories.Interfaces
{
    internal interface IPackageRepository
    {
        bool Insert(Package package);

        bool Update(Package package);

        bool Delete(int id);

        List<Address> FindAll();
    }
}
