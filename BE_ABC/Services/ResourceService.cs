using BE_ABC.Models.CommonModels;
using BE_ABC.Models.Context;
using BE_ABC.Models.DTO.Request;
using BE_ABC.Models.ErdModel;
using BE_ABC.Services.GenericService;
using BE_ABC.Util;
using Microsoft.EntityFrameworkCore;

namespace BE_ABC.Services
{
    public class ResourceService : GenericService<Resource>
    {
        public ResourceService(MyDbContext context) : base(context)
        {

        }

        public async Task<(bool check, string err)> checkInsert(ResourceCreateReq req)
        {
            var findType = await db.ResourceType.FindAsync(req.resourceTypeId);
            if (findType == null)
            {
                return (false, $"ResourceType id={req.resourceTypeId} not exist");
            }

            return (true, "");
        }

        public async Task<(bool check, string err)> checkUpdate(ResourceReq req)
        {
            var findResource = await db.ResourceType.FindAsync(req.resourceTypeId);
            if (findResource == null)
            {
                return (false, $"ResourceType id={req.resourceTypeId} not exist");
            }


            var findType = await db.Resource.FindAsync(req.id);
            if (findType == null)
            {
                return (false, $"Resource id={req.id} not exist");
            }

            return (true, "");
        }
        internal async Task<Resource> get(int req)
        {
            var user = db.Resource.Where(u => u.id == req).Include(u => u.ResourceType).FirstOrDefault();

            return user;
        }
        public List<Resource> getAll(Pagination page)
        {
            var user = db.Resource.Include(u => u.ResourceType).Skip((page.page - 1) * page.limit).Take(page.limit).ToList();
            if (user != null)
            {
                return user;
            }
            else
                return new List<Resource>();
        }

        public async Task<Resource> insert(ResourceCreateReq req)
        {
            Resource pt = new Resource();
            pt.resourceTypeId = req.resourceTypeId;
            pt.name = req.name;
            pt.images = req.images;
            pt.description = req.description;
            pt.isFree = req.isFree;
            pt.createAt = DateTimeExtensions.getUxixTimeNow();
            pt.updateAt = DateTimeExtensions.getUxixTimeNow();
            pt.status = req.status;

            db.Attach(pt);
            var entityEntry = await db.Set<Resource>().AddAsync(pt);

            await db.SaveChangesAsync();

            return entityEntry.Entity;
        }

        public async Task update(ResourceReq req)
        {
            var findPosType = await db.Resource.FindAsync(req.id);

            if (findPosType != null)
            {
                findPosType.name = req.name;
                findPosType.description = req.description;
                findPosType.name = req.name;
                findPosType.images = req.images;
                findPosType.isFree = req.isFree;
                findPosType.updateAt = DateTimeExtensions.getUxixTimeNow();
                findPosType.status = req.status;

                db.Set<Resource>().Update(findPosType);

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
