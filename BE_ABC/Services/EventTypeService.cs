using BE_ABC.Models.CommonModels;
using BE_ABC.Models.Context;
using BE_ABC.Models.ErdModel;
using BE_ABC.Models.ErdModels;
using BE_ABC.Services.GenericService;
using Microsoft.EntityFrameworkCore;

namespace BE_ABC.Services
{
    public class EventTypeService : GenericService<EventType>
    {
        public EventTypeService(MyDbContext context) : base(context)
        {
        }

        internal async Task<EventType?> get(string req)
        {
            var user = db.EventType
            .Where(u => u.id == req)
            .FirstOrDefault();

            return user;
        }

        internal List<EventType> getAll(Pagination page)
        {
            var user = db.EventType
            .Skip((page.page - 1) * page.limit).Take(page.limit).ToList();

            return user;
        }
    }
}
