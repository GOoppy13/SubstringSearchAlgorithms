using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubstringSearchAlgorithms
{
    class BoyerMooreAlgorithm : ISubstingSearch
    {
        private Dictionary<char, int> _shifts;
        private Dictionary<string, int> _suffShifts;
        public string Pattern { get; set; }
        public BoyerMooreAlgorithm(string pattern)
        {
            Pattern = pattern;
        }
        public ICollection<Match> SubstingSearch(string text)
        {
            CalculationShifts();
            CalculationSuffShifts();
            List<Match> matchs = new List<Match>();
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
                        matchs.Add(new Match(Pattern, k + 1));
                        i++;
                    }
                    else
                    {
                        string suff = "";
                        for (int l = k + 1; k <= i; k++)
                        {
                            suff += text[l];
                        }
                        i += GetSuffShift(suff);
                    }
                    j = Pattern.Length - 1;
                }
                else
                {
                    i += GetShift(text[i]);
                }
            }
            return matchs;
        }
        private void CalculationShifts()
        {
            _shifts = new Dictionary<char, int>();
            for (int i = Pattern.Length - 1; i >= 0; i--)
            {
                _shifts.TryAdd(Pattern[i], Pattern.Length - i);
            }
        }
        private int GetShift(char c)
        {
            try
            {
                return _shifts[c];
            }
            catch (Exception)
            {
                return Pattern.Length;
            }
        }
        private void CalculationSuffShifts()
        {
            string suff = "";
            for (int i = Pattern.Length - 1; i > 0; i--)
            {
                suff = suff.Insert(0, Pattern[i].ToString());
                char c = Pattern[i - 1];
                int j = i - 1;
                while (j != -1)
                {
                    if (j == 0 || Pattern[j - 1] != c)
                    {
                        bool flag = true;
                        for (int k = j, l = 0; k < j + suff.Length; k++, l++)
                        {
                            if (suff[l] != Pattern[k])
                            {
                                flag = false;
                                break;
                            }
                        }
                        if (flag)
                        {
                            _suffShifts.Add(suff, i - j);
                            break;
                        }
                    }
                    j--;
                }
            }
        }
        private int GetSuffShift(string suff)
        {
            try
            {
                return _suffShifts[suff];
            }
            catch (Exception)
            {
                return Pattern.Length;
            }
        }
    }
}
