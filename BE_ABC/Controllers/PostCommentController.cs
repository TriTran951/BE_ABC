using BE_ABC.Models.CommonModels;
using BE_ABC.Models.DTO.Request;
using BE_ABC.Models.ErdModel;
using BE_ABC.Services;
using Microsoft.AspNetCore.Mvc;

namespace BE_ABC.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class PostCommentController : ControllerBase
    {
        private readonly PostCommentService postCommentService;
        public PostCommentController(PostCommentService postCommentController)
        {
            this.postCommentService = postCommentController;
        }
        [HttpPost]
        [Route("getAll")]
        public IActionResult getAll(Pagination pagination)
        {
            try
            {
                return Ok(postCommentService.getAll(pagination));
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
                List<PostComment> list = new List<PostComment>();
                foreach (var req in uid)
                {
                    var find = await postCommentService.FindByIdAsync(req);
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
        public async Task<IActionResult> insert(List<PostCommentCreateReq> ptReq)
        {
            try
            {

                foreach (var req in ptReq)
                {
                    var (check, err) = await postCommentService.checkInsert(req);

                    if (!check)
                    {
                        return BadRequest(err);
                    }
                }

                var listInsertedUser = new List<PostComment>();
                foreach (var req in ptReq)
                {
                    var entity = await postCommentService.insert(req);
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
        public async Task<IActionResult> update(List<PostCommentReq> pt)
        {
            try
            {

                foreach (var req in pt)
                {
                    var (check, err) = await postCommentService.checkUpdate(req);
                }

                foreach (var req in pt)
                {
                    await postCommentService.update(req);
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
        public async Task<IActionResult> hardDelete(List<int> id)
        {
            try
            {
                foreach (var req in id)
                {
                    var find = await postCommentService.FindByIdAsync(req);
                    if (find != null)
                        await postCommentService.DeleteAsync(find);
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
