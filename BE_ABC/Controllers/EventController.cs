using BE_ABC.Models.CommonModels;
using BE_ABC.Models.DTO.insertReq;
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
        private readonly UserService userService;
        public EventController(EventService _eventService, UserService userService)
        {
            eventService = _eventService;
            this.userService = userService;
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
                    var find = await eventService.getById(req);
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

                return Ok("Success");
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
                    bool check = await eventService.checkDelete(req);
                    if (!check)
                        return BadRequest($"Event id={uid} in use");
                }

                foreach (var req in uid)
                {
                    var find = await eventService.FindByIdAsync(req);
                    if (find != null)
                        await eventService.DeleteAsync(find);
                }

                return Ok("Success");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("search")]
        public async Task<IActionResult> search(SearchReq req)
        {
            try
            {
                return Ok(eventService.search(req));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("today")]
        public async Task<IActionResult> today()
        {
            try
            {
                return Ok(eventService.today());
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

                List<Event> list = await eventService.getListByUid(uid);

                return Ok(list);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
