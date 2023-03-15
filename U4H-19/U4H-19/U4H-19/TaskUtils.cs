using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Data;

namespace U4H_19
{
    internal class TaskUtils
    {
        /// <summary>
        /// Reads and does all needed tasks and prints to a result file.
        /// </summary>
        /// <param name="fin1">First data file</param>
        /// <param name="fin2">Second data file</param>
        /// <param name="fout">Output file</param>
        /// <param name="fbook">Book output file</param>
        public static void Process(string fin1, string fin2, string fout, string fbook)
        {
            string line1;
            string line2;

            bool duplicate = false;

            List<string> CommonWords = new List<string>();
            List<string> NotCommonWords = new List<string>();
            List<string> LongestWords = new List<string>();

            char[] punctuation = { ' ', '.', ',', '!', '?', '.', ':', ';', '(', ')', '\t', '\r', '\n', '\'', '"' };

            int maxLength = 0;
            string maxLine = "";

            string dashes = new string('-', 38);
            using (StreamReader reader1 = new StreamReader(fin1, Encoding.UTF8))  
            {
                
                    while ((line1 = reader1.ReadLine()) != null)
                    {
                        string[] words1 = line1.Split(punctuation, StringSplitOptions.RemoveEmptyEntries);

                        for (int i = 0; i < words1.Length; i++)
                        {
                            using (StreamReader reader2 = new StreamReader(fin2, Encoding.UTF8))
                            {
                                while ((line2 = reader2.ReadLine()) != null)
                                {
                                    string[] words2 = line2.Split(punctuation);
                                    if (words2.Contains(words1[i]))
                                    {

                                        duplicate = true;

                                    }
                                }
                                if (!duplicate)
                                {

                                    NotCommonWords.Add(words1[i]);
                                }
                                else
                                {
                                    CommonWords.Add(words1[i]);
                                }
                                duplicate = false;
                            }
                        }
                        int tempMax = GetLongestWordLenght(NotCommonWords);
                        if (tempMax > maxLength)
                        {
                            maxLength = tempMax;
                        }
                    }
                  
                
            }
            List<int> Repetitions = new List<int>();
            LongestWords = CreateLongestWordList(NotCommonWords, maxLength);
            for (int i = 0; i < LongestWords.Count; i++)
            {
                int count = 0;
                using (StreamReader reader1 = new StreamReader(fin1, Encoding.UTF8))
                {
                    while ((line1 = reader1.ReadLine()) != null)
                    {
                        string[] words1 = line1.Split(punctuation, StringSplitOptions.RemoveEmptyEntries);
                        count += GetRepetitions(words1, LongestWords[i]);
                    }
                    Repetitions.Add(count);
                }
            }                   
            SortLongestWords(ref LongestWords);
            int firstLineNr = -1;
            int secondLineNr = -1;
            int x = -1;
            int y = -1;
            using (StreamReader reader1 = new StreamReader(fin1, Encoding.UTF8))
            {
                while ((line1 = reader1.ReadLine()) != null)
                {
                    x++;
                    using (StreamReader reader2 = new StreamReader(fin2, Encoding.UTF8))
                    {
                        
                        while ((line2 = reader2.ReadLine()) != null)
                        {
                            y++;
                            if(line2 == line1 && line1.Count() > 2 && line1.Length > maxLine.Length)
                            {
                                maxLine = line1;
                                firstLineNr = x+1;
                                secondLineNr = y;
                            }
                        }
                        
                    }
                    y = 0;
                }

            }
            using (StreamWriter writer = new StreamWriter(fbook))
            {
                using (StreamReader reader1 = new StreamReader(fin1, Encoding.UTF8))
                {
                    using (StreamReader reader2 = new StreamReader(fin2, Encoding.UTF8))
                    {
                        string text1 = reader1.ReadToEnd();
                        string text2 = reader2.ReadToEnd();
                        string output = "";
                        while (text1 != "")
                        {
                            string word = "";
                            word = Regex.Match(text2, @"\w+", RegexOptions.IgnoreCase).Value;

                            int index = text1.IndexOf(word);
                            if (index == -1)
                            {
                                output += text1 + " ";
                                break;
                            }
                            else
                            {
                                output += text1.Substring(0, index);
                                text1 = text1.Remove(0, index + word.Length);
                                Match match = Regex.Match(text1, @"\w");
                                if (match.Success)
                                {
                                    text1 = text1.Remove(0, match.Index);
                                }
                                else
                                {
                                    text1 = "";
                                }
                            }

                            string temp = text1;
                            text1 = text2;
                            text2 = temp;
                        }

                        output += text2;
                        writer.WriteLine(output);

                    }
                }
                
            }

            
            using (var writer = File.CreateText(fout))
            {
                writer.WriteLine("| {0,-20} | {1,-12} |", "Longest Word", "Repetitions");
                writer.WriteLine(dashes);
                for (int i = 0; i < LongestWords.Count; i++)
                {
                    writer.WriteLine("| {0,-20} | {1,12} |", LongestWords[i], Repetitions[i]);
                }
                writer.WriteLine(dashes);
                writer.WriteLine("Ilgiausias teksto fragmentas");
                writer.WriteLine(dashes);
                writer.WriteLine(maxLine);
                writer.WriteLine("The line position of the first file is {0}", firstLineNr);
                writer.WriteLine("The line position of the secont file is {0}", secondLineNr);
                writer.WriteLine(dashes);
            }
        }

        /// <summary>
        /// Finds the maximum length of words in a list
        /// </summary>
        /// <param name="input">A list of words</param>
        /// <returns>The maximum word length</returns>
        public static int GetLongestWordLenght(List<string> input)
        {
            int max = 0;
            for(int i = 0; i < input.Count; i++)
            {
                if (input[i].Length > max )
                {
                    max = input[i].Length;
                }
            }
            return max;
        }

        /// <summary>
        /// Creates a new list of the longest words
        /// </summary>
        /// <param name="input">A list of words</param>
        /// <param name="max">The maximum word length</param>
        /// <returns></returns>
        public static List<string> CreateLongestWordList(List<string> input, int max)
        {
            
            List<string> wordList = new List<string>();
            while (max != 0)
            {
                for (int i = 0; i < input.Count; i++)
                {
                    if (input[i].Length == max && !wordList.Contains(input[i]))
                    {
                        if (wordList.Count < 10 || i != input.Count - 1)
                        {
                            wordList.Add(input[i]);
                        }
                        else break;
                    }

                    
                }
                max--;
            }
            return wordList;
        }
        /// <summary>
        /// Finds the repetitions of a word
        /// </summary>
        /// <param name="input1">A string array of words</param>
        /// <param name="word">Specific word you want to find repetitions for</param>
        /// <returns>How many times the word is repeated</returns>
        public static int GetRepetitions(string[] input1, string word)
        {
            int count = 0;
            for (int i = 0; i < input1.Length; i++) 
            {
                if(word == input1[i])
                {
                    count++;
                }
            }
            return count;
        }
        /// <summary>
        /// Sorts a list of words by descending order
        /// </summary>
        /// <param name="input">A list of words</param>
        public static void SortLongestWords(ref List<string> input)
        {
            for (int i = 0; i < input.Count - 1; i++) 
            {
                for (int j = 0; j < input.Count - 1 - i; j++)
                {
                    if (input[j].Length < input[j+1].Length)
                    {
                        string temp = input[j];
                        input[j] = input[j+1]; 
                        input[j+1] = temp;
                    }
                }
            }
        }
    }
}
