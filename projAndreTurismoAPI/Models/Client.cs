using System.Net;

namespace Models
{
    public class Client
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Phone { get; set; }
        public Address Address { get; set; }
        public DateTime RegisterDate { get; set; }

        public override string ToString()
        {
            //return Newtonsoft.Json.JsonConvert.SerializeObject(this);
            return $"\n\tId: {this.Id}\n\tName: {this.Name}\n\tPhone: {this.Phone}\n\tAddress: {this.Address}\n\tRegister Date: {this.RegisterDate}";
        }
    }
}