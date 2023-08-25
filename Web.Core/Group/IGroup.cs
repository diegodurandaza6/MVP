using Web.Model.Group;

namespace Web.Core.Group
{
    public interface IGroup
    {
        void GetGrouplist(GroupListModel model);
        void GetGroupById(GroupViewModel model);
        void ChnageGroupStatus(GroupViewModel model);
        void CreateGroup(GroupViewModel model);
        void details(GroupViewModel model);
        void AddInGroup(GroupViewModel model);
        void removeingroup(string v);
    }
}
