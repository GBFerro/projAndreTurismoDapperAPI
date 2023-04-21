using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Repositories.Interfaces;

namespace Repositories
{
    internal class PackageRepository : IPackageRepository
    {
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Address> FindAll()
        {
            throw new NotImplementedException();
        }

        public bool Insert(Package package)
        {
            throw new NotImplementedException();
        }

        public bool Update(Package package)
        {
            throw new NotImplementedException();
        }
    }
}
