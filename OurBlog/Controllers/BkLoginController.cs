
using OurBlog.Helper;
using OurBlog.IBll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OurBlog.Model;

namespace ElecSmoke.Controllers
{
    public class BkLoginController : BaseController
    {
        //public IUserInfoService UserInfoService = new UserInfoService();

        public IUsersService UsersService { get; private set; }
      
        public BkLoginController(IUsersService usersService)
        {
            this.UsersService = usersService;

            this.AddDisposableOject(usersService);
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult BkLogin()
        {
            string sessionCode = Session["ValidateCode"] == null ? string.Empty : Session["ValidateCode"].ToString();
            string name = Request["LoginCode"];
            string pwd = Request["LoginPwd"];

            if (string.IsNullOrEmpty(name))
            {
                return Json(new { result = "error", info = "用户名不能为空！" });
            }

            if (string.IsNullOrEmpty(name))
            {
                return Json(new { result = "error", info = "密码不能为空！" });
            }

            Session["ValidateCode"] = null;
            string requestCode = Request["vCode"] == null ? string.Empty : Request["vCode"].ToString();

            if (string.IsNullOrEmpty(requestCode))
            {
                return Json(new { result = "error", info = "请输入验证码！" });
            }

            if (!requestCode.Equals(sessionCode))
            {
                return Json(new { result = "error", info = "验证码错误！" });
            }

            user ckusr = this.UsersService.GetLoginUsers(name, pwd).ToList()[0];
            var loginUsr = "ok";

            if (loginUsr == null)
            {
                //   return Content("用户密码错误，登录失败");
                return Json(new { result = "error", info = "用户密码错误，登录失败" });
            }

            Session["loginUser"] = loginUsr;

            string sessionId = Guid.NewGuid().ToString();
            string loginUsrJson = SerializeHelper.SerializeObjectToJson(loginUsr);
            CacheHelper.set(sessionId, loginUsrJson, DateTime.Now.AddMinutes(20));
            Response.Cookies["sessionId"].Value = sessionId;
            return Json(new { result = "ok", info = "登陆成功" });
        }

        #region 验证码
        public ActionResult ShowValidateCode()
        {
            ValidateCode validateCode = new ValidateCode();
            string code = validateCode.CreateValidateCode(4);
            Session["ValidateCode"] = code;
            var byteData = validateCode.CreateValidateGraphic(code);
            return File(byteData, "image/jpeg");
        }
        #endregion



        //
        // GET: /BkLogin/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /BkLogin/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /BkLogin/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /BkLogin/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /BkLogin/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /BkLogin/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /BkLogin/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
