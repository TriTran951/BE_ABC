using BE_ABC.Models.CommonModels;
using BE_ABC.Models.DTO.Request;
using BE_ABC.Models.ErdModel;
using BE_ABC.Services;
using Microsoft.AspNetCore.Mvc;

namespace BE_ABC.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ResourceController : Controller
    {
        private readonly ResourceService ResourceService;
        public ResourceController(ResourceService ResourceService)
        {
            this.ResourceService = ResourceService;
        }
        [HttpPost]
        [Route("getAll")]
        public IActionResult getAll(Pagination pagination)
        {
            try
            {
                return Ok(ResourceService.getAll(pagination));
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
                List<Resource> list = new List<Resource>();
                foreach (var req in uid)
                {
                    var find = await ResourceService.get(req);
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
        public async Task<IActionResult> insert(List<ResourceCreateReq> ptReq)
        {
            try
            {
                foreach (var req in ptReq)
                {
                    var (check, err) = await ResourceService.checkInsert(req);
                    if (!check)
                    {
                        return BadRequest(err);
                    }
                }

                var listInsertedUser = new List<Resource>();
                foreach (var req in ptReq)
                {
                    var entity = await ResourceService.insert(req);
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
        public async Task<IActionResult> update(List<ResourceReq> pt)
        {
            try
            {
                foreach (var req in pt)
                {
                    var (check, err) = await ResourceService.checkUpdate(req);
                    if (!check)
                    {
                        return BadRequest(err);
                    }
                }

                foreach (var req in pt)
                {
                    await ResourceService.update(req);
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
                    var find = await ResourceService.FindByIdAsync(req);
                    if (find != null)
                        await ResourceService.DeleteAsync(find);
                    else
                        return BadRequest($"Resource not found {req}");

                }

                return Ok("ok");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [Route("getResourceByType")]
        public async Task<IActionResult> getResourceByType(string resourceId)
        {
            try
            {

                var (data, err) = await ResourceService.getResourceByType(resourceId);

                if (data == null)
                {
                    return BadRequest(err);
                }

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }

}
