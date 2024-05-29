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
    public class PostService : GenericService<Post>
    {
        public PostService(MyDbContext context) : base(context)
        {
        }

        public async Task<(bool, string)> checkInsertPost(PostReq req)
        {
            //check post type
            var findType = await db.PostType.FindAsync(req.postTypeId);
            if(findType == null)
            {
                return (false, $"Post type id={req.postTypeId} not exist");
            }

            if (req.eventId != null) { 
                var findEvent = await db.Event.FindAsync(req.eventId);
                if (findEvent == null)
                {
                    return (false, $"Event id={req.eventId} not exist");
                }
            }

            //check creator
            var findUser = await db.User.FindAsync(req.creatorUid);
            if (findUser == null)
            {
                return (false, $"User id={req.creatorUid} not exist");
            }

            foreach(var user in req.mentionUid) 
            {
                var findUserMention = await db.User.FindAsync(user);
                if (findUserMention == null)
                {
                    return (false, $"User mention id={user} not exist");
                }
            }

            return (true, "");
        }

        internal async Task<(bool, string)> checkUpdate(Post req)
        {
            var findPost = await db.Post.FindAsync(req.id);
            if (findPost == null)
            {
                return (false, $"Post {req.id} not found");
            }

            var findUser = await db.User.FindAsync(req.creatorUid);
            if (findPost == null)
            {
                return (false, $"User {req.creatorUid} not found");
            }

            var findPostType = await db.PostType.FindAsync(req.postTypeId);
            if (findPost == null)
            {
                return (false, $"PostType {req.postTypeId} not found");
            }

            if (req.eventId != null)
            {
                var findEvent = await db.Event.FindAsync(req.eventId);
                if (findEvent == null)
                {
                    return (false, $"Event {req.eventId} not found");
                }
            }

            return (true, "Ok");
        }

        internal async Task<Post> get(int req)
        {
            var user = db.Post
            .Where(u => u.id == req)
            .Include(u => u.User)
            .Include(u => u.Event)
            .FirstOrDefault();

            return user;
        }

        internal List<Post> getAll(Pagination page)
        {
            var user = db.Post
            .Include(u => u.User)
            .Include(u => u.Event)
            .Skip((page.page - 1) * page.limit).Take(page.limit).ToList();

            return user;
        }

        internal async Task<Post> insert(PostReq req)
        {
            Post newPost = new Post();

            newPost.postTypeId = req.postTypeId;
            newPost.creatorUid = req.creatorUid;
            newPost.eventId = req.eventId;
            newPost.mentionUid = req.mentionUid;
            newPost.title = req.title;
            newPost.content = req.content;
            newPost.images = req.images ?? [];
            newPost.files = req.files ?? [];
            newPost.likes = 0;
            newPost.comments = 0;
            newPost.createAt = DateTimeExtensions.getUxixTimeNow(); 
            newPost.updateAt = DateTimeExtensions.getUxixTimeNow();
            newPost.status = req.status;

            db.Attach(newPost);
            var entityEntry = await db.Set<Post>().AddAsync(newPost);

            await db.SaveChangesAsync();

            return entityEntry.Entity;
        }

        internal async Task update(Post req)
        {
            var findUser = await db.Post.FindAsync(req.id);
            if (findUser != null)
            {
                findUser.id = req.id;
                findUser.postTypeId = req.postTypeId;
                findUser.creatorUid = req.creatorUid;
                findUser.eventId = req.eventId;
                findUser.mentionUid = req.mentionUid;
                findUser.title = req.title;
                findUser.content = req.content;
                findUser.images = req.images;
                findUser.files = req.files;
                findUser.updateAt = DateTimeExtensions.getUxixTimeNow();
                findUser.status = req.status;

            }
        }
    }
}
