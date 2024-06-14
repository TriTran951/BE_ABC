using BE_ABC.Models.CommonModels;
using BE_ABC.Models.Context;
using BE_ABC.Models.DTO.insertReq;
using BE_ABC.Models.DTO.Request;
using BE_ABC.Models.ErdModels;
using BE_ABC.Services.GenericService;
using BE_ABC.Util;
using Microsoft.EntityFrameworkCore;

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
                          .Include(e => e.Resource)
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
                 .Include(e => e.Resource)
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
                findEvent.resourceId = item.resourceId;
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
            newEvent.resourceId = item.resourceId;
            newEvent.postsId = item.postsId;
            newEvent.paticipantsUid = item.paticipantsUid;
            newEvent.permissionIdToCRUDPost = item.permissionIdToCRUDPost;
            newEvent.description = item.description;
            newEvent.startAt = item.startAt;
            newEvent.endAt = item.endAt;
            newEvent.createAt = DateTimeExtensions.getUxixTimeNow();
            newEvent.updateAt = DateTimeExtensions.getUxixTimeNow();
            newEvent.status = item.status;
            newEvent.resouceUsingId = new List<int>();

            db.Attach(newEvent);
            var entityEntry = await db.Set<Event>().AddAsync(newEvent);

            await db.SaveChangesAsync();

            var newItem = await db.Set<Event>()
                       .Include(e => e.EventType)
                       .Include(e => e.User)
                       .Include(e => e.Resource)
                       .FirstOrDefaultAsync(e => e.id == entityEntry.Entity.id);  // Use FirstOrDefaultAsync for async operation

            return newItem;
        }

        public List<Event> search(SearchReq page)
        {
            // Ensure page number is not less than 1
            if (page.page < 1)
                page.page = 1;

            // Ensure limit is not less than 1
            if (page.limit < 1)
                page.limit = 1;

            var events = db.Event
                 .Where(e => e.name.Contains(page.text) || e.description.Contains(page.text))
                 .Include(e => e.EventType)
                 .Include(e => e.User)
                 .Include(e => e.Resource)
                 .Skip((page.page - 1) * page.limit)
                 .Take(page.limit)
                 .ToList();
            return events;
        }

        public List<Event> today()
        {
            var startOfDay = (int)(DateTime.UtcNow.Date - new DateTime(1970, 1, 1)).TotalSeconds;
            var endOfDay = (int)(DateTime.UtcNow.Date.AddDays(1) - new DateTime(1970, 1, 1)).TotalSeconds;

            var events = db.Event
                 .Where(e => (e.startAt >= startOfDay && e.startAt <= endOfDay) || (e.endAt >= startOfDay && e.endAt <= endOfDay))
                 .Include(e => e.EventType)
                 .Include(e => e.User)
                 .Include(e => e.Resource)
                 .ToList();
            return events;
        }

        internal async Task<List<Event>> getListByUid(string uid)
        {
            var @event = db.Event.Where(u => u.reporterUid == uid)
                        .Include(e => e.EventType)
                        .Include(e => e.User)
                        .Include(e => e.Resource)
                        .ToList();

            return @event;
        }

        internal async Task<bool> checkDelete(int req)
        {
            var check = db.Post.Where(p => p.eventId == req);

            if (check.Count() > 0)
                return false;
            return true;
        }
    }
}
