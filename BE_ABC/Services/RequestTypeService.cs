using BE_ABC.Models.CommonModels;
using BE_ABC.Models.Context;
using BE_ABC.Models.DTO.Request;
using BE_ABC.Models.ErdModel;
using BE_ABC.Models.ErdModels;
using BE_ABC.Services.GenericService;
using BE_ABC.Util;

namespace BE_ABC.Services
{
    public class RequestTypeService : GenericService<RequestType>
    {
        public RequestTypeService(MyDbContext context) : base(context)
        {
        }
        public List<RequestType> getAll(Pagination page)
        {
            var user = db.RequestType.Skip((page.page - 1) * page.limit).Take(page.limit).ToList();
            if (user != null)
            {
                return user;
            }
            else
                return new List<RequestType>();
        }
        public async Task<(bool, string)> checkInsert(RequestTypeReq req)
        {
            //check post type
            var findType = await db.RequestType.FindAsync(req.id);
            if (findType != null)
            {
                return (false, $"Request type id={req.id} exist");
            }

            //check creator
            var findUser = await db.Department.FindAsync(req.approvalDepartmentId);
            if (findUser == null)
            {
                return (false, $"Department id={req.approvalDepartmentId} not exist");
            }

            return (true, "");
        }

        public async Task<RequestType> insert(RequestTypeReq req)
        {
            RequestType pt = new RequestType();
            pt.id = req.id;
            pt.name = req.name;
            pt.description = req.description;
            pt.approvalDepartmentId = req.approvalDepartmentId;
            pt.minApprovalGrade = req.minApprovalGrade;
            pt.permissionIdToCRUD = req.permissionIdToCRUD;
            pt.status = req.status;
            pt.createAt = DateTimeExtensions.getUxixTimeNow();
            pt.updateAt = DateTimeExtensions.getUxixTimeNow();

            db.Attach(pt);
            var entityEntry = await db.Set<RequestType>().AddAsync(pt);

            await db.SaveChangesAsync();

            return entityEntry.Entity;
        }
        public async Task update(RequestType req)
        {
            var findPosType = await db.RequestType.FindAsync(req.id);

            if (findPosType != null)
            {
                findPosType.id = req.id;
                findPosType.name = req.name;
                findPosType.description = req.description;
                findPosType.approvalDepartmentId = req.approvalDepartmentId;
                findPosType.minApprovalGrade = req.minApprovalGrade;
                findPosType.permissionIdToCRUD = req.permissionIdToCRUD;
                findPosType.status = req.status;
                findPosType.updateAt = DateTimeExtensions.getUxixTimeNow();


                db.Set<RequestType>().Update(findPosType);

                await db.SaveChangesAsync();
            }
        }
    }
}
