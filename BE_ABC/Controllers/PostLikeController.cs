using BE_ABC.Models.CommonModels;
using BE_ABC.Models.DTO.Request;
using BE_ABC.Models.ErdModel;
using BE_ABC.Services;
using Microsoft.AspNetCore.Mvc;

namespace BE_ABC.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class PostLikeController : Controller
    {
        private readonly PostLikeService PostLikeService;
        public PostLikeController(PostLikeService PostLikeService)
        {
            this.PostLikeService = PostLikeService;
        }
        [HttpPost]
        [Route("getAll")]
        public IActionResult getAll(Pagination pagination)
        {
            try
            {
                return Ok(PostLikeService.getAll(pagination));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [Route("get")]
        public async Task<IActionResult> getBylist(List<string> uid)
        {
            try
            {
                List<PostLike> list = new List<PostLike>();
                foreach (var req in uid)
                {
                    var find = await PostLikeService.FindByIdAsync(req);
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
        public async Task<IActionResult> insert(List<PostLikeCreateReq> ptReq)
        {
            try
            {
                foreach (var req in ptReq)
                {
                    var (check, err) = await PostLikeService.checkInsert(req);
                    if (!check)
                    {
                        return BadRequest(err);
                    }
                }

                var listInsertedUser = new List<PostLike>();
                foreach (var req in ptReq)
                {
                    var entity = await PostLikeService.insert(req);
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
        public async Task<IActionResult> update(List<PostLikeReq> pt)
        {
            try
            {
                foreach (var req in pt)
                {
                    var (check, err) = await PostLikeService.checkUpdate(req);
                    if (!check)
                    {
                        return BadRequest(err);
                    }
                }

                foreach (var req in pt)
                {
                    await PostLikeService.update(req);
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
                    var find = await PostLikeService.FindByIdAsync(req);
                    if (find != null)
                        await PostLikeService.DeleteAsync(find);
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
