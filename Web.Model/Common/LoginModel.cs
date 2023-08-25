using System.Collections.Generic;

namespace Web.Model.Common
{
    public class LoginModel
    {


        public IEnumerable<DropDownViewModel> Collection { get; set; }
        public string IsSubscribed { get; set; }
        public string msg { get; set; }
        public string Subscribedtext { get; set; }
        public string ids { get; set; }
        public long Id { get; set; }
        public long UserId { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public long Status { get; set; }
        public string Company { get; set; }
        public long UsertypeId { get; set; }
        public string UsertypeName { get; set; }
        public string oldPassword { get; set; }
        public string NewPassword { get; set; }
        public string Phone { get; set; }
        public long AccountType { get; set; }
        public string Title { get; set; }
        public long CompanyuserTypeid { get; set; }
        public string Resumefile { get; set; }
        public string ContactId { get; set; }
        public string Image { get; set; }
        public string ClientLogo { get; set; }
        public long KeepLogIn { get; set; }
        public string location { get; set; }

        public long CompanyId { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public IEnumerable<LocationDropdown> CollectionLocation { get; set; }
        public string FilePath { get; set; }
        public string FileName { get; set; }

    }
}
