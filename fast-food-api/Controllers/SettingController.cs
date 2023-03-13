using fast_food;
using Microsoft.AspNetCore.Mvc;

namespace fast_food_api.Controllers
{
    [Route("api/[controller]"), ApiController]
    public class SettingController : ControllerBase
    {
        private readonly HelperSQL _helperSql;

        public SettingController()
        {
            _helperSql = new HelperSQL();
            _helperSql.CreateConnection();
        }

        [HttpPost, Route("initialize")]
        public IActionResult Initialize()
        {
            try
            {
                if (_helperSql.CreateTable())
                {
                    return Ok();
                }
            }
            catch (Exception)
            {

                throw;
            }
           

            return Problem("There was an error managing your request");
        }
    }
}
