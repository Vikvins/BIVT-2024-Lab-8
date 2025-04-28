using System;

namespace Lab_8
{
    public class Blue_2 : Blue
    {
        private string _output;
        private string _filter;

        public Blue_2(string input, string filter) : base(input)
        {
            _filter = filter;
            _output = null;
        }

        public string Output => _output;

        public override void Review()
        {
            if (string.IsNullOrEmpty(Input) || string.IsNullOrEmpty(_filter)) return;

            string[] words = Input.Split(' ');
            string result = "";
            string separator = "";

            foreach (var word in words)
            {
                if (string.IsNullOrWhiteSpace(word)) continue;

                if (!word.ToLower().Contains(_filter.ToLower()))
                {
                    result += separator + word;
                    separator = " ";
                }
                else
                {
                    if (word.Length > 0 && !char.IsLetter(word[0]))
                    {
                        result += separator + word[0] + word[0];
                        separator = " ";
                    }
                    if (word.Length > 0 && !char.IsLetter(word[word.Length - 1]))
                    {
                        result += word[word.Length - 1];
                        separator = " ";
                    }
                }
            }

            _output = result.Trim();
        }

        public override string ToString()
        {
            if (string.IsNullOrEmpty(_output))
                return string.Empty;
            else
                return _output;
        }
    }
}
