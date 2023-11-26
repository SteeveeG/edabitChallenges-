using System.Text.RegularExpressions;

namespace EnglishToPigLatinTranslator
{
    public class Translator
    {
        private static List<char> consonant = new()
        {
            'b', 'c', 'd', 'f', 'g', 'h', 'j', 'k', 'l', 'm', 'n', 'p', 'q', 'r', 's', 't', 'v', 'w', 'x', 'y', 'z', 'B',
            'C', 'D', 'F', 'G', 'H', 'J', 'K', 'L', 'M', 'N', 'P', 'Q', 'R', 'S', 'T', 'V', 'W', 'X', 'Y', 'Z'
        };

        private static List<char> vowel = new() { 'a', 'e', 'i', 'o', 'u', 'y', 'A', 'E', 'I', 'O', 'U', 'Y' };
        private static bool firstCharIsUpper;
        private static bool withPunctuation;
        private static int numberOfPunctuation;
        private static Regex regex = new(@"[\p{P}\p{S}-[._]]", RegexOptions.IgnoreCase);
        private static List<int> punctuationIndexOfWord = new();
        private static List<char> backupPunctuationWords = new();

        public static string TranslateWord(string word)
        {
            var firstChar = word[0];
            firstCharIsUpper = char.IsUpper(firstChar);
            word = word.ToLower();
            if (consonant.Contains(firstChar))
            {
        
                CheckPunctuation(ref word, GetNewWordsCount(word));
                word = TranslateConsonant(word);
            }

            else if (vowel.Contains(firstChar))
            {
                CheckPunctuation(ref word, 3);
                word = TranslateVowel(word);
            }

            if (firstCharIsUpper)
            {
                word = char.ToUpper(word[0]) + word.Substring(1);
            }

            if (withPunctuation)
            {
                for (int i = 0; i < backupPunctuationWords.Count; i++)
                {
                    if (punctuationIndexOfWord[i] < word.Length)
                    {
                        word = word.Insert(punctuationIndexOfWord[i], backupPunctuationWords[i].ToString());
                    }
                    else
                    {
                        word += backupPunctuationWords[i].ToString();
                    }
                }
            }
        
            return word;
        }

        private static int GetNewWordsCount(string word)
        {
            var counter = 0;
            foreach (var character in word)
            {
                if (!vowel.Contains(character) && !regex.IsMatch(character.ToString()))
                {
                    counter++;
                }
                else if(vowel.Contains(character))
                {
                    return counter;
                }
            }

            return counter;
        }

        private static void CheckPunctuation(ref string word, int newWordsCount)
        {
            punctuationIndexOfWord = new();
            backupPunctuationWords = new();
            var backupPunctuationIndexOfWord = new List<int>();
            withPunctuation = regex.IsMatch(word);
            numberOfPunctuation = regex.Matches(word).Count;

            if (numberOfPunctuation > 0)
            {
                foreach (Match match in regex.Matches(word))
                {
                    punctuationIndexOfWord.Add(match.Index);
                }

                //Create Backup to use in Foreach because it need to be controlled if 
                //where exacly the punctuation is like at the end of the string or
                //in between of some chars 
 
                backupPunctuationIndexOfWord.AddRange(punctuationIndexOfWord);
                var checkWordLength = word.Length;
                for (int i = punctuationIndexOfWord.Count - 1; i >= 0; i--)
                {
                    if (punctuationIndexOfWord[i] == checkWordLength - 1)
                    {
                        punctuationIndexOfWord[i] += newWordsCount + 1;
                        checkWordLength--;
                    }
                }
                foreach (var punctuationIndex in backupPunctuationIndexOfWord)
                {
                    backupPunctuationWords.Add(word[punctuationIndex]);
                }
                foreach (var punctuationIndex in backupPunctuationIndexOfWord)
                {
                    word = word.Replace(word[punctuationIndex], ' ');
                }
            
                word = word.Trim();
                var newWord = "";
                foreach (var character in word)
                {
                    if (char.IsWhiteSpace(character))
                    {
                        continue;
                    }

                    newWord += character;
                }

                word = newWord;
            }
        }

        private static string TranslateVowel(string word)
        {
            word += "yay";
            return word;
        }

        private static string TranslateConsonant(string word)
        {
            for (var i = 1; i < word.Length; i++)
            {
                if (vowel.Contains(word[i]))
                {
                    var l = word.Substring(0, i);
                    word = word.Remove(0, i);
                    word += l;
                    break;
                }
            }

            word += "ay";
            return word;
        }


        public static string TranslateSentence(string sentence)
        {
            var words = sentence.Split(" ");
            var translatedSentence = ""; 
            var space="";
            foreach (var word in words)
            {
                translatedSentence += $"{space}{TranslateWord(word)}";
                space = " ";
            }

            return translatedSentence;
        }
    }
}