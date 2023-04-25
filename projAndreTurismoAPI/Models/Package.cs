using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Package
    {
        public int Id { get; set; }
        public decimal Value { get; set; }
        public DateTime RegisterDate { get; set; }
        public Hotel Hotel { get; set; }
        public Ticket Ticket { get; set; }
        public Client Client { get; set; }

        public override string ToString()
        {
            //return Newtonsoft.Json.JsonConvert.SerializeObject(this);
            return $"Id: {this.Id}\nHotel: {this.Hotel}\nTicket: {this.Ticket}\nClient: {this.Client}\nRegister Date: {this.RegisterDate}\nValue: {this.Value}";
        }
    }
}
