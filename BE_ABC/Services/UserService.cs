using BE_ABC.ConstValue;
using BE_ABC.Models.CommonModels;
using BE_ABC.Models.Context;
using BE_ABC.Models.DTO.Request;
using BE_ABC.Models.ErdModels;
using BE_ABC.Services.GenericService;
using BE_ABC.Util;
using Microsoft.IdentityModel.Tokens;

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
        
        public async Task update(UserReq user)
        {
            var findUser = await db.User.FindAsync(user.uid);
            if (findUser != null)
            {
                findUser.uid = user.uid;
                findUser.departmentId = user.departmentId;
                findUser.grade = user.grade;
                findUser.username = user.username;
                findUser.birthday = (int)DateTimeExtensions.ToUnixTime(DateTime.UtcNow);
                findUser.email = user.email;
                findUser.avatar = user.avatar;
                findUser.description = user.description;
                findUser.permissionIdToCRUD = user.permissionIdToCRUD;
                findUser.updateAt = DateTimeExtensions.getUxixTimeNow();
                findUser.status = user.status;

                db.Set<User>().Update(findUser);

                await db.SaveChangesAsync();
            }
        }
        public async Task<User>? insert(UserReq user)
        {
            User newUser = new User();
            newUser.uid = user.uid;
            newUser.departmentId = user.departmentId;
            newUser.grade = user.grade;
            newUser.username = user.username;
            newUser.birthday = (int)DateTimeExtensions.ToUnixTime(DateTime.UtcNow);
            newUser.email = user.email;
            newUser.avatar = user.avatar;
            newUser.description = user.description;
            newUser.permissionIdToCRUD = user.permissionIdToCRUD;
            newUser.createAt = DateTimeExtensions.getUxixTimeNow();
            newUser.updateAt = DateTimeExtensions.getUxixTimeNow(); 
            newUser.status = user.status;

            db.Attach(newUser);
            var entityEntry = await db.Set<User>().AddAsync(newUser);

            await db.SaveChangesAsync();

            return entityEntry.Entity;
        }
        public async Task<(bool, string)> checkUserInsert(UserReq user)
        {
            var findUser = await db.User.FindAsync(user.uid);
            if(findUser == null)
            {
                return (false, "User exist");
            }

            if(user.departmentId != null)
            {
                var checkDepartment = await db.Department.FindAsync(user.departmentId);
                if (checkDepartment == null)
                {
                    return (false, $"departmentId of user {user.uid} invalid");
                }
            }
            

            return (true, "Ok");
        }
        public async Task<(bool, string)> checkUpdate(UserReq user)
        {
            var findUser = await db.User.FindAsync(user.uid);

            if (findUser == null)
            {
                return (false, "User not found");
            }

            if (user.departmentId != null)
            {
                var checkDepartment = await db.Department.FindAsync(user.departmentId);
                if (checkDepartment == null)
                {
                    return (false, $"departmentId of user {user.uid} invalid");
                }
            }

            return (true, "Ok");
        }
    }
}
