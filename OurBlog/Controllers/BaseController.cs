
using OurBlog.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ElecSmoke.Controllers
{
    public class BaseController : ExtendedController
    {
        public UserInfo UserInfo { set; get; }
        #region 处理自动销毁
        public IList<IDisposable> DisposableObjects { get; private set; }
        public BaseController()
        {
            this.DisposableObjects = new List<IDisposable>();
        }
        protected void AddDisposableOject(object obj)
        {
            IDisposable disposable = obj as IDisposable;
            if (null!=disposable)
            {
                this.DisposableObjects.Add(disposable);

            }
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                foreach (IDisposable obj in this.DisposableObjects)
                {
                    if (null != obj)
                    {
                        obj.Dispose();
                    }
                }
            }
        }
        #endregion

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //{
            //    base.OnActionExecuting(filterContext);

            //    var loginUsr = Session["loginUser"] as UserInfo;
            //    string cookieSessionId = Request["sessionId"];
            //    if (string.IsNullOrEmpty(cookieSessionId))
            //    {
            //        Response.Write("<script>window.top.location.href = '/BkLogin/Index'</script>");
            //        Response.Flush();
            //        Response.End();
            //      //  Response.Redirect("BkLogin/Index");
            //    }
            //    var loginUsrJsonStr = CacheHelper.Get(cookieSessionId) as string;
            //    if (string.IsNullOrEmpty(loginUsrJsonStr))
            //    {
            //        Response.Write("<script>window.top.location.href = '/BkLogin/Index'</script>");
            //        Response.Flush();
            //        Response.End();
            //        //Response.Redirect("/BkLogin/Index");
            //    }
            //    else
            //    {
            //        UserInfo = SerializeHelper.DeSerializeStringToObject<UserInfo>(loginUsrJsonStr);
            //        CacheHelper.set(cookieSessionId, loginUsrJsonStr,DateTime.Now.AddMinutes(20));

            //    }
        }


    }
}
