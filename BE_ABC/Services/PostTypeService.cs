using BE_ABC.Models.CommonModels;
using BE_ABC.Models.Context;
using BE_ABC.Models.DTO.Request;
using BE_ABC.Models.ErdModel;
using BE_ABC.Models.ErdModels;
using BE_ABC.Services.GenericService;
using BE_ABC.Util;

namespace BE_ABC.Services
{
    public class PostTypeService : GenericService<PostType>
    {
        public PostTypeService(MyDbContext context) : base(context)
        {
        }

        public async Task<(bool check, string err)> checkTypeInsert(PostTypeReq PostTypeReq)
        {
            throw new NotImplementedException();
        }

        public async Task<(bool check, string err)> checkUpdate(UserReq req)
        {
            throw new NotImplementedException();
        }

        public List<PostType> getAll(Pagination page)
        {
            var user = db.PostType.Skip((page.page - 1) * page.limit).Take(page.limit).ToList();
            if (user != null)
            {
                return user;
            }
            else
                return new List<PostType>();
        }

        public async Task<PostType > insert(PostTypeReq req)
        {
            PostType pt = new PostType();
            pt.name = req.name;
            pt.description = req.description;
            pt.permissionIdToCRUD = req.permissionIdToCRUD;
            pt.permissionIdToCRUDPost = req.permissionIdToCRUDPost;
            pt.createAt = DateTimeExtensions.getUxixTimeNow();
            pt.updateAt = DateTimeExtensions.getUxixTimeNow();
            pt.status = req.status;

            db.Attach(pt);
            var entityEntry = await db.Set<PostType>().AddAsync(pt);

            await db.SaveChangesAsync();

            return entityEntry.Entity;
        }

        public async Task update(PostType req)
        {
            var findPosType = await db.PostType.FindAsync(req.id);

            if (findPosType != null)
            {
                findPosType.name = req.name;
                findPosType.description = req.description;
                findPosType.permissionIdToCRUD = req.permissionIdToCRUD;
                findPosType.permissionIdToCRUDPost = req.permissionIdToCRUDPost;
                findPosType.updateAt = DateTimeExtensions.getUxixTimeNow();
                findPosType.status = req.status;

                db.Set<PostType>().Update(findPosType);

                await db.SaveChangesAsync();
            }
        }
    }
}
