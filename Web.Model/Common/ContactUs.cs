namespace Web.Model.Common
{
    public class ContactUs
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Message { get; set; }
        public string SubJect { get; set; }
        public string Email { get; set; }
        public string AdminEmail { get; set; }
        public long typeId { get; set; }
    }
}
