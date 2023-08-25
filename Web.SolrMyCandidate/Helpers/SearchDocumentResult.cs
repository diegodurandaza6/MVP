using SolrNet.Attributes;

namespace Web.SolrMyCandidate.Helpers
{
    public class SearchDocumentResult : SearchDocumentNew
    {
        [SolrField("score")]
        public double Score { get; set; }
    }
}
