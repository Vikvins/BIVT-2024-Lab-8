using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8
{
    public class Blue_1 : Blue
    {
        private string[] _output;
        public string[] Output => _output == null ? null : (string[])_output.Clone();

        public Blue_1(string input) : base(input)
        {
            _output = null;
        }

        public override void Review()
        {
            if (Input == null || Input.Trim().Length == 0)
            {
                _output = null;
                return;
            }

            string[] words = Input.Split(' ');

            int wordCount = 0;
            foreach (string word in words)
            {
                if (word != null && word.Length > 0)
                    wordCount++;
            }

            string[] filteredWords = new string[wordCount];
            int index = 0;
            foreach (string word in words)
            {
                if (word != null && word.Length > 0)
                {
                    filteredWords[index] = word;
                    index++;
                }
            }

            string[] tempLines = new string[wordCount];
            int lineCount = 0;
            string currentLine = "";

            foreach (string word in filteredWords)
            {
                if (currentLine.Length == 0)
                {
                    currentLine = word;
                }
                else if (currentLine.Length + 1 + word.Length <= 50)
                {
                    currentLine += " " + word;
                }
                else
                {
                    tempLines[lineCount] = currentLine;
                    lineCount++;
                    currentLine = word;
                }
            }

            if (currentLine.Length > 0)
            {
                tempLines[lineCount] = currentLine;
                lineCount++;
            }

            _output = new string[lineCount];
            for (int i = 0; i < lineCount; i++)
            {
                _output[i] = tempLines[i];
            }
        }

        public override string ToString()
        {
            if (_output == null) return null;
            else
            {
                string result = "";
                for (int i = 0; i < _output.Length; i++)
                {
                    if (i > 0)
                        result += Environment.NewLine;
                    result += _output[i];
                }
                return result;
            }
        }
    }
}
