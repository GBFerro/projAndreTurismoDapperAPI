using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class ConnectionDBRepository
    {
        protected SqlConnection Conn { get; set; }

        public ConnectionDBRepository()
        {
            Conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
        }
    }
}
