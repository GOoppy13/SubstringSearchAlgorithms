using System.Collections.Generic;

namespace SubstringSearchAlgorithms
{
    public class BruteForceAlgorithm : ISubstingSearch
    {
        public string Pattern { get; set; }
        public BruteForceAlgorithm(string pattern)
        {
            Pattern = pattern;
        }
        public ICollection<Match> SubstingSearch(string text)
        {
            List<Match> matches = new List<Match>();
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == Pattern[0])
                {
                    int j = i + 1;
                    int k = 1;
                    bool suitable = true;
                    string substr = text[i].ToString();
                    while (k < Pattern.Length)
                    {
                        if (j == text.Length)
                        {
                            suitable = false;
                            break;
                        }
                        if (text[j] != Pattern[k])
                        {
                            suitable = false;
                            break;
                        }
                        substr += text[j].ToString();
                        j++;
                        k++;
                    }
                    if (suitable)
                    {
                        matches.Add(new Match(substr, i));
                    }
                }
            }
            return matches;
        }
    }
}
