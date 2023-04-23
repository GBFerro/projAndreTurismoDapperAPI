using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using Models;
using Repositories;

namespace Services
{
    public class PackageService
    {
        public int Insert(Package package, string INSERT)
        {
            return new PackageRepository().Insert(package, INSERT);
        }

        public bool Update(Package package, string UPDATE)
        {
            return new PackageRepository().Update(package, UPDATE);
        }

        public bool Delete(int id, string DELETE)
        {
            return new PackageRepository().Delete(id, DELETE);
        }

        public List<Package> FindAll(string GETALL)
        {
            return new PackageRepository().FindAll(GETALL);
        }
    }
}

