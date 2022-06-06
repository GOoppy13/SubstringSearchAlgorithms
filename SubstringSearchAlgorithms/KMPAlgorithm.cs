using System.Collections.Generic;

namespace SubstringSearchAlgorithms
{
    public class KMPAlgorithm : ISubstingSearch
    {
        public string Pattern { get; set; }
        public KMPAlgorithm(string pattern)
        {
            Pattern = pattern;
        }
        public ICollection<Match> SubstingSearch(string text)
        {
            List<Match> matches = new List<Match>();
            List<int> _prefix = new List<int>();
            _prefix.Add(0);
            int k;
            for (int i = 1; i < Pattern.Length; ++i)
            {
                k = _prefix[i - 1];
                while (k > 0 && Pattern[i] != Pattern[k])
                {
                    k = _prefix[k - 1];
                }
                if (Pattern[k] == Pattern[i])
                {
                    k++;
                }
                _prefix.Add(k);
            }
            k = 0;
            for (int i = 0; i < text.Length; ++i)
            {
                while (k > 0 && text[i] != Pattern[k])
                {
                    k = _prefix[k - 1];
                }
                if (Pattern[k] == text[i])
                {
                    k++;
                }
                if (k == Pattern.Length)
                {
                    matches.Add(new Match(Pattern, i - Pattern.Length + 1));
                    k = _prefix[k];
                }
                _prefix.Add(k);
            }
            return matches;
        }
    }
}
