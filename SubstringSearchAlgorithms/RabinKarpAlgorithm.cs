using System;
using System.Collections.Generic;

namespace SubstringSearchAlgorithms
{
    public class RabinKarpAlgorithm : ISubstingSearch
    {
        private const ulong mod = 4294967296;
        private const int primeInt = 53;
        private ulong _powPrimeInt;
        private ulong _hashPattern;
        public string Pattern { get; set; }
        public RabinKarpAlgorithm(string pattern)
        {
            Pattern = pattern;
            _powPrimeInt = (ulong)Math.Pow(primeInt, Pattern.Length - 1);
            _hashPattern = GetHashCode(0, Pattern.Length, Pattern);
        }
        public ICollection<Match> SubstingSearch(string text)
        {
            ulong _hashText = GetHashCode(0, Pattern.Length, text);
            List <Match> matches = new List<Match>();
            text += " ";
            for (int i = 0; i < text.Length - Pattern.Length; i++)
            {
                if (_hashPattern == _hashText)
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
                _hashText -= text[i];
                _hashText /= primeInt;
                _hashText += _powPrimeInt * text[i + Pattern.Length];
            }
            return matches;
        }
        private ulong GetHashCode(int start, int end, string str)
        {
            ulong result = 0;
            for (int i = start, j = 0; i < end; i++, j++)
            {
                result += (ulong)Math.Pow(primeInt, j) * str[i];
            }
            return result;
        }
    }
}
