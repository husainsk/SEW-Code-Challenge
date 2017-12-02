using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SEWCodeChallenge
{
    class Program
    {
         static void Main(string[] args)
            {
                string[] wordsForProblem = System.IO.File.ReadAllLines(@"C:\SEWCodeChallenge\SEWCodeChallenge\SEWCodeChallenge\WordList\wordlist.txt");
                //string[] wordsForProblem = { "cat", "cats", "catsdogcats","dog", "dogcatsdog", "hippopotamuses", "rat", "ratcatdogcat"};

                FindConcatenatedtWords(wordsForProblem);
            }


            public static void FindConcatenatedtWords(string[] listOfWords)
            {
                bool largestWord = false;
                bool secondLargestWord = false;
                int count = 0;
                if (listOfWords == null) throw new ArgumentNullException("listOfWords");
                var sortedWords = listOfWords.OrderByDescending(word => word.Length).ToList();
                var dict = new HashSet<String>(sortedWords);
                foreach (var word in sortedWords)
                {
                    if (isMadeOfWords(word, dict))
                    {
                        if (largestWord & !secondLargestWord)
                        {
                            Console.WriteLine(word);
                            secondLargestWord = true;
                        }

                        if (!largestWord)
                        {
                            Console.WriteLine(word);
                            largestWord = true;
                        }

                        count++;
                    }
                }
                Console.WriteLine(count);
                Console.Read();
            }

            private static bool isMadeOfWords(string word, HashSet<string> dict)
            {
                if (String.IsNullOrEmpty(word)) return false;
                if (word.Length == 1)
                {
                    if (dict.Contains(word)) return true;
                    else return false;
                }
                foreach (var pair in generatePairs(word))
                {
                    if (dict.Contains(pair.Item1))
                    {
                        if (dict.Contains(pair.Item2))
                        {
                            return true;
                        }
                        else
                        {
                            if (isMadeOfWords(pair.Item2, dict) == true) return true;

                        }
                    }
                }
                return false;
            }

            private static List<Tuple<string, string>> generatePairs(string word)
            {
                var output = new List<Tuple<string, string>>();
                for (int i = 1; i < word.Length; i++)
                {
                    output.Add(Tuple.Create(word.Substring(0, i), word.Substring(i)));
                }
                return output;
            }

        }
    }






