using System;
using System.Collections.Generic;
using System.Numerics;

namespace SubstringSearchAlgorithms
{
    public class RabinKarpAlgorithm : ISubstingSearch
    {
        private const ulong mod = 4294967296;
        private const ulong primeInt = 31;
        public string Pattern { get; set; }
        public RabinKarpAlgorithm(string pattern)
        {
            Pattern = pattern;
        }
        public ICollection<Match> SubstingSearch(string text)
        {
            List<Match> matches = new List<Match>();

            ulong alphabetSize = 256;
            ulong patternHash = Pattern[0] % mod;
            ulong textHash = text[0] % mod;
            ulong firstIndexHash = 1;

            for (int i = 1; i < Pattern.Length; i++)
            {
                patternHash *= alphabetSize;
                patternHash += Pattern[i];
                patternHash %= mod;

                textHash *= alphabetSize;
                textHash += text[i];
                textHash %= mod;

                firstIndexHash *= alphabetSize;
                firstIndexHash %= mod;
            }

            for (int i = 0; i <= text.Length - Pattern.Length; i++)
            {
                if (patternHash == textHash)
                {
                    int k = 0;
                    bool flag = false;
                    for (int j = i; j < i + Pattern.Length; j++, k++)
                    {
                        if (text[j] != Pattern[k])
                        {
                            flag = true;
                            break;
                        }
                    }
                    if (!flag)
                    {
                        matches.Add(new Match(Pattern, i));
                    }
                }

                if (i == (text.Length - Pattern.Length))
                {
                    break;
                }

                textHash -= (text[i] * firstIndexHash) % mod;
                textHash += mod;
                textHash *= alphabetSize;
                textHash += text[i + Pattern.Length];
                textHash %= mod;
            }

            return matches;
        }
    }
}
