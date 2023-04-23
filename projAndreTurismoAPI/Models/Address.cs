using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Address
    {
        public int Id { get; set; }
        public string? Street { get; set; }
        public int Number { get; set; }
        public string? District { get; set; }
        public string? ZipCode { get; set; }
        public string? Complement { get; set; }
        public City City { get; set; }
        public DateTime RegisterDate { get; set; }

        public override string ToString()
        {
            //return Newtonsoft.Json.JsonConvert.SerializeObject(this);
            return $"\n\t\tId: {this.Id}\n\t\tStreet: {this.Street}\n\t\tNumber: {this.Number}\n\t\tDistrict: {this.District}\n\t\tZip Cod: {this.ZipCode}\n\t\tComplement: {this.Complement}" +
                $"\n\t\tCity: {this.City}\n\t\tRegister Date: {this.RegisterDate}";
        }
    }
}
