using System;
using System.Web.Mvc;
using System.Web.Routing;

namespace MvpTelent.Controllers
{
    public class AuthController : Controller
    {
        public log4net.ILog logger = log4net.LogManager.GetLogger(typeof(BaseController));
        // GET: Base
        //public ActionResult Index()
        //{
        //    return View();
        //}

        protected override void OnAuthorization(AuthorizationContext filterContext)
        {

            if (Session["Id"] == null )
            {
                Session.Abandon();
                Session.Clear();
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                {
                    controller = "Admin",
                    action = "Index"
                }));
            }
             
        }
    }
}

