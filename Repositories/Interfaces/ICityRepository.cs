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
        bool Insert(City city);

        bool Update(City city);

        bool Delete(int id);

        List<City> FindAll();
    }
}
