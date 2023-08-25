using System.Collections.Generic;
using Web.Model.Common;

namespace Web.Model.Admin
{
    public class RoleListModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string description { get; set; }

        public long statusId { get; set; }
        public List<DropDownViewModel> Collection { get; set; }
    }
}
