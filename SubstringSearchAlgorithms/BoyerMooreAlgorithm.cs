using System;
using System.Collections.Generic;

namespace SubstringSearchAlgorithms
{
    public class BoyerMooreAlgorithm : ISubstingSearch
    {
        private Dictionary<char, int> _shifts;
        private int[] _suffShifts;
        public string Pattern { get; set; }
        public BoyerMooreAlgorithm(string pattern)
        {
            Pattern = pattern;
        }
        public ICollection<Match> SubstingSearch(string text)
        {
            CalculationShifts();
            CalculationSuffShifts();
            List<Match> matches = new List<Match>();
            int j = Pattern.Length - 1;
            int i = j;
            while (i < text.Length)
            {
                if (Pattern[j] == text[i])
                {
                    int k = i;
                    while (j >= 0 && Pattern[j] == text[k])
                    {
                        j--;
                        k--;
                    }
                    if (j == -1)
                    {
                        matches.Add(new Match(Pattern, k + 1));
                        i++;
                    }
                    else
                    {
                        i += GetSuffShift(j+1);
                    }
                    j = Pattern.Length - 1;
                }
                else
                {
                    i += GetShift(text[i]);
                }
            }
            return matches;
        }
        private void CalculationShifts()
        {
            _shifts = new Dictionary<char, int>();
            for (int i = Pattern.Length - 2; i >= 0; i--)
            {
                _shifts.TryAdd(Pattern[i], Pattern.Length - i - 1);
            }
        }
        private int GetShift(char c)
        {
            _shifts.TryGetValue(c, out int value);
            return value != 0 ? value : Pattern.Length;
        }
        private void CalculationSuffShifts()
        {
            _suffShifts = new int[Pattern.Length];
            for (int i = Pattern.Length - 1; i >= 0; i--)
            {
                int j = i - 1;
                while (j != -1)
                {
                    if (j == 0 || Pattern[j - 1] != Pattern[i - 1])
                    {
                        bool flag = true;
                        for (int k = j, l = i; k < j + Pattern.Length - i; k++, l++)
                        {
                            if (Pattern[l] != Pattern[k])
                            {
                                flag = false;
                                break;
                            }
                        }
                        if (flag)
                        {
                            _suffShifts[i] = i - j;
                            break;
                        }
                        else
                        {
                            _suffShifts[i] = Pattern.Length;
                        }
                    }
                    j--;
                }
            }
        }
        private int GetSuffShift(int index)
        {
            return _suffShifts[index];
        }
    }
}
