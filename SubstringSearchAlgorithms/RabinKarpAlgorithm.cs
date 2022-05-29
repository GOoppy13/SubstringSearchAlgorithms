using System.Collections.Generic;

namespace SubstringSearchAlgorithms
{
    public class RabinKarpAlgorithm : ISubstingSearch
    {
        private int _hashPattern;
        public string Pattern { get; set; }
        public RabinKarpAlgorithm(string pattern)
        {
            Pattern = pattern;
        }
        public ICollection<Match> SubstingSearch(string text)
        {
            _hashPattern = Pattern.GetHashCode();
            List<Match> matches = new List<Match>();
            if (text.Length >= Pattern.Length)
            {
                string substr = "";
                for (int i = 0; i < Pattern.Length - 1; i++)
                {
                    substr += text[i];
                }
                for (int j = Pattern.Length - 1; j < text.Length; j++)
                {
                    substr += text[j];
                    int hash = substr.GetHashCode();
                    if (hash == _hashPattern)
                    {
                        bool flag = true;
                        for (int i = 0, k = j - Pattern.Length + 1; i < Pattern.Length; i++, k++)
                        {
                            if (Pattern[i] != text[k])
                            {
                                flag = false;
                                break;
                            }
                        }
                        if (flag)
                        {
                            matches.Add(new Match(substr, j - Pattern.Length + 1));
                        }
                    }
                    substr = substr.Remove(0, 1);
                }
            }
            return matches;
        }
    }
}
