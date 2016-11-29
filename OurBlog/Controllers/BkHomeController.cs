
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ElecSmoke.Controllers
{
    public class BkHomeController : BaseController
    {
        //IVistorInfoService VistorInfoService = new VistorInfoService();

        //
        // GET: /BkHome/
        //public IUserInfoService UserInfoService = new UserInfoService();

        public ActionResult Index()
        {
            ViewBag.Usrs = "admin";
            ViewBag.count = 1;
            //ViewBag.count = VistorInfoService.LoadEnities(a => a.DelFlag != true).Count();
            return View();
        }

        public ActionResult ListInfo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ListInfo(object rows, object page)
        {
            //int pageSize = Request["rows"] == null ? 10 : int.Parse(Request["rows"]);
            //int pageIndex = Request["page"] == null ? 1 : int.Parse(Request["page"]);
            //int total = 0;
            ////var temp = UserInfoService.LoadPageEnities<DateTime?>(pageIndex, pageSize, out total, i => true, o => o.SubTime, false).Select(a => new { a.UserId, a.UserPwd, a.UserName, SubTime = a.SubTime.ToString(), a.RoleId, a.Remark, a.Phone, a.Email, DelFlag = (a.DelFlag == true ? "冻结" : "未冻结") });

            //var data = new { total = total, rows = temp };
            return Json(new { UserId = "11" }, JsonRequestBehavior.AllowGet);
        }


        public ActionResult checkname()
        {
            //string checkName = Request["userName"] == null ? string.Empty : Request["userName"];
            //if (string.IsNullOrEmpty(checkName))
            //{
            //    return Content("false");
            //}
            //var usrInfo = UserInfoService.LoadEnities(a => a.UserName == checkName);
            //if (usrInfo.Count() > 0)
            //{
            //    return Content("false");
            //}

            return Content("true");
        }
        //
        // GET: /BkHome/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // POST: /BkHome/Create

        [HttpPost]
        public ActionResult Create(UserInfo collection)
        {
            //a.UserId, a.UserName, a.SubTime, a.RoleId, a.Remark, a.Phone, a.Email, DelFlag = a.DelFlag
            //UserInfo userInfo = new Model.UserInfo();
            //userInfo.UserName = Request["UserName"];
            //userInfo.Remark = Request["Remark"];
            //userInfo.Phone = Request["Phone"];
            //userInfo.Email = Request["Email"];
            //userInfo.DelFlag = Request["DelFlag"] == "false" ? false : true;
            //collection.UserId = Guid.NewGuid();
            //collection.SubTime = DateTime.Now.ToLocalTime();
            //UserInfo result = UserInfoService.Add(collection);
            var isSuccess = "true";
            //if (result == null)
            //{
            //    isSuccess = "false";
            //}
            //var data = new { errorMsg = isSuccess };
            //return Json(data, JsonRequestBehavior.AllowGet);
            return Content(isSuccess);
        }

        //
        // GET: /BkHome/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /BkHome/Edit/5

        public ActionResult EditUser(UserInfo collection)
        {
            //collection.DelFlag = Request["nameRd"] == "true" ? true : false;
            //collection.UserName = Request["UserName"] == null ? string.Empty : Request["UserName"].Split(',')[0];
            //collection.UserPwd = Request["UserPwd"].Split(',')[0];
            //collection.SubTime = DateTime.Now.ToLocalTime();
            //collection.Phone = Request["Phone"];
            //collection.Remark = Request["Remark"];
            //collection.Email = Request["Email"];
            //var successFlag = true;
            //try
            //{
            //    successFlag = UserInfoService.Update(collection, UserInfoService.LoadEnities(a => a.UserId == collection.UserId).ToList()[0]);
            //}
            //catch (Exception ex)
            //{
            //    successFlag = false;
            //    LogHelper.WriteExceptionInfo(ex, this.HttpContext);
            //}
            var isResult = "false";
            //if (successFlag)
            //{
            //    isResult = "true";
            //}
            return Content(isResult);
        }

        //
        // GET: /BkHome/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /BkHome/Delete/5

        [HttpPost]
        public ActionResult Delete(Guid id)
        {
            //var successFlag = true;
            //UserInfo userInfo = new UserInfo();
            //userInfo.UserId = id;
            //try
            //{
            //    successFlag = UserInfoService.Delete(userInfo, true);
            //}
            //catch (Exception ex)
            //{
            //    successFlag = false;
            //    LogHelper.WriteExceptionInfo(ex, this.HttpContext);
            //}
            var isResult = "false";
            //if (successFlag)
            //{
            //    isResult = "true";
            //}
            var data = new { success = isResult, successMsg = "操作成功", errorMsg = "操作失败，请联系管理员" };
            return Json(data, JsonRequestBehavior.AllowGet);
        }


        public ActionResult WelcomePage()
        {
            return View();
        }
    }
}
