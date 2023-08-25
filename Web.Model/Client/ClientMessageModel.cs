namespace Web.Model.Client
{
    public class ClientMessageModel
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public string Email { get; set; }
        public string PhoneNo { get; set; }
        public string JobPostingUrl { get; set; }
        public string Description { get; set; }
        public string FileName { get; set; }
        public long UserId { get; set; }
    }
}
