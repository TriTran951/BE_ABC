using BE_ABC.Models.CommonModels;
using BE_ABC.Services;
using Microsoft.AspNetCore.Mvc;

namespace BE_ABC.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class UserController : Controller
    {
        UserService userService;
        public UserController(UserService _userService) 
        { 
            userService = _userService;
        }
        [HttpPost]
        public IActionResult getAll(Pagination pagination)
        {
            try
            {
                return Ok(userService.getAll(pagination)); 
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
