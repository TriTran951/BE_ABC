using BE_ABC.ConstValue;
using BE_ABC.Models.CommonModels;
using BE_ABC.Models.Context;
using BE_ABC.Models.DTO.Request;
using BE_ABC.Models.ErdModels;
using BE_ABC.Services.GenericService;

namespace BE_ABC.Services
{
    public class UserService : GenericService<User>
    {
        public UserService(MyDbContext context) : base(context)
        {
        }
        public List<User> getAll(Pagination page)
        {
            var user = db.User.Skip((page.page - 1) * page.limit).Take(page.limit).ToList();
            if (user != null)
            {
                return user;
            }
            else
                return new List<User> { };
        }
        public async Task<User>? insert(UserReq user)
        {
            User newUser = new User();
            newUser.uid = user.uid;
            newUser.departmentId = user.departmentId;
            newUser.grade = user.grade;
            newUser.username = user.username;
            newUser.birthday = DateTime.Now;
            newUser.email = user.email;
            newUser.avatar = user.avatar;
            newUser.description = user.description;
            newUser.permissionIdToCRUD = user.permissionIdToCRUD;
            newUser.createAt = 1;
            newUser.updateAt = 1;
            newUser.status = StatusType.create;

            db.Attach(newUser);
            var entityEntry = await db.Set<User>().AddAsync(newUser);

            await db.SaveChangesAsync();

            return entityEntry.Entity;
        }
    }
}
