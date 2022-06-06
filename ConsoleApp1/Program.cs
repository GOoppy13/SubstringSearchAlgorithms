using SubstringSearchAlgorithms;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = "Степан";
            var algms = new List<ISubstingSearch>()
            {
                new BruteForceAlgorithm(pattern),
                new RabinKarpAlgorithm(pattern),
                new KMPAlgorithm(pattern),
                new BoyerMooreAlgorithm(pattern),
            };
            string text = null;
            using (StreamReader sr = new StreamReader(@"C:\Users\ZeroSector\Desktop\Папки\различные ресурсы\Анна_Каренина.txt"))
            {
                text = sr.ReadToEnd();
            }
            Stopwatch sw = new Stopwatch();
            for (int i = 0; i < algms.Count; i++)
            {
                sw.Restart();
                Console.WriteLine(algms[i].SubstingSearch(text).Count);
                sw.Stop();
                Console.WriteLine(algms[i].GetType().ToString().Split('.')[1] + ": " + sw.ElapsedMilliseconds);
            }
            Console.ReadKey();
        }
    }
}
