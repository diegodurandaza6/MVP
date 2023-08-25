using System.Collections.Generic;

namespace Web.Model.Group
{

    public class GroupListModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int Status { get; set; } = 1;
        
        public IEnumerable<GroupViewModel> Collection { get; set; }
    }
}
