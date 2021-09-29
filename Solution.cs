    public class Solution
    {
        public bool IsAlienSorted(string[] words, string order)
        {
            List<AlienTransliteration> transliterations = new List<AlienTransliteration>();
            int asciiCode = 97;
            foreach (char alien in order)
            {
                AlienTransliteration transliteration = new AlienTransliteration();
                transliteration.Alien = alien;
                transliteration.Human = (char)asciiCode;
                transliterations.Add(transliteration);
                asciiCode += 1;
            }

            List<string> humanWords = new List<string>();
            foreach (string word in words)
            {
                string humanWord = "";
                foreach (char alien in word)
                {
                    AlienTransliteration transliteration = transliterations.FirstOrDefault(x => x.Alien == alien);
                    if (transliteration != null)
                    {
                        humanWord += transliteration.Human;
                    }
                }
                humanWords.Add(humanWord);
            }

            return humanWords.SequenceEqual(humanWords.OrderBy(x => x));
        }
    }

    public class AlienTransliteration
    {
        public char Alien { get; set; }
        public char Human { get; set; }
    }
