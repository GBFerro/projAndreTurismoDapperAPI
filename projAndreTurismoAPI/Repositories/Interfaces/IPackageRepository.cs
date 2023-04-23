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
        int Insert(Package package, string INSERT);

        bool Update(Package package, string UPDATE);

        bool Delete(int id, string DELETE);

        List<Package> FindAll(string GETALL);
    }
}
