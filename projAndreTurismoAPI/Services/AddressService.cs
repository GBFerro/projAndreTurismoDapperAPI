using System.Collections.Generic;
using System.Data.SqlClient;
using System.Net;
using Models;
using Repositories;

namespace Services
{
    public class AddressService
    {
        public int Insert(Address address, string INSERT)
        {
            return new AddressRepository().Insert(address, INSERT);
        }


        public bool Update(Address address, string UPDATE)
        {
            return new AddressRepository().Update(address, UPDATE);
        }

        public bool Delete(int id, string DELETE)
        {
            return new AddressRepository().Delete(id, DELETE);
        }

        public List<Address> FindAll(string GETALL)
        {
            return new AddressRepository().FindAll(GETALL);
        }
    }
}