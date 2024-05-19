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
    public class PostTypeController : Controller
    {
        private readonly  PostTypeService postTypeService;
        public PostTypeController(PostTypeService postTypeService)
        {
            this.postTypeService = postTypeService;
        }
        [HttpPost]
        [Route("getAll")]
        public IActionResult getAll(Pagination pagination)
        {
            try
            {
                return Ok(postTypeService.getAll(pagination));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> insert(List<PostTypeReq> ptReq)
        {
            try
            {
                //foreach (var req in ptReq)
                //{
                //    var (check, err) = await postTypeService.checkTypeInsert(req);
                //    if (!check)
                //    {
                //        return BadRequest(err);
                //    }
                //}

                var listInsertedUser = new List<PostType>();
                foreach (var req in ptReq)
                {
                    var entity = await postTypeService.insert(req);
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
        public async Task<IActionResult> update(List<PostType> pt)
        {
            try
            {
                //foreach (var req in user)
                //{
                //    var (check, err) = await postTypeService.checkUpdate(req);
                //    if (!check)
                //    {
                //        return BadRequest(err);
                //    }
                //}

                foreach (var req in pt)
                {
                    await postTypeService.update(req);
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
                    var find = await postTypeService.FindByIdAsync(req);
                    if (find != null)
                        await postTypeService.DeleteAsync(find);
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
