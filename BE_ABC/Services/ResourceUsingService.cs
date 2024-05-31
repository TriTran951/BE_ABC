using BE_ABC.Models.CommonModels;
using BE_ABC.Models.Context;
using BE_ABC.Models.DTO.Request;
using BE_ABC.Models.ErdModel;
using BE_ABC.Models.ErdModels;
using BE_ABC.Services.GenericService;
using BE_ABC.Util;
using Microsoft.EntityFrameworkCore;

namespace BE_ABC.Services
{
    public class ResourceUsingService : GenericService<ResourceUsing>
    {
        public ResourceUsingService(MyDbContext context) : base(context)
        {

        }
        public async Task<(bool check, string err)> checkInsert(ResourceUsingCreateReq req)
        {
            var findType = await db.Resource.Where(u => u.id == req.resourceId).FirstOrDefaultAsync();
            if (findType == null)
            {
                return (false, $"resourceId id={req.resourceId} not exist");
            }

            var findUser1 = await db.User.FindAsync(req.reporterUid);
            if (findUser1 == null)
            {
                return (false, $"reporterUid id={req.reporterUid} not exist");
            }

            var findUser2 = await db.User.FindAsync(req.borrowerUid);
            if (findUser2 == null)
            {
                return (false, $"reporterUid id={req.borrowerUid} not exist");
            }

            if (req.startAt >= req.endAt)
            {
                return (false, $"startAt must less than endAt  not exist");
            }

            return (true, "");
        }

        public async Task<(bool check, string err)> checkUpdate(ResourceUsingReq req)
        {
            var findResouce = await db.ResourceUsing.FindAsync(req.id);
            if (findResouce == null)
            {
                return (false, $"resource id={req.resourceId} not exist");
            }

            var findType = await db.Resource.FindAsync(req.resourceId);
            if (findType == null)
            {
                return (false, $"resourceId id={req.resourceId} not exist");
            }

            var findUser1 = await db.User.FindAsync(req.reporterUid);
            if (findUser1 == null)
            {
                return (false, $"reporterUid id={req.reporterUid} not exist");
            }

            var findUser2 = await db.User.FindAsync(req.borrowerUid);
            if (findUser2 == null)
            {
                return (false, $"reporterUid id={req.borrowerUid} not exist");
            }

            if (req.startAt >= req.endAt)
            {
                return (false, $"startAt must less than endAt  not exist");
            }

            return (true, "");
        }
        internal async Task<List<ResourceUsing>> getByUid(string uid)
        {
            var post = db.ResourceUsing.Where(u => u.borrowerUid == uid)
                .Include(u => u.Reporter)
                .Include(u => u.Borrower)
                .Include(u => u.Resource)
                .ToList();

            return post;
        }
        public List<ResourceUsing> getAll(Pagination page)
        {
            var user = db.ResourceUsing
                .Include(u => u.Reporter)
                .Include(u => u.Borrower)
                .Include(u => u.Resource)
                .Skip((page.page - 1) * page.limit).Take(page.limit).ToList();
            if (user != null)
            {
                return user;
            }
            else
                return new List<ResourceUsing>();
        }

        public async Task<ResourceUsing> insert(ResourceUsingCreateReq req)
        {
            ResourceUsing pt = new ResourceUsing();
            pt.resourceId = req.resourceId;
            pt.reporterUid = req.reporterUid;
            pt.borrowerUid = req.borrowerUid;
            pt.startAt = req.startAt;
            pt.endAt = req.endAt;
            pt.createAt = DateTimeExtensions.getUxixTimeNow();
            pt.updateAt = DateTimeExtensions.getUxixTimeNow();
            pt.status = req.status;

            db.Attach(pt);
            var entityEntry = await db.Set<ResourceUsing>().AddAsync(pt);

            await db.SaveChangesAsync();

            return entityEntry.Entity;
        }

        public async Task update(ResourceUsingReq req)
        {
            var findPosType = await db.ResourceUsing.FindAsync(req.id);

            if (findPosType != null)
            {
                findPosType.resourceId = req.resourceId;
                findPosType.reporterUid = req.reporterUid;
                findPosType.borrowerUid = req.borrowerUid;
                findPosType.startAt = req.startAt;
                findPosType.endAt = req.endAt;
                findPosType.updateAt = DateTimeExtensions.getUxixTimeNow();
                findPosType.status = req.status;

                db.Set<ResourceUsing>().Update(findPosType);

                await db.SaveChangesAsync();
            }
        }

        internal async Task<(List<Resource>? data, string err)> getResourceByType(string resourceId)
        {
            var findType = await db.ResourceType.FindAsync(resourceId);

            if (findType == null)
            {

                return (null, $"ResourceType id={resourceId} not exist");
            }

            var data = db.Resource.Where(u => u.resourceTypeId == resourceId).ToList();

            return (data, "");
        }
    }
}
