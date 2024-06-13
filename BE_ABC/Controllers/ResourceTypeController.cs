﻿using BE_ABC.Models.CommonModels;
using BE_ABC.Models.DTO.Request;
using BE_ABC.Models.ErdModels;
using BE_ABC.Services;
using Microsoft.AspNetCore.Mvc;

namespace BE_ABC.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ResourceTypeController : Controller
    {
        private readonly ResourceTypeService ResourceTypeService;
        public ResourceTypeController(ResourceTypeService ResourceTypeService)
        {
            this.ResourceTypeService = ResourceTypeService;
        }
        [HttpPost]
        [Route("getAll")]
        public IActionResult getAll(Pagination pagination)
        {
            try
            {
                return Ok(ResourceTypeService.getAll(pagination));
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
                List<ResourceType> list = new List<ResourceType>();
                foreach (var req in uid)
                {
                    var find = await ResourceTypeService.FindByIdAsync(req);
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
        public async Task<IActionResult> insert(List<ResourceTypeReq> ptReq)
        {
            try
            {
                foreach (var req in ptReq)
                {
                    var (check, err) = await ResourceTypeService.checkInsert(req);
                    if (!check)
                    {
                        return BadRequest(err);
                    }
                }

                var listInsertedUser = new List<ResourceType>();
                foreach (var req in ptReq)
                {
                    var entity = await ResourceTypeService.insert(req);
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
        public async Task<IActionResult> update(List<ResourceTypeReq> pt)
        {
            try
            {
                foreach (var req in pt)
                {
                    var (check, err) = await ResourceTypeService.checkUpdate(req);
                    if (!check)
                    {
                        return BadRequest(err);
                    }
                }

                foreach (var req in pt)
                {
                    await ResourceTypeService.update(req);
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
                    var find = await ResourceTypeService.FindByIdAsync(req);
                    if (find != null)
                        await ResourceTypeService.DeleteAsync(find);
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
