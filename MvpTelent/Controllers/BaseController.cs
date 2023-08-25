using System.Web.Mvc;

namespace MvpTelent.Controllers
{
    public class BaseController : Controller
    {
        public log4net.ILog logger = log4net.LogManager.GetLogger(typeof(BaseController));
        
    }
}

