using System.Collections.Generic;
using System.Runtime.InteropServices;
using BE_ABC.Models.CommonModels;
using BE_ABC.Models.DTO.Request;
using BE_ABC.Models.ErdModels;
using BE_ABC.Services;
using Microsoft.AspNetCore.Mvc;

namespace BE_ABC.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class EventController : Controller
    {
        EventService eventService;
        public EventController(EventService _eventService)
        {
            eventService = _eventService;
        }
        [HttpPost]
        [Route("get")]
        public async Task<IActionResult> getBylist(List<int> uid)
        {
            try
            {
                List<Event> list = new List<Event>();
                foreach (var req in uid)
                {
                    var find = await eventService.FindByIdAsync(req);
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
                return Ok(eventService.getAll(pagination));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> insert(List<EventCreateReq> events)
        {
            try
            {
                var listInsertedEvent = new List<Event>();
                foreach (var req in events)
                {
                    var entity = await eventService.insert(req);
                    listInsertedEvent.Add(entity);
                }

                return Ok(listInsertedEvent);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("")]
        public async Task<IActionResult> update(List<EventReq> events)
        {
            try
            {
                foreach (var req in events)
                {
                    var (check, err) = await eventService.checkUpdate(req);
                    if (!check)
                    {
                        return BadRequest(err);
                    }
                }

                foreach (var req in events)
                {
                    await eventService.update(req);
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
                    var find = await eventService.FindByIdAsync(req);
                    if (find != null)
                        await eventService.DeleteAsync(find);
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
