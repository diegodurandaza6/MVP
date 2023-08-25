namespace Web.Model.Admin
{
    public class RoleViewModel
    {
        public long Id { get; set; }
        public int statusId { get; set; }
        public string Name { get; set; }
        public string PageId { get; set; }
        public long CreateBy { get; set; }
        public string description { get; set; }
    }
}
