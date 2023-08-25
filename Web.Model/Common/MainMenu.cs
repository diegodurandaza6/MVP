using System.Collections.Generic;

namespace Web.Model.Common
{
    public class MainMenu
    {
        public int MenuId { get; set; }
        public string MenuName { get; set; }

        public IEnumerable<SubMenu> SubMenus { get; set; }
    }

    public class SubMenu
    {
        public int SubMenuId { get; set; }

        public string SubMenuName { get; set; }
        public int MenuId { get; set; }

        public MainMenu MainMenu { get; set; }

        public string Area { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public string Url { get; set; }
        public bool ishidden { get; set; }
        public IEnumerable<SubMenuRole> SubMenuRoles { get; set; }


    }

    public class SubMenuRole
    {
        public int MenuId { get; set; }

        public int SubMenuId { get; set; }

        public int RoleId { get; set; }
    }
}
