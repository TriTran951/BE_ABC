using BE_ABC.Models.CommonModels;
using BE_ABC.Models.DTO.Request;
using BE_ABC.Models.ErdModels;
using BE_ABC.Services;
using Microsoft.AspNetCore.Mvc;

namespace BE_ABC.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class RequestTypeController : Controller
    {
        private readonly RequestTypeService RequestTypeService;
        public RequestTypeController(RequestTypeService RequestTypeService)
        {
            this.RequestTypeService = RequestTypeService;
        }
        [HttpPost]
        [Route("getAll")]
        public IActionResult getAll(Pagination pagination)
        {
            try
            {
                return Ok(RequestTypeService.getAll(pagination));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [Route("get")]
        public async Task<IActionResult> getBylist(List<string> id)
        {
            try
            {
                List<RequestType> list = new List<RequestType>();
                foreach (var req in id)
                {
                    var find = await RequestTypeService.get(req);
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
        public async Task<IActionResult> insert(List<RequestTypeReq> ptReq)
        {
            try
            {
                foreach (var req in ptReq)
                {
                    var (check, err) = await RequestTypeService.checkInsert(req);
                    if (!check)
                    {
                        return BadRequest(err);
                    }
                }

                var listInsertedUser = new List<RequestType>();
                foreach (var req in ptReq)
                {
                    var entity = await RequestTypeService.insert(req);
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
        public async Task<IActionResult> update(List<RequestTypeReq> pt)
        {
            try
            {
                foreach (var req in pt)
                {
                    await RequestTypeService.update(req);
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
                foreach (var req in uid)
                {
                    var find = await RequestTypeService.FindByIdAsync(req);
                    if (find != null)
                        await RequestTypeService.DeleteAsync(find);
                }

                return Ok("ok");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
