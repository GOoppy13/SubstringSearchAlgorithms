using System.Collections.Generic;

namespace SubstringSearchAlgorithms
{
    public interface ISubstingSearch
    {
        ICollection<Match> SubstingSearch(string text);
    }
}
