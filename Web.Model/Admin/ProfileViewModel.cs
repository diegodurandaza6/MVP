using System.Collections.Generic;
using Web.Model.Common;

namespace Web.Model.Admin
{
    public class ProfileViewModel
    {
        public string locationKey { get; set; }

        public string companywebsite { get; set; }

        public long UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }
        public string LastName { get; set; }
        public string FileName { get; set; }
        public IEnumerable<DropDownViewModel> CountryCollection { get; set; }
        public IEnumerable<DropDownViewModel> StateCollection { get; set; }
        public long CountryId { get; set; }
        public long StateId { get; set; }
        public string CityName { get; set; }
        public string CompanyName { get; set; }
        public string location { get; set; }
    }
}
