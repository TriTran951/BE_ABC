using BE_ABC.ConstValue;
using BE_ABC.Models.CommonModels;
using BE_ABC.Models.Context;
using BE_ABC.Models.DTO.Request;
using BE_ABC.Models.ErdModels;
using BE_ABC.Services.GenericService;
using BE_ABC.Util;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.Linq;

namespace BE_ABC.Services
{
    public class EventService : GenericService<Event>
    {
        public EventService(MyDbContext context) : base(context)
        {
        }

        public async Task<Event> getById(int id)
        {
            var item = await db.Set<Event>()
                          .Include(e => e.EventType)
                          .Include(e => e.User)
                          .FirstOrDefaultAsync(e => e.id == id);  // Use FirstOrDefaultAsync for async operation

            return item;
        }

        public List<Event> getAll(Pagination page)
        {
            // Ensure page number is not less than 1
            if (page.page < 1)
                page.page = 1;

            // Ensure limit is not less than 1
            if (page.limit < 1)
                page.limit = 1;

            var events = db.Event
                 .Include(e => e.EventType) 
                 .Include(e => e.User)
                 .Skip((page.page - 1) * page.limit)
                 .Take(page.limit)
                 .ToList();
            return events;
        }

        public async Task update(EventReq item)
        {
            var findEvent = await db.Event.FindAsync(item.id);
            if (findEvent != null)
            {
                findEvent.id = item.id;
                findEvent.name = item.name;
                findEvent.eventTypeId = item.eventTypeId;
                findEvent.reporterUid = item.reporterUid;
                findEvent.resouceUsingId = item.resouceUsingId;
                findEvent.postsId = item.postsId;
                findEvent.paticipantsUid = item.paticipantsUid;
                findEvent.permissionIdToCRUDPost = item.permissionIdToCRUDPost;
                findEvent.description = item.description;
                findEvent.startAt = item.startAt;
                findEvent.endAt = item.endAt;
                findEvent.updateAt = DateTimeExtensions.getUxixTimeNow();
                findEvent.status = item.status;

                db.Set<Event>().Update(findEvent);

                await db.SaveChangesAsync();
            }
        }
        public async Task<(bool, string)> checkUpdate(EventReq item)
        {
            var findEvent = await db.Event.FindAsync(item.id);

            if (findEvent == null)
            {
                return (false, "Event not found");
            }

            return (true, "Ok");
        }
        public async Task<Event>? insert(EventCreateReq item)
        {
            Event newEvent = new Event();
            newEvent.name = item.name;
            newEvent.eventTypeId = item.eventTypeId;
            newEvent.reporterUid = item.reporterUid;
            newEvent.resouceUsingId = item.resouceUsingId;
            newEvent.postsId = item.postsId;
            newEvent.paticipantsUid = item.paticipantsUid;
            newEvent.permissionIdToCRUDPost = item.permissionIdToCRUDPost;
            newEvent.description = item.description;
            newEvent.startAt = item.startAt;
            newEvent.endAt = item.endAt;
            newEvent.createAt = DateTimeExtensions.getUxixTimeNow();
            newEvent.updateAt = DateTimeExtensions.getUxixTimeNow();
            newEvent.status = item.status;

            db.Attach(newEvent);
            var entityEntry = await db.Set<Event>().AddAsync(newEvent);

            await db.SaveChangesAsync();

            return entityEntry.Entity;
        }
    }
}
