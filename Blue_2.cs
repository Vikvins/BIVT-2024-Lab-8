using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8
{
    public class Blue_2 : Blue
    {
        private string _output;
        private string _sequence;

        public string Output
        {
            get { return _output; }
            private set { _output = value; }
        }

        public Blue_2(string input, string sequence) : base(input)
        {
            _sequence = sequence.ToLower();
            _output = string.Empty;
        }

        public override void Review()
        {
            if (Input == null || _sequence == null)
            {
                _output = "";
                return;
            }


            string[] words = Input.Split(new char[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

            string result = "";

            foreach (string word in words)
            {
                string cleanWord = RemovePunctuation(word);

                if (!cleanWord.ToLower().Contains(_sequence))
                {
                    result += word + " ";
                }
            }

            result = result.Trim();

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
            return Output;
        }
    }
}