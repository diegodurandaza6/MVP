using SolrNet.Attributes;

namespace Web.SolrClient.Helpers
{
    public class SearchDocumentResult : SearchDocumentNew
    {
        [SolrField("score")]
        public double Score { get; set; }
    }
}
