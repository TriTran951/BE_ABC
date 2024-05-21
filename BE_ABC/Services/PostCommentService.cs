using BE_ABC.Models.CommonModels;
using BE_ABC.Models.Context;
using BE_ABC.Models.DTO.Request;
using BE_ABC.Models.ErdModel;
using BE_ABC.Services.GenericService;
using BE_ABC.Util;

namespace BE_ABC.Services
{
    public class PostCommentService : GenericService<PostComment>
    {
        public PostCommentService(MyDbContext context) : base(context)
        {
        }

        internal async Task<(bool check, string err)> checkInsert(PostCommentReq req)
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

        internal async Task<(bool check, string err)> checkUpdate(PostComment req)
        {
            var findComment = await db.PostComment.FindAsync(req.id);

            if (findComment == null)
            {
                return (false, "Comment not exist");
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

        internal List<PostComment> getAll(Pagination page)
        {
            var user = db.PostComment.Skip((page.page - 1) * page.limit).Take(page.limit).ToList();
            if (user != null)
            {
                return user;
            }
            else
                return new List<PostComment> { };
        }

        internal async Task<PostComment> insert(PostCommentReq req)
        {
            var newComment = new PostComment();
            newComment.userId = req.userId;
            newComment.postId = req.postId;
            newComment.content = req.content;
            newComment.images = req.images;
            newComment.file = req.file;
            newComment.createAt = DateTimeExtensions.getUxixTimeNow();
            newComment.updateAt = DateTimeExtensions.getUxixTimeNow();
            newComment.status = req.status;

            db.Attach(newComment);
            var entityEntry = await db.Set<PostComment>().AddAsync(newComment);

            await db.SaveChangesAsync();

            return entityEntry.Entity;
        }
    }
}
