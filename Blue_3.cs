using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8
{
    public class Blue_3 : Blue
    {
        private (char, double)[] _output;

        public (char, double)[] Output
        {
            get { return _output; }
            private set { _output = value; }
        }

        public Blue_3(string input) : base(input)
        {
            _output = new (char, double)[0];
        }

        public override void Review()
        {
            if (Input == null)
            {
                _output = new (char, double)[0];
                return;
            }

            string[] words = Input.Split(new char[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

            int totalWords = 0;
            int[] letterCounts = new int[char.MaxValue];

            foreach (string word in words)
            {
                string cleanWord = RemovePunctuation(word);
                if (cleanWord.Length == 0)
                    continue;

                char firstChar = char.ToLower(cleanWord[0]);

                if (char.IsLetter(firstChar)) 
                {
                    letterCounts[firstChar]++;
                    totalWords++;
                }
            }

            if (totalWords == 0)
            {
                _output = new (char, double)[0];
                return;
            }

            int count = 0;
            for (int i = 0; i < letterCounts.Length; i++)
            {
                if (letterCounts[i] > 0)
                    count++;
            }

            (char, double)[] result = new (char, double)[count];
            int index = 0;
            for (int i = 0; i < letterCounts.Length; i++)
            {
                if (letterCounts[i] > 0)
                {
                    double percentage = (double)letterCounts[i] * 100.0 / totalWords;
                    result[index] = ((char)i, percentage);
                    index++;
                }
            }

            for (int i = 0; i < result.Length - 1; i++)
            {
                for (int j = i + 1; j < result.Length; j++)
                {
                    if (result[i].Item2 < result[j].Item2 ||
                        (result[i].Item2 == result[j].Item2 && result[i].Item1 > result[j].Item1))
                    {
                        var temp = result[i];
                        result[i] = result[j];
                        result[j] = temp;
                    }
                }
            }

            Output = result;
        }

        private string RemovePunctuation(string word)
        {
            char[] punctuations = { '.', '!', '?', ',', ':', '"', ';', '–', '(', ')', '[', ']', '{', '}', '/' };
            string result = "";

            foreach (char c in word)
            {
                if (Array.IndexOf(punctuations, c) == -1)
                {
                    result += c;
                }
            }

            return result;
        }

        public override string ToString()
        {
            if (Output == null || Output.Length == 0)
                return "";

            string result = "";
            for (int i = 0; i < Output.Length; i++)
            {
                result += $"{Output[i].Item1}: {Math.Round(Output[i].Item2, 4)}";
                if (i != Output.Length - 1)
                    result += "\n";
            }

            return result;
        }
    }
}