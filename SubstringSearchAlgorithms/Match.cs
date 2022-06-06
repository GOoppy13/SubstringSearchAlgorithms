namespace SubstringSearchAlgorithms
{
    public class Match
    {
        public string Substring { get; private set; }
        public int Position { get; private set; }
        public Match(string substring, int pos)
        {
            Substring = substring;
            Position = pos;
        }
    }
}
