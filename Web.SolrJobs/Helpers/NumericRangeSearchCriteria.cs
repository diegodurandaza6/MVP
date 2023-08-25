using System;

namespace Web.SolrJobs.Helpers
{
    [Serializable]
    public class NumericRangeSearchCriteria
    {
        private const string rangeQueryFormat = "[{0} TO {1}]";

        public long UpperLimit { get; set; }

        public long LowerLimit { get; set; }

        public override string ToString()
        {
            return string.Format(rangeQueryFormat, LowerLimit, UpperLimit);
        }

        public NumericRangeSearchCriteria()
        {
        }

        public NumericRangeSearchCriteria(long upperLimit, long lowerLimit)
        {
            UpperLimit = upperLimit;
            LowerLimit = lowerLimit;
        }
    }
}
