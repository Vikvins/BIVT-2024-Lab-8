using System;
using System.Text;

namespace Lab_8
{
    public class Blue_3 : Blue
    {
        private (char, double)[] _output;

        public (char, double)[] Output
        {
            get
            {
                if (_output == null) return null;
                var copy = new (char, double)[_output.Length];
                Array.Copy(_output, copy, _output.Length);
                return copy;
            }
        }

        public Blue_3(string input) : base(input)
        {
            _output = null;
        }

        public override void Review()
        {
            if (string.IsNullOrWhiteSpace(Input))
            {
                _output = null;
                return;
            }

            char[] separators = { ' ', '.', '!', '?', ',', ':', '"', ';', '–', '(', ')', '[', ']', '{', '}', '/' };

            
            string[] words = Input.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            int[] charCounts = new int[char.MaxValue];
            int totalWords = 0;

            foreach (string word in words)
            {
                if (word.Length == 0) continue;

                char firstChar = char.ToLower(word[0]);
                if (char.IsLetter(firstChar))
                {
                    charCounts[firstChar]++;
                    totalWords++;
                }
            }

            if (totalWords == 0)
            {
                _output = Array.Empty<(char, double)>();
                return;
            }

            int uniqueLetters = 0;
            for (int i = 0; i < charCounts.Length; i++)
            {
                if (charCounts[i] > 0) uniqueLetters++;
            }

            
            _output = new (char, double)[uniqueLetters];
            int index = 0;

            for (int i = 0; i < charCounts.Length; i++)
            {
                if (charCounts[i] > 0)
                {
                    double percentage = Math.Round(charCounts[i] * 100.0 / totalWords, 4);
                    _output[index++] = ((char)i, percentage);
                }
            }

            
            for (int i = 0; i < _output.Length; i++)
            {
                for (int j = i + 1; j < _output.Length; j++)
                {
                    if (_output[j].Item2 > _output[i].Item2)
                    {
                        var temp = _output[i];
                        _output[i] = _output[j];
                        _output[j] = temp;
                    }
                    else if (_output[j].Item2 == _output[i].Item2)
                    {
                        if (_output[j].Item1 < _output[i].Item1)
                        {
                            var temp = _output[i];
                            _output[i] = _output[j];
                            _output[j] = temp;
                        }
                    }
                }
            }
        }

        public override string ToString()
        {
            if (_output == null || _output.Length == 0)
                return string.Empty;

            var sb = new StringBuilder();
            for (int i = 0; i < _output.Length; i++)
            {
                sb.Append(_output[i].Item1);
                sb.Append(" - ");
                sb.Append(_output[i].Item2.ToString("F4"));

                if (i < _output.Length - 1)
                    sb.AppendLine();
            }

            return sb.ToString();
        }
    }
}