using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using Models;
using Repositories;

namespace Services
{
    public class HotelService
    {
        public int Insert(Hotel hotel, string INSERT)
        {
            return new HotelRepository().Insert(hotel, INSERT);
        }

        public bool Update(Hotel hotel, string UPDATE)
        {
            return new HotelRepository().Update(hotel, UPDATE);
        }

        public bool Delete(int id, string DELETE)
        {
            return new HotelRepository().Delete(id, DELETE);
        }

        public List<Hotel> FindAll(string GETALL)
        {
            return new HotelRepository().FindAll(GETALL);
        }
    }
}
