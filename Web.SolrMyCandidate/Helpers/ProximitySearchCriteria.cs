using System;

namespace Web.SolrMyCandidate.Helpers
{
    [Serializable]
    public class ProximitySearchCriteria
    {
        private const string proximityQueryFormat = @"""{0} {1}""~{2}";

        public string Keyword1 { get; set; }

        public string Keyword2 { get; set; }

        public int Distance { get; set; }

        public override string ToString()
        {
            return string.Format(proximityQueryFormat, Keyword1, Keyword2, Distance);
        }

        public ProximitySearchCriteria()
        {
        }

        public ProximitySearchCriteria(string keyword1, string keyword2, int distance)
        {
            Keyword1 = keyword1;
            Keyword2 = keyword2;
            distance = Distance;
        }
    }
}
