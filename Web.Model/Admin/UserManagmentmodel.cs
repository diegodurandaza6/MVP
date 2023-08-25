using System.Collections.Generic;
using Web.Model.Common;

namespace Web.Model.Admin
{
    public class UserManagmentmodel
    {


        public long Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string RoleName { get; set; }
        public string LastName { get; set; }
        public string Phoneno { get; set; }
        public long UserId { get; set; }
        public long RoleId { get; set; }
        public long StatusId { get; set; }
        public long AccounttypeId { get; set; }

        public IEnumerable<DropDownViewModel> rolecollection { get; set; }
        public string Createddate { get; set; }
        public List<UserManagmentmodel> UserListcollection { get; set; }
        public string Ids { get; set; }
    }
}
