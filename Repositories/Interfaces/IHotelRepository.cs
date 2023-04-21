using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Repositories.Interfaces
{
    internal interface IHotelRepository
    {
        bool Insert(Hotel hotel);

        bool Update(Hotel hotel);

        bool Delete(int id);

        List<Address> FindAll();
    }
}
