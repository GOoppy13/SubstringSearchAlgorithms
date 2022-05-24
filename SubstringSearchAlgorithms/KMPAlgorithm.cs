using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubstringSearchAlgorithms
{
    class KMPAlgorithm : ISubstingSearch
    {
        private Dictionary<int, int> _prefix;
        public string Pattern { get; set; }
        public KMPAlgorithm(string pattern)
        {
            Pattern = pattern;
        }
        public ICollection<Match> SubstingSearch(string text)
        {
            List<Match> matches = new List<Match>();
            CalculatePrefix(text);
            for (int i = 0; i < text.Length; i++)
            {
                if (_prefix[Pattern.Length + i + 1] == Pattern.Length)
                {
                    matches.Add(new Match(Pattern, i - Pattern.Length));
                }
            }
            return matches;
        }
        private void CalculatePrefix(string text)
        {
            _prefix = new Dictionary<int, int>();
            _prefix.Add(0, 0);
            text = Pattern + "$" + text;
            for (int i = 1; i < text.Length; i++)
            {
                int k = _prefix[i - 1];
                while (k > 0 && text[i] != text[k])
                {
                    k = _prefix[k - 1];
                }
                if (text[k] == text[i])
                {
                    _prefix.Add(i, k);
                }
            }
        }
    }
}
