using System;
using System.Collections.Generic;

namespace Web.SolrJobs.Helpers
{
    [Serializable]
    public class FuzzySearchCriteria
    {
        public List<string> SplitOnSpace(string text)
        {
            return AsList(text, " ");
        }

        public static string[] TrimStringArray(string[] split)
        {
            if (split == null)
            {
                return split;
            }

            for (var i = 0; i < split.Length; ++i)
            {
                if (split[i] == null)
                    continue;
                split[i] = split[i].Trim();
            }
            return split;
        }

        public static bool IsNullOrEmpty(string str)
        {
            return String.IsNullOrEmpty(str);
        }

        public List<string> AsList(string str, string delimeter, bool ignoreEmptyItems = true)
        {
            var split = IsNullOrEmpty(str) ? new string[] { } : str.Split(new string[] { delimeter }, StringSplitOptions.None);
            var result = new List<string>();
            result.AddRange(ignoreEmptyItems ? TrimStringArray(split) : split);
            return result;
        }

        private const string fuzzyQueryFormat = @"{0}~{1}";

        public string SearchWord { get; set; }

        public int EditDistance { get; set; }

        public List<string> GetQuery()
        {
            var list = new List<string>();
            SplitOnSpace(SearchWord).ForEach(s => list.Add(string.Format(fuzzyQueryFormat, s, EditDistance)));
            return list;
        }

        public override string ToString()
        {
            return string.Format(fuzzyQueryFormat, SearchWord, EditDistance);
        }

        public FuzzySearchCriteria()
        {
        }

        public FuzzySearchCriteria(string searchWord, int editDistance)
        {
            SearchWord = searchWord;
            EditDistance = editDistance;
        }
    }
}
