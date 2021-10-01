using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode
{
    public class Solution
    {
        public bool IsAlienSorted(string[] words, string order)
        {
            List<AlienTransliteration> transliterations = new List<AlienTransliteration>();
            int asciiCode = 97;
            foreach (char cipher in order)
            {
                AlienTransliteration transliteration = new AlienTransliteration();
                transliteration.Cipher = cipher;
                transliteration.Plain = (char)asciiCode;
                transliterations.Add(transliteration);
                asciiCode += 1;
            }

            List<string> plainWords = new List<string>();
            foreach (string word in words)
            {
                string plainWord = "";
                foreach (char cipher in word)
                {
                    AlienTransliteration transliteration = transliterations.FirstOrDefault(x => x.Cipher == cipher);
                    if (transliteration != null)
                    {
                        plainWord += transliteration.Plain;
                    }
                }
                plainWords.Add(plainWord);
            }

            return plainWords.SequenceEqual(plainWords.OrderBy(x => x));
        }
    }

    public class AlienTransliteration
    {
        public char Cipher { get; set; }
        public char Plain { get; set; }
    }
}
