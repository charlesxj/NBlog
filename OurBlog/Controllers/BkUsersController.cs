using OurBlog.Helper;
using OurBlog.IBll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OurBlog.Model;
using System.Linq.Expressions;
using Newtonsoft.Json;

namespace OurBlog.Controllers
{
    public class BkUsersController : ElecSmoke.Controllers.BaseController
    {
        public IUsersService UsersService { get; private set; }

        public BkUsersController(IUsersService usersService)
        {
            this.UsersService = usersService;

            this.AddDisposableOject(usersService);
        }

        // GET: BkUsers
        public ViewResult Index()
        {
            return View();
        }

        public JsonResult GetList()
        {
            string usr_no = string.IsNullOrEmpty(Request["usr_no"]) ? null : Request["usr_no"];
            string user_name = string.IsNullOrEmpty(Request["user_name"]) ? null : Request["user_name"];
            string nick_name = string.IsNullOrEmpty(Request["nick_name"]) ? null : Request["nick_name"];
            string rgt_time = Request["rgt_time"];
            string usr_level = string.IsNullOrEmpty(Request["usr_level"]) ? null : Request["usr_level"];

            int page = string.IsNullOrEmpty(Request["page"]) ? 1 : int.Parse(Request["page"]);
            int rows = string.IsNullOrEmpty(Request["rows"]) ? 10 : int.Parse(Request["rows"]);

            DateTime? c_time = null;
            DateTime? c_time_end = null;
            if (string.IsNullOrEmpty(rgt_time) == false)
            {
                c_time = DateTime.Parse(rgt_time);
                c_time_end = c_time.Value.AddDays(1);
            }


            int count = 0;
            var data = UsersService.GetUsersByFilter(a => (
            a.FUSERNO == (usr_no ?? a.FUSERNO)
            && a.FUSERNAME == (user_name ?? a.FUSERNAME)
            && a.FUSERNICKNAME == (nick_name ?? a.FUSERNICKNAME)
            && a.FUSERREGTIME >= (c_time ?? a.FUSERREGTIME)
            && a.FUSERREGTIME <= (c_time_end ?? a.FUSERREGTIME)
            && a.FUSERLEVEL == (usr_level ?? a.FUSERLEVEL)), page, rows, b => b.FUSERLEVEL, out count);
            return Json(
                new { rows = data, total = count });
        }


        // POST: BkUsers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[ValidateAntiForgeryToken]
        public ContentResult CreateOrEdit(user user)
        {
            if (!string.IsNullOrEmpty(Request["flag"]))
            {
                List<user> usres = JsonConvert.DeserializeObject<List<user>>(Request["users"]);
                return Content(optUser(usres));
            }

            if (user.FUSERID == 0)
            {
                return Content(CreateUser(user));
            }
            else
            {
                return Content(EditUser(user));
            }

        }

        private string optUser(List<user> usres)
        {
            int data = 1;
            foreach (var item in usres)
            {
                item.FUSERSTATUS = (item.FUSERSTATUS == "DISABLED") ? "NORMAL" : "DISABLED";
                data = UsersService.EditUser(item) * data;
            }
            if (data == 1)
            {
                var a = new { success = true, message = "操作成功" };
                return JsonConvert.SerializeObject(a);
            }
            else
            {
                var a = new
                {
                    success = false,
                    message = "操作失败，请重试或联系管理员"
                };
                return JsonConvert.SerializeObject(a);
            }
        }

        private string EditUser(user user)
        {
            user.FUSERNAME = user.FUSERNAME ?? string.Empty;
            //user.FUSERREGTIME = DateTime.Now;
            user.FUSERLEVEL = user.FUSERLEVEL ?? "1";
            user.FUSERSTATUS = user.FUSERSTATUS ?? "NORMAL";

            var data = UsersService.EditUser(user);
            if (data == 1)
            {
                var a = new { success = true, message = "操作成功" };
                return JsonConvert.SerializeObject(a);
            }
            else
            {
                var a = new
                {
                    success = false,
                    message = "操作失败，请重试或联系管理员"
                };
                return JsonConvert.SerializeObject(a);
            }
        }

        string CreateUser(user user)
        {
            user.FUSERNAME = user.FUSERNAME ?? string.Empty;
            user.FUSERREGTIME = DateTime.Now;
            user.FUSERLEVEL = "1";
            user.FUSERSTATUS = "NORMAL";

            var data = UsersService.AddUser(user);
            if (data == 1)
            {
                var a = new { success = true, message = "添加成功" };
                return JsonConvert.SerializeObject(a);
            }
            else
            {
                var a = new
                {
                    success = false,
                    message = "添加失败，请重试或联系管理员"
                };
                return JsonConvert.SerializeObject(a);
            }
        }

        //// GET: BkUsers/Details/5
        //public async Task<ActionResult> Details(long? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    user user = await db.user.FindAsync(id);
        //    if (user == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(user);
        //}

        //// GET: BkUsers/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: BkUsers/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Create([Bind(Include = "FUSERID,FUSERNO,FUSERNAME,FUSERNICKNAME,FUSERREGTIME,FUSERLEVEL,FUSERBIRTHDAY,FUSERMOBILENO,FUSERQQNO,FUSERWXID,FUSERMAIL,FUSERSTATUS,FUSERTELNO,FPASSWORD")] user user)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.user.Add(user);
        //        await db.SaveChangesAsync();
        //        return RedirectToAction("Index");
        //    }

        //    return View(user);
        //}

        //// GET: BkUsers/Edit/5
        //public async Task<ActionResult> Edit(long? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    user user = await db.user.FindAsync(id);
        //    if (user == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(user);
        //}

        //// POST: BkUsers/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Edit([Bind(Include = "FUSERID,FUSERNO,FUSERNAME,FUSERNICKNAME,FUSERREGTIME,FUSERLEVEL,FUSERBIRTHDAY,FUSERMOBILENO,FUSERQQNO,FUSERWXID,FUSERMAIL,FUSERSTATUS,FUSERTELNO,FPASSWORD")] user user)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(user).State = System.Data.Entity.EntityState.Modified;
        //        await db.SaveChangesAsync();
        //        return RedirectToAction("Index");
        //    }
        //    return View(user);
        //}

        //// GET: BkUsers/Delete/5
        //public async Task<ActionResult> Delete(long? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    user user = await db.user.FindAsync(id);
        //    if (user == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(user);
        //}

        //// POST: BkUsers/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> DeleteConfirmed(long id)
        //{
        //    user user = await db.user.FindAsync(id);
        //    db.user.Remove(user);
        //    await db.SaveChangesAsync();
        //    return RedirectToAction("Index");
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
