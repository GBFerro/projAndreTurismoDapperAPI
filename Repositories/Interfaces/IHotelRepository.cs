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
        int Insert(Hotel hotel, string INSERT);

        bool Update(Hotel hotel, string UPDATE);

        bool Delete(int id, string DELETE);

        List<Hotel> FindAll(string GETALL);
    }
}
