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
    public class DepartmentService: GenericService<Department>
    {
        public DepartmentService(MyDbContext context) : base(context)
        {
        }
        public List<Department> getAll(Pagination page)
        {
            var user = db.Department.Include(u=>u.User).Skip((page.page - 1) * page.limit).Take(page.limit).ToList();
            if (user != null)
            {
                return user;
            }
            else
                return new List<Department>();
        }
        public async Task<(bool, string)> checkInsert(DepartmentReq req)
        {
            //check post type
            var findType = await db.RequestType.FindAsync(req.id);
            if (findType != null)
            {
                return (false, $"Department id={req.id} exist");
            }

            //check creator
            var findUser = await db.User.FindAsync(req.directorUid);
            if (findUser == null)
            {
                return (false, $"User id={req.directorUid} not exist");
            }

            return (true, "");
        }

        public async Task<Department> insert(DepartmentReq req)
        {
            Department pt = new Department();
            pt.id = req.id;
            pt.name = req.name;
            pt.directorUid = req.directorUid;
            pt.permissionIdToCRUD = req.permissionIdToCRUD;
            pt.status = req.status;
            pt.createAt = DateTimeExtensions.getUxixTimeNow();
            pt.updateAt = DateTimeExtensions.getUxixTimeNow();

            db.Attach(pt);
            var entityEntry = await db.Set<Department>().AddAsync(pt);

            await db.SaveChangesAsync();

            return entityEntry.Entity;
        }
        public async Task update(Department req)
        {
            var findPosType = await db.Department.FindAsync(req.id);

            if (findPosType != null)
            {
                findPosType.id = req.id;
                findPosType.name = req.name;
                findPosType.directorUid = req.directorUid;
                findPosType.permissionIdToCRUD = req.permissionIdToCRUD;
                findPosType.status = req.status;
                findPosType.updateAt = DateTimeExtensions.getUxixTimeNow();

                db.Set<Department>().Update(findPosType);

                await db.SaveChangesAsync();
            }
        }

    }
}
