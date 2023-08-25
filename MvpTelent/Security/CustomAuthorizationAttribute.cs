using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using Web.Core.Common;
using Web.Core.Common.Impl;
using Web.Model.Common;

namespace MvpTelent.Security
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple = false, Inherited = true)]
    public class CustomAuthorizationAttribute : AuthorizeAttribute
    {
        public bool DoDatabaseAuthorization { get; set; } = false;
        public new int[] Roles { get; set; }

        public long[] AccountTypes { get; set; }

        ILogin _Ilogin = new LoginService();

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            HttpCookie authCookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
            if (authCookie != null)
            {
                var tuple = ParseUrl.GetComponent(httpContext);
                string actionName = tuple.Item3;
                string controllerName = tuple.Item2;
                string areaName = tuple.Item1;


                FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);
                if (authTicket == null || authTicket.Expired)
                    return false;

                var User = JsonConvert.DeserializeObject<LoginModel>(authTicket.UserData);
                if (User == null) return false;

                IIdentity Identity = new FormsIdentity(authTicket);

                var CustomPrincipal = new CustomPrincipal(Identity, new int[] { User.RoleId }, User.FirstName + " " + User.LastName, User.Email, User.Id, new long[] { User.UsertypeId });
                HttpContext.Current.User = CustomPrincipal;


                var mainMenus = httpContext.Session["Menus"] as IEnumerable<MainMenu>;

                var hasDataRole = true;
                if (DoDatabaseAuthorization)
                {

                    if (mainMenus == null) return false;

                    else
                    {
                        Func<SubMenu, bool> func = x => (x.Action.ToLower() == actionName && x.Controller.ToLower() == controllerName && x.Area.ToLower() == areaName);
                        var submenu = mainMenus.SelectMany(x => x.SubMenus).FirstOrDefault(func);
                        if (submenu != null)
                        {
                            hasDataRole = mainMenus.SelectMany(x => x.SubMenus).SelectMany(x => x.SubMenuRoles).Any(x => x.RoleId == User.RoleId && x.MenuId == submenu.MenuId && x.SubMenuId == submenu.SubMenuId);
                        }
                    }
                }
                var hasRole = true;

                var hasAccountType = true;

                if (AccountTypes != null && AccountTypes.Count() > 0)
                {
                    hasAccountType = AccountTypes.Contains(User.UsertypeId);
                }
                if (Roles != null)
                {
                    hasRole = !Roles.Any(x => CustomPrincipal.Roles.Any(z => z == x));
                }

                return hasRole && hasDataRole && hasAccountType;
            }

            return false;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(
               new { area = "", action = "LogoutAndRedirectToLogin", controller = "home" }
            ));
        }
    }

    public class ParseUrl
    {
        public static Tuple<string, string, string> GetComponent(HttpContextBase httpContext)
        {
            var routeData = RouteTable.Routes.GetRouteData(httpContext);
            var action = routeData.Values["action"];
            var controller = routeData.Values["controller"];
            var area = GetAreaName(routeData);
            string actionName = action == null ? "index" : action.ToString().ToLower();
            string controllerName = controller.ToString().ToLower();
            string areaName = area == null ? "" : area.ToString().ToLower();

            return new Tuple<string, string, string>(areaName, controllerName, actionName);
        }
        private static string GetAreaName(RouteBase route)
        {
            var area = route as IRouteWithArea;
            if (area != null)
            {
                return area.Area;
            }
            var route2 = route as Route;
            if ((route2 != null) && (route2.DataTokens != null))
            {
                return (route2.DataTokens["area"] as string);
            }
            return null;
        }


        private static string GetAreaName(RouteData routeData)
        {
            object obj2;
            if (routeData.DataTokens.TryGetValue("area", out obj2))
            {
                return (obj2 as string);
            }
            return GetAreaName(routeData.Route);
        }
    }

    public class CustomPrincipal : IPrincipal
    {
        IIdentity _Identity;

        public CustomPrincipal(IIdentity Identity, int[] Roles, string Name, string Email, long Id, long[] AccountType)
        {
            _Identity = Identity;
            this.Roles = Roles;
            this.Name = Name;
            this.Email = Email;
            this.Id = Id;
        }

        public IIdentity Identity
        {
            get { return _Identity; }
        }

        public int[] Roles { get; private set; }

        public string Email { get; private set; }

        public string Name { get; private set; }

        public long Id { get; private set; }
        public long[] AccountType { get; set; }

        public bool IsInRole(string role)
        {
            if (int.TryParse(role, out int RoleId))
            {
                return Roles.Contains(RoleId);
            }
            return false;
        }
    }


}