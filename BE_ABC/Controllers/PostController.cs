﻿using BE_ABC.Models.CommonModels;
using BE_ABC.Models.DTO.insertReq;
using BE_ABC.Models.DTO.Request;
using BE_ABC.Models.ErdModel;
using BE_ABC.Models.ErdModels;
using BE_ABC.Services;
using Microsoft.AspNetCore.Mvc;

namespace BE_ABC.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class PostController : Controller
    {
        private readonly PostService postService;
        private readonly UserService userService;
        public PostController(PostService postService, UserService userService)
        {
            this.postService = postService;
            this.userService = userService; 
        }
        [HttpPost]
        [Route("getAll")]
        public IActionResult getAll(Pagination pagination)
        {
            try
            {
                return Ok(postService.getAll(pagination));
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
                List<Post> list = new List<Post>();
                foreach (var req in uid)
                {
                    var find = await postService.get(req);
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
        public async Task<IActionResult> insert(List<PostReq> ptReq)
        {
            try
            {
                foreach (var req in ptReq)
                {
                    var (check, err) = await postService.checkInsertPost(req);
                    if (!check)
                    {
                        return BadRequest(err);
                    }
                }

                var listInsertedUser = new List<Post>();
                foreach (var req in ptReq)
                {
                    var entity = await postService.insert(req);
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
        public async Task<IActionResult> update(List<PostUpdate> pt)
        {
            try
            {
                foreach (var req in pt)
                {
                    await postService.checkUpdate(req);
                }


                foreach (var req in pt)
                {
                    await postService.update(req);
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
                    var find = await postService.FindByIdAsync(req);
                    if (find != null)
                        await postService.DeleteAsync(find);
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("getAllByUid")]
        public async Task<IActionResult> getBylist(string uid)
        {
            try
            {
                var findUser = await userService.FindByIdAsync(uid);

                if (findUser == null)
                {
                    return BadRequest("User not found");
                }

                List<Post> list = await postService.getByUid(uid);

                return Ok(list);
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
                return Ok(postService.search(req));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
