using BE_ABC.Models.CommonModels;
using BE_ABC.Models.DTO.insertReq;
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
        [Route("get")]
        public async Task<IActionResult> getBylist(List<string> uid)
        {
            try
            {
                List<User> list = new List<User> ();
               foreach (var req in uid)
                {
                    var find = await userService.get(req);
                    if (find != null)
                    {
                        list.Add(find);
                    }
                   
                }

                return Ok(list);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
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
        public async Task<IActionResult> insert(List<UserReq> user)
        {
            try
            {
                foreach(var req in user)
                {
                    var (check, err) = await userService.checkUserInsert(req);
                    if (!check)
                    {
                        return BadRequest(err);
                    }
                }

                var listInsertedUser = new List<User>();
                foreach(var req in user)
                {
                    var entity = await userService.insert(req);
                    listInsertedUser.Add(entity);
                }
               
                return Ok(listInsertedUser);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        [Route("")]
        public async Task<IActionResult> update(List<UserReq> user)
        {
            try
            {
                foreach (var req in user)
                {
                    var (check, err) = await userService.checkUpdate(req);
                    if (!check)
                    {
                        return BadRequest(err);
                    }
                }

                foreach (var req in user)
                {
                    await userService.update(req);
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        [Route("")]
        public async Task<IActionResult> hardDelete(List<string> uid)
        {
            try
            {
                foreach(var req in uid)
                {
                    var find = await userService.FindByIdAsync(req);
                    if(find!= null)
                        await userService.DeleteAsync(find);
                }    

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("search")]
        public IActionResult search(SearchReq req)
        {
            try
            {
                return Ok(userService.search(req));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
