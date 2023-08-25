using System;

namespace Web.SolrMyCandidate.Helpers
{
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public sealed class SearchResultAttribute : Attribute
    {
        public bool Display { get; set; }

        public bool Highlight { get; set; }
    }
}
