using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


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
                (char, double)[] copy = new (char, double)[_output.Length];
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
            if (string.IsNullOrEmpty(Input))
            {
                _output = null;
                return;
            }

            int[] counts = new int[char.MaxValue]; 
            int totalWords = 0;

            int i = 0;
            while (i < Input.Length)
            {
                
                while (i < Input.Length && !char.IsLetter(Input[i])) i++;

             
                if (i < Input.Length && char.IsLetter(Input[i]))
                {
                    char c = char.ToLower(Input[i]);
                    counts[c]++;
                    totalWords++;

                   
                    while (i < Input.Length && Input[i] != ' ') i++;
                }
            }

    
            int unique = 0;
            for (int j = 0; j < counts.Length; j++)
            {
                if (counts[j] > 0)
                    unique++;
            }

            _output = new (char, double)[unique];
            int index = 0;
            for (int j = 0; j < counts.Length; j++)
            {
                if (counts[j] > 0)
                {
                    double percent = Math.Round(counts[j] * 100.0 / totalWords, 4);
                    _output[index++] = ((char)j, percent);
                }
            }

            Array.Sort(_output, (a, b) =>
            {
                int cmp = b.Item2.CompareTo(a.Item2);
                if (cmp != 0) return cmp;
                return a.Item1.CompareTo(b.Item1);
            });
        }

        public override string ToString()
        {
            if (_output == null || _output.Length == 0) return "";
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < _output.Length; i++)
            {
                sb.Append($"{_output[i].Item1} - {_output[i].Item2:F4}");
                if (i < _output.Length - 1)
                    sb.AppendLine();
            }
            return sb.ToString();
        }
    }
}
