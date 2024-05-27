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
    public class ResourceTypeService : GenericService<BE_ABC.Models.ErdModels.ResourceType>
    {
        public ResourceTypeService(MyDbContext context) : base(context)
        {
        }

        public async Task<(bool, string)> checkInsert(ResourceTypeReq req)
        {
            var findType = await db.ResourceType.FindAsync(req.id);
            if (findType != null)
            {
                return (false, $"ResourceType id={req.id} exist");
            }

            return (true, "");
        }

        internal async Task<(bool, string)> checkUpdate(ResourceType req)
        {
            var findType = await db.ResourceType.FindAsync(req.id);
            if (findType == null)
            {
                return (false, $"ResourceType id={req.id} not exist");
            }

            return (true, "");
        }

        internal List<ResourceType> getAll(Pagination page)
        {
            var user = db.ResourceType
                .Skip((page.page - 1) * page.limit).Take(page.limit).ToList();
            if (user != null)
            {
                return user;
            }
            else
                return new List<ResourceType> { };
        }

        internal async Task<ResourceType> insert(ResourceTypeReq req)
        {
            ResourceType newPost = new ResourceType();

            newPost.id = req.id;
            newPost.name = req.name;
            newPost.description = req.description;
            newPost.permissionIdToCRUDResourceUsing = newPost.permissionIdToCRUDResourceUsing;
            newPost.permissionIdToCRUDResource = req.permissionIdToCRUDResource;
            newPost.permissionIdToCRUD = req.permissionIdToCRUD;
            newPost.createAt = DateTimeExtensions.getUxixTimeNow();
            newPost.updateAt = DateTimeExtensions.getUxixTimeNow();
            newPost.status = req.status;

            db.Attach(newPost);
            var entityEntry = await db.Set<ResourceType>().AddAsync(newPost);

            await db.SaveChangesAsync();

            return entityEntry.Entity;
        }

        internal async Task update(ResourceType req)
        {
            var newPost = await db.ResourceType.FindAsync(req.id);
            if (newPost != null)
            {
                newPost.id = req.id;
                newPost.name = req.name;
                newPost.description = req.description;
                newPost.permissionIdToCRUDResourceUsing = newPost.permissionIdToCRUDResourceUsing;
                newPost.permissionIdToCRUDResource = req.permissionIdToCRUDResource;
                newPost.permissionIdToCRUD = req.permissionIdToCRUD;
                newPost.updateAt = DateTimeExtensions.getUxixTimeNow();
                newPost.status = req.status;

                db.Set<ResourceType>().Update(newPost);

                await db.SaveChangesAsync();
            }
        }
    }
}
