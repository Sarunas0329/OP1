using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Kontrolinis
{
    internal class TaskUtils
    {
        public static void PerformTask(string fin, string fout)
        {
            string noNumbers = "";
            using (StreamReader reader = new StreamReader(fin))
            {
                string punctuation = reader.ReadLine();
                string line;
                using (StreamWriter writer = new StreamWriter(fout))
                {
                    while ((line = reader.ReadLine()) != null)
                    {
                        string longestWord = FindWord1Line(line, punctuation);
                        string editedLine = EditLine(line, punctuation, longestWord);
                        writer.WriteLine(editedLine);
                        string noNumberWord = FindWord2Line(line, punctuation);
                        noNumberWord = Regex.Match(noNumberWord, @"\w+").Value;
                        noNumbers += $"{noNumberWord}\r\n";
                    }
                    writer.WriteLine(noNumbers);
                }
            }

        }
        public static bool NoDigits(string line)
        {
            Match m = Regex.Match(line, "[0-9]");
            if(m.Success)
            {
                return true;
            }
            return false;
            
        }
        public static int NumberDifferentVowelsInLine(string line)
        {
            int count = 0;
            char[] vowels = { 'a', 'e', 'i', 'o', 'u' };
            for (int i = 0; i < vowels.Length; i++) 
            {
                if (line.Contains(vowels[i]))
                {
                    count++;
                }
            }

            return count;
        }
        public static string FindWord1Line(string line, string punctuation)
        {
            string[] words = Regex.Split(line, punctuation);
            string longestWord = "";
            foreach (string word in words)
            {
                if (NumberDifferentVowelsInLine(word) >= 3)
                {
                    if (word.Length > longestWord.Length)
                    {
                        longestWord = word;
                    }
                }
            }
            return longestWord;
        }
        public static string EditLine(string line, string punctuation, string word)
        {
            Match match = Regex.Match(line, $@"({punctuation}|^){word}");
            line = match.Value + "" + line.Remove(match.Index, match.Value.Length);
            return line;
        }
        public static string FindWord2Line(string line, string punctuation)
        {
            string noNumberWord = "";

            foreach (Match match in Regex.Matches(line, $@"({punctuation}|^)\w+"))
            {
                string word = Regex.Match(match.Value, @"\w+").Value;
                if(!NoDigits(word))
                {
                    noNumberWord = word;
                }
            }
            return noNumberWord;
        }
    }
}
