using BE_ABC.Models.CommonModels;
using BE_ABC.Models.DTO.Req;
using BE_ABC.Models.ErdModel;
using BE_ABC.Models.ErdModels;
using BE_ABC.Services;
using Microsoft.AspNetCore.Mvc;

namespace BE_ABC.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class RequestController : Controller
    {
        private readonly RequestService RequestService;
        private readonly UserService UserService;
        public RequestController(RequestService RequestService, UserService UserService)
        {
            this.RequestService = RequestService;
            this.UserService = UserService;
        }
        [HttpPost]
        [Route("getAll")]
        public IActionResult getAll([FromBody] Pagination pagination)
        {
            try
            {
                return Ok(RequestService.getAll(pagination));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [Route("get")]
        public async Task<IActionResult> getBylist(List<int> uid)
        {
            try
            {
                List<Request> list = new List<Request>();
                foreach (var req in uid)
                {
                    var find = await RequestService.get(req);
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
        [Route("")]
        public async Task<IActionResult> insert(List<RequestCreateReq> ptReq)
        {
            try
            {
                foreach (var req in ptReq)
                {
                    var (check, err) = await RequestService.checkInsertPost(req);
                    if (!check)
                    {
                        return BadRequest(err);
                    }
                }

                var listInsertedUser = new List<Request>();
                foreach (var req in ptReq)
                {
                    var entity = await RequestService.insert(req);
                    listInsertedUser.Add(entity);
                }

                return Ok(listInsertedUser);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "intentional server error.");
            }
        }
        [HttpPut]
        [Route("")]
        public async Task<IActionResult> update(List<RequestReq> pt)
        {
            try
            {
                foreach (var req in pt)
                {
                    var (check,err) = await RequestService.checkUpdate(req);

                    if(!check)
                        return BadRequest(err);
                }


                foreach (var req in pt)
                {
                    await RequestService.update(req);
                }

                return Ok("ok");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        [Route("")]
        public async Task<IActionResult> hardDelete(List<int> id)
        {
            try
            {
                foreach (var req in id)
                {
                    var find = await RequestService.FindByIdAsync(req);
                    if (find != null)
                        await RequestService.DeleteAsync(find);
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("getAllByRequesterUid")]
        public async Task<IActionResult> getBylist(string uid)
        {
            try
            {
                var findUser = await UserService.FindByIdAsync(uid);

                if (findUser == null)
                {
                    return BadRequest("User not found");
                }

                List<Request> list = await RequestService.getByUid(uid);

                return Ok(list);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
