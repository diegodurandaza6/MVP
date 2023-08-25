using System.Data;
using Web.Dal.Group;
using Web.Model.Group;

namespace Web.Core.Group.Impl
{
    public class GroupService : IGroup
    {
        GroupFactory _objGroupFactory = new GroupFactory();
        GroupDel _objGroup = new GroupDel();

        DataTable dt = new DataTable();
        DataSet ds = new DataSet();

        public void AddInGroup(GroupViewModel model)
        {
            _objGroup.AddInGroup(model);
        }

        public void ChnageGroupStatus(GroupViewModel model)
        {
            _objGroup.ChnageGroupStatus(model);
        }

        public void CreateGroup(GroupViewModel model)
        {
            _objGroup.CreateGroup(model);
        }
        public void details(GroupViewModel model)
        {
            ds = _objGroup.details(model);
            _objGroupFactory.details(model, ds);
        }
        public void GetGroupById(GroupViewModel model)
        {
            dt = _objGroup.GetGroupById(model);
            _objGroupFactory.GetGroupById(model, dt);
        }

        public void GetGrouplist(GroupListModel model)
        {
            dt = _objGroup.GetGrouplist(model);
            _objGroupFactory.GetGrouplist(model, dt);
        }

        public void removeingroup(string Id)
        {
            _objGroup.removeingroup(Id);
        }
    }
}
