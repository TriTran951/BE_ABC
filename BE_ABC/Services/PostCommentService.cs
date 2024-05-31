using BE_ABC.Models.CommonModels;
using BE_ABC.Models.Context;
using BE_ABC.Models.DTO.Request;
using BE_ABC.Models.ErdModel;
using BE_ABC.Services.GenericService;
using BE_ABC.Util;
using Microsoft.EntityFrameworkCore;

namespace BE_ABC.Services
{
    public class PostCommentService : GenericService<PostComment>
    {
        public PostCommentService(MyDbContext context) : base(context)
        {
        }

        internal async Task<(bool check, string err)> checkInsert(PostCommentCreateReq req)
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

        internal async Task<(bool check, string err)> checkUpdate(PostCommentReq req)
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

        internal async Task<PostComment?> get(int req)
        {
            var user = db.PostComment.Where(u => u.id == req).Include(u => u.User).FirstOrDefault();

            return user;
        }

        internal List<PostComment> getAll(Pagination page)
        {
            var user = db.PostComment.Include(u => u.User).Skip((page.page - 1) * page.limit).Take(page.limit).ToList();
            if (user != null)
            {
                return user;
            }
            else
                return new List<PostComment> { };
        }

        internal async Task<PostComment> insert(PostCommentCreateReq req)
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

            var post = await db.Post.FindAsync(req.postId);
            if (post != null)
            {
                post.comments++;
                db.Set<Post>().Update(post);
            }

            db.Attach(newComment);
            var entityEntry = await db.Set<PostComment>().AddAsync(newComment);

            await db.SaveChangesAsync();

            return entityEntry.Entity;
        }

        internal async Task update(PostCommentReq req)
        {
            var findUser = await db.PostComment.FindAsync(req.id);
            if (findUser != null)
            {
                findUser.id = req.id;
                findUser.userId = req.userId;
                findUser.postId = req.postId;
                findUser.content = req.content;
                findUser.images = req.images;
                findUser.file = req.file;
                findUser.updateAt = DateTimeExtensions.getUxixTimeNow();
                findUser.status = req.status;

                db.Set<PostComment>().Update(findUser);

                await db.SaveChangesAsync();
            }
        }
    }
}
