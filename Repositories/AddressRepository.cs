using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Models;
using Repositories.Interfaces;

namespace Repositories
{
    public class AddressRepository : ConnectionDBRepository, IAddressRepository
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

        public List<Address> FindAll(string GETALL)
        {
            List<Address> list = new List<Address>();
            using (Conn)
            {
                Conn.Open();
                list = (List<Address>) Conn.Query<Address, City, Address>(GETALL, (address, city) => { address.City = city; return address; });
            }
            return list;
        }

        public int Insert(Address address, string INSERT)
        {
            try
            {
                int id;
                using (Conn)
                {
                    Conn.Open();
                    id = Conn.ExecuteScalar<int>(INSERT, new {@Street = address.Street, @Number = address.Number, @District = address.District,
                                                            @ZipCode = address.ZipCode, @Complement = address.Complement, @RegisterDate = address.RegisterDate,
                                                            @IdCity = address.City.Id});
                }
                return id;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Update(Address address, string UPDATE)
        {
            try
            {
                using (Conn)
                {
                    Conn.Open();
                    Conn.Execute(UPDATE, address);
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
