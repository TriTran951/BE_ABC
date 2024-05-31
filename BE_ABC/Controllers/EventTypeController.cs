using BE_ABC.Models.CommonModels;
using BE_ABC.Models.ErdModel;
using BE_ABC.Models.ErdModels;
using BE_ABC.Services;
using Microsoft.AspNetCore.Mvc;

namespace BE_ABC.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class EventTypeController : Controller
    {
        private readonly EventTypeService EventTypeService;
        public EventTypeController(EventTypeService EventTypeService)
        {
            this.EventTypeService = EventTypeService;
        }
        [HttpPost]
        [Route("getAll")]
        public IActionResult getAll(Pagination pagination)
        {
            try
            {
                return Ok(EventTypeService.getAll(pagination));
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
                List<EventType> list = new List<EventType>();
                foreach (var req in uid)
                {
                    var find = await EventTypeService.get(req);
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
    }
}
