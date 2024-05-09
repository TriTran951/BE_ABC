using BE_ABC.Models.CommonModels;
using BE_ABC.Models.Context;
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
    }
}
