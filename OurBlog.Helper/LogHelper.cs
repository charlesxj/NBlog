using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace OurBlog.Helper
{
    public class LogHelper
    {
        public static Queue<Exception> errorQueue = new Queue<Exception>();
        public static void WriteExceptionInfo(Exception ex, HttpContextBase httpContext)
        {
            errorQueue.Enqueue(ex);
            httpContext.Response.Write("<script>window.top.location.href = '/Error.html'</script>");
            httpContext.Response.Flush();
            httpContext.Response.End();
            //httpContext.Response.Redirect("/Error.html");
        }
    }
}
