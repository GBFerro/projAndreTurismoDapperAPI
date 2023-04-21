using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Repositories.Interfaces;

namespace Repositories
{
    internal class AddressRepository : IAddressRepository
    {
        private string Conn { get; set; }

        public AddressRepository() 
        {
            Conn = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Address> FindAll()
        {
            throw new NotImplementedException();
        }

        public bool Insert(Address address)
        {
            throw new NotImplementedException();
        }

        public bool Update(Address address)
        {
            throw new NotImplementedException();
        }
    }
}
