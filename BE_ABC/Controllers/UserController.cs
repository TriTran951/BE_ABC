using BE_ABC.Models.CommonModels;
using BE_ABC.Models.DTO.Request;
using BE_ABC.Models.ErdModels;
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
        [Route("getAll")]
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
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> insert(UserReq user)
        {
            try
            {
                var entity = await userService.insert(user);
                if (entity == null)
                {
                    return BadRequest("fail to create");
                }
                return Ok(entity);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
