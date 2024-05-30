using BE_ABC.Models.CommonModels;
using BE_ABC.Models.Context;
using BE_ABC.Models.DTO.Req;
using BE_ABC.Models.DTO.Request;
using BE_ABC.Models.DTO.Req;
using BE_ABC.Models.ErdModel;
using BE_ABC.Models.ErdModels;
using BE_ABC.Services.GenericService;
using BE_ABC.Util;
using Microsoft.EntityFrameworkCore;

namespace BE_ABC.Services
{
    public class RequestService : GenericService<Request>
    {
        public RequestService(MyDbContext context) : base(context)
        {
        }
        internal async Task<List<Request>> getByUid(string uid)
        {
            var list = db.Request.Where(u=>u.requesterUid == uid)
                 .Include(u => u.Requester)
                .Include(u => u.Reporter)
                .Include(u => u.RequestType)
                .ToList();

            return list;
        }
        internal async Task<Request?> get(int req)
        {
            var user = db.Request
            .Where(u => u.id == req)
            .Include(u => u.Requester)
            .Include(u => u.Reporter)
            .Include(u => u.RequestType)
            .FirstOrDefault();

            return user;
        }

        internal List<Request> getAll(Pagination page)
        {
            var user = db.Request
            .Include(u => u.Requester)
            .Include(u => u.Reporter)
            .Include(u => u.RequestType)
            .Skip((page.page - 1) * page.limit).Take(page.limit).ToList();

            return user;
        }



        internal async Task<Request> insert(RequestCreateReq req)
        {
            Request newPost = new Request();

            newPost.requesterUid = req.requesterUid;
            newPost.requestTypeId = req.requestTypeId;
            newPost.reporterUid = req.reporterUid;
            newPost.name = req.name;
            newPost.description = req.description;
            newPost.startAt = req.startAt;
            newPost.endAt = req.endAt;
            newPost.approvalStatus = req.approvalStatus;
            newPost.decidedAt = req.decidedAt;
            newPost.decisionDetail = req.decisionDetail;
            newPost.createAt = DateTimeExtensions.getUxixTimeNow();
            newPost.updateAt = DateTimeExtensions.getUxixTimeNow();
            newPost.status = req.status;

            db.Attach(newPost);
            var entityEntry = await db.Set<Request>().AddAsync(newPost);

            await db.SaveChangesAsync();

            return entityEntry.Entity;
        }

        internal async Task update(RequestReq req)
        {
            var findUser = await db.Request.FindAsync(req.id);
            if (findUser != null)
            {
                findUser.id = req.id;
                findUser.requesterUid = req.requesterUid;
                findUser.requestTypeId = req.requestTypeId;
                findUser.reporterUid = req.reporterUid;
                findUser.name = req.name;
                findUser.description = req.description;
                findUser.startAt = req.startAt;
                findUser.endAt = req.endAt;
                findUser.approvalStatus = req.approvalStatus;
                findUser.decidedAt = req.decidedAt;
                findUser.decisionDetail = req.decisionDetail;
                findUser.updateAt = DateTimeExtensions.getUxixTimeNow();
                findUser.status = req.status;

                db.Set<Request>().Update(findUser);

                await db.SaveChangesAsync();
            }
        }
        internal async Task<(bool, string)> checkUpdate(RequestReq req)
        {
            var findPost = await db.Request.FindAsync(req.id);
            if (findPost == null)
            {
                return (false, $"Request {req.id} not found");
            }

            var findType = await db.User.FindAsync(req.requesterUid);
            if (findType == null)
            {
                return (false, $"User id={req.requesterUid} not exist");
            }


            var findEvent = await db.RequestType.FindAsync(req.requestTypeId);
            if (findEvent == null)
            {
                return (false, $"RequestType id={req.requestTypeId} not exist");
            }


            //check creator
            var findUser = await db.User.FindAsync(req.reporterUid);
            if (findUser == null)
            {
                return (false, $"User id={req.reporterUid} not exist");
            }


            return (true, "Ok");
        }
        public async Task<(bool, string)> checkInsertPost(RequestCreateReq req)
        {
            var findType = await db.User.FindAsync(req.requesterUid);
            if (findType == null)
            {
                return (false, $"User id={req.requesterUid} not exist");
            }

        
            var findEvent = await db.RequestType.FindAsync(req.requestTypeId);
            if (findEvent == null)
            {
                return (false, $"RequestType id={req.requestTypeId} not exist");
            }
            

            //check creator
            var findUser = await db.User.FindAsync(req.reporterUid);
            if (findUser == null)
            {
                return (false, $"User id={req.reporterUid} not exist");
            }

            return (true, "");
        }


    }
}
