using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services;

namespace projAndreTurismoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        #region Constants
        public readonly static string INSERT = "insert into City (Name, RegisterDate) " +
            "values (@Name, @RegisterDate); Select cast(scope_Identity() as int)";

        public readonly static string GETALL = "select Id , Name, RegisterDate from City";

        public readonly static string DELETE = "delete from City where Id = @Id";

        public readonly static string UPDATE = "update City set Name = @Name where Id = @Id";

        private CityService _cityService;
        #endregion

        public CityController()
        {
            _cityService = new CityService();
        }

        [HttpPost(Name = "Insert City")]
        public int Insert(City city)
        {
            int status = 0;
            try
            {

                status = _cityService.Insert(city, INSERT); ;
            }
            catch (Exception)
            {
                status = 0;
                throw;
            }

            return status;
        }

        [HttpPut(Name = "Update City")]
        public bool Update(City city)
        {
            return _cityService.Update(city, UPDATE);
        }

        [HttpDelete(Name = "Delete City By {id}")]
        public bool Delete(int id)
        {
            return _cityService.Delete(id, DELETE);
        }

        [HttpGet(Name = "List Cities")]
        public List<City> FindAll()
        {
            return _cityService.FindAll(GETALL);
        }
    }
}
