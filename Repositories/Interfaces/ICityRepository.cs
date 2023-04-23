using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Repositories.Interfaces
{
    internal interface ICityRepository
    {
        int Insert(City city, string INSERT);

        bool Update(City city, string UPDATE);

        bool Delete(int id, string DELETE);

        List<City> FindAll(string GETALL);
    }
}
