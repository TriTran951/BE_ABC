using BE_ABC.Models.CommonModels;
using BE_ABC.Models.DTO.Request;
using BE_ABC.Models.ErdModel;
using BE_ABC.Models.ErdModels;
using BE_ABC.Services;
using Microsoft.AspNetCore.Mvc;

namespace BE_ABC.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ResourceUsingController : Controller
    {
        private readonly ResourceUsingService ResourceUsingService;
        public ResourceUsingController(ResourceUsingService ResourceUsingService)
        {
            this.ResourceUsingService = ResourceUsingService;
        }
        [HttpPost]
        [Route("getAll")]
        public IActionResult getAll(Pagination pagination)
        {
            try
            {
                return Ok(ResourceUsingService.getAll(pagination));
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
                List<ResourceUsing> list = new List<ResourceUsing>();
                foreach (var req in uid)
                {
                    var find = await ResourceUsingService.FindByIdAsync(req);
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
        public async Task<IActionResult> insert(List<ResourceUsingReq> ptReq)
        {
            try
            {
                foreach (var req in ptReq)
                {
                    var (check, err) = await ResourceUsingService.checkInsert(req);
                    if (!check)
                    {
                        return BadRequest(err);
                    }
                }

                var listInsertedUser = new List<ResourceUsing>();
                foreach (var req in ptReq)
                {
                    var entity = await ResourceUsingService.insert(req);
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
        public async Task<IActionResult> update(List<ResourceUsing> pt)
        {
            try
            {
                foreach (var req in pt)
                {
                    var (check, err) = await ResourceUsingService.checkUpdate(req);
                    if (!check)
                    {
                        return BadRequest(err);
                    }
                }

                foreach (var req in pt)
                {
                    await ResourceUsingService.update(req);
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
        public async Task<IActionResult> hardDelete(List<int> uid)
        {
            try
            {
                foreach (var req in uid)
                {
                    var find = await ResourceUsingService.FindByIdAsync(req);
                    if (find != null)
                        await ResourceUsingService.DeleteAsync(find);
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
    }
}
