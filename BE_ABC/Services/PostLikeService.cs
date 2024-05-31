using BE_ABC.Models.CommonModels;
using BE_ABC.Models.Context;
using BE_ABC.Models.DTO.Request;
using BE_ABC.Models.ErdModel;
using BE_ABC.Services.GenericService;
using BE_ABC.Util;

namespace BE_ABC.Services
{
    public class PostLikeService : GenericService<PostLike>
    {
        public PostLikeService(MyDbContext context) : base(context)
        {
        }
        internal async Task<(bool check, string err)> checkInsert(PostLikeCreateReq req)
        {
            var findUser = await db.User.FindAsync(req.userId);

            if (findUser == null)
            {
                return (false, "User not exist");
            }

            var findPost = await db.Post.FindAsync(req.postId);

            if (findPost == null)
            {
                return (false, "Post not exist");
            }

            return (true, "");
        }

        internal async Task<(bool check, string err)> checkUpdate(PostLikeReq req)
        {
            var findComment = await db.PostLike.FindAsync(req.id);

            if (findComment == null)
            {
                return (false, "Like not exist");
            }

            var findUser = await db.User.FindAsync(req.userId);

            if (findUser == null)
            {
                return (false, "User not exist");
            }

            var findPost = await db.Post.FindAsync(req.postId);

            if (findPost == null)
            {
                return (false, "Post not exist");
            }

            return (true, "");
        }

        internal List<PostLike> getAll(Pagination page)
        {
            var user = db.PostLike.Skip((page.page - 1) * page.limit).Take(page.limit).ToList();
            if (user != null)
            {
                return user;
            }
            else
                return new List<PostLike> { };
        }

        internal async Task<PostLike> insert(PostLikeCreateReq req)
        {
            var newComment = new PostLike();
            newComment.userId = req.userId;
            newComment.postId = req.postId;
            newComment.createAt = DateTimeExtensions.getUxixTimeNow();
            newComment.updateAt = DateTimeExtensions.getUxixTimeNow();
            newComment.status = req.status;

            var post = await db.Post.FindAsync(req.postId);
            if (post != null)
            {
                post.likes++;
                db.Set<Post>().Update(post);
            }

            db.Attach(newComment);
            var entityEntry = await db.Set<PostLike>().AddAsync(newComment);

            await db.SaveChangesAsync();

            return entityEntry.Entity;
        }
        internal async Task update(PostLikeReq req)
        {
            var findUser = await db.PostLike.FindAsync(req.id);
            if (findUser != null)
            {
                findUser.id = req.id;
                findUser.userId = req.userId;
                findUser.postId = req.postId;
                findUser.updateAt = DateTimeExtensions.getUxixTimeNow();
                findUser.status = req.status;

                db.Set<PostLike>().Update(findUser);

                await db.SaveChangesAsync();
            }
        }
    }
}
