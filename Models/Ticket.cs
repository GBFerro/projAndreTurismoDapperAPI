using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public Address Departure { get; set; }
        public Address Arrival { get; set; }
        //public Client Client { get; set; }
        public decimal Value { get; set; }
        public DateTime RegisterDate { get; set; }

        public override string ToString()
        {
            //return Newtonsoft.Json.JsonConvert.SerializeObject(this);
            return $"\n\tId: {this.Id}\n\tArrival: {this.Arrival}\n\tDeparture: {this.Departure}\n\tRegister Date: {this.RegisterDate}\n\tValue: {this.Value}";
        }
    }
}
