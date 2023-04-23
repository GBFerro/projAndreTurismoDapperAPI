using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Models;
using Repositories.Interfaces;

namespace Repositories
{
    public class HotelRepository : ConnectionDBRepository, IHotelRepository
    {
        public bool Delete(int id, string DELETE)
        {
            try
            {
                using (Conn)
                {
                    Conn.Execute(DELETE, new { Id = id });
                }

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Hotel> FindAll(string GETALL)
        {
            List<Hotel> list = new List<Hotel>();
            using (Conn)
            {
                Conn.Open();
                list = (List<Hotel>)Conn.Query<Hotel, Address, City, Hotel>(GETALL, (hotel, address, city) => { hotel.Address = address; hotel.Address.City = city; return hotel; });
            }
            return list;
        }

        public int Insert(Hotel hotel, string INSERT)
        {
            try
            {
                int id;
                using (Conn)
                {
                    Conn.Open();
                    id = Conn.ExecuteScalar<int>(INSERT, new
                    {
                        @Name = hotel.Name,
                        @Value = hotel.Value,
                        @RegisterDate = hotel.RegisterDate,
                        @IdAddress = hotel.Address.Id
                    });
                }
                return id;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Update(Hotel hotel, string UPDATE)
        {
            try
            {
                using (Conn)
                {
                    Conn.Open();
                    Conn.Execute(UPDATE, hotel);
                }
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
