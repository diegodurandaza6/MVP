using System.Collections.Generic;

namespace Web.Model.Admin
{
    public class Dashboardmodel
    {

        public IEnumerable<EnquiresViewModel> Collection { get; set; }
        public long Id { get; set; }
        public long ClientId { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public long UserId { get; set; }
        public long Companycount { get; set; }
        public long Candidatecount { get; set; }
        public long Enquirescount { get; set; }
        public string Subject { get; set; }
        public long InterviewCount { get; set; }
        public long GeneralMessagesCount { get; set; }
        public long InterviewsRequestCount { get; set; }
        public long SharedJobCount { get; set; }
        public string Email { get; set; }
        public string Date { get; set; }
        public string Description { get; set; }
        public long TypeId { get; set; }

        public IEnumerable<Dashboardmodel> mettingschedulecollection { get; set; }

        public IEnumerable<Dashboardmodel> UpcomingInterviewscolloction { get; set; }

        public long Jobcount { get; set; }

        public long InterviewsRequestCount_Candidate { get; set; }
    }
}
