using System.Collections.Generic;

namespace Web.Model.Admin
{
    public class Alertmodel
    {
        public string lastsentdate;

        public string location { get; set; }


        public IEnumerable<Alertmodel> alertjobcollection { get; set; }

        public long Id { get; set; }

        public string Email { get; set; }
        public long StatusId { get; set; }
        public long CreateBy { get; set; }
        public long AlertId { get; set; }
        public string JobTitle { get; set; }
        public string AlertName { get; set; }
        public string Name { get; set; }
        public string Createddate { get; set; }
    }
}
