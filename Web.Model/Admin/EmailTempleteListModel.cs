using System.Collections.Generic;
using Web.Model.Common;

namespace Web.Model.Admin
{

    public class EmailTempleteViewModel
    {
        public long groupid;
        public string emailbodyUrl { get; set; }

        public string createdate { get; set; }
        public long isread { get; set; }
        public long sentstatus { get; set; }
        public long email_id { get; set; }
        public long Subscribe { get; set; }
        public long Id { get; set; }
        public string Name { get; set; }
        public string Subject { get; set; }
        public string EmailId { get; set; }
        public string Description { get; set; }
        public string Description1 { get; set; }
        public string Description2 { get; set; }
        public string Description3 { get; set; }
        public long StatusId { get; set; }
        public long UserId { get; set; }
        public long TemplateId { get; set; }
        public string result { get; set; }
        public long ContactId { get; set; }
        public string Email { get; set; }
        public long ClientId { get; set; }
        public long GroupId { get; set; }
        public IEnumerable<EmailTempleteViewModel> Collection { get; set; }
        public IEnumerable<DropDownViewModel> Collectionemailtemplete { get; set; }
        public IEnumerable<DropDownViewModel> Collectionclientcontact { get; set; }

        public IEnumerable<DropDownViewModel> candidategroupcollection { get; set; }

        public string FirstFollowDate { get; set; }
        public long isfollow { get; set; }
        public string thirdfollowdate { get; set; }
        public string secondFollowDate { get; set; }
        public long emailtempleteid { get; set; }
        public long clientcontactId { get; set; }
        public long CreateBy { get; set; }
        public string Group { get; set; }
        public int EmailStatus { get; set; } = 1;
    }

}
