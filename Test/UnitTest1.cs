using System;
using Xunit;
using SubstringSearchAlgorithms;
using System.Linq;
using System.Collections.Generic;

namespace Test
{
    public class UnitTest1
    {
        [Fact]
        public void AaaaaTest()
        {
            string pattern = "aa";
            var algms = new List<ISubstingSearch>()
            {
                new BruteForceAlgorithm(pattern),
                new RabinKarpAlgorithm(pattern),
                new BoyerMooreAlgorithm(pattern),
                new KMPAlgorithm(pattern)
            };
            string text = "aaaaaaaaaa";
            var expected = Enumerable.Range(0, 9).ToList();
            foreach(var algm in algms)
            {
                var actual = algm.SubstingSearch(text).ToList();
                Assert.Equal(9, actual.Count);
                for (int i = 0; i < 9; i++)
                {
                    Assert.Equal(expected[i], actual[i].Position);
                }
            }
        }
        [Fact]
        public void Test()
        {
            string pattern = "aaab";
            var algms = new List<ISubstingSearch>()
            {
                new BruteForceAlgorithm(pattern),
                new RabinKarpAlgorithm(pattern),
                new BoyerMooreAlgorithm(pattern),
                new KMPAlgorithm(pattern)
            };
            string text = "aaabbbababbaaababaab";
            var expected = new List<int>() { 0, 11 };
            foreach (var algm in algms)
            {
                var actual = algm.SubstingSearch(text).ToList();
                Assert.Equal(2, actual.Count);
                for (int i = 0; i < 2; i++)
                {
                    Assert.Equal(expected[i], actual[i].Position);
                }
            }
        }
    }
}
