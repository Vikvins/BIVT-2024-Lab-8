using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8
{
    public class Blue_4 : Blue
    {
        private int _output;

        public int Output
        {
            get { return _output; }
            private set { _output = value; }
        }

        public Blue_4(string input) : base(input)
        {
            _output = 0;
        }

        public override void Review()
        {
            if (Input == null)
            {
                _output = 0;
                return;
            }

            int sum = 0;
            int currentNumber = 0;
            bool isBuildingNumber = false;

            for (int i = 0; i < Input.Length; i++)
            {
                char c = Input[i];

                if (c >= '0' && c <= '9')
                {
                    currentNumber = currentNumber * 10 + (c - '0');
                    isBuildingNumber = true;
                }
                else
                {
                    if (isBuildingNumber)
                    {
                        sum += currentNumber;
                        currentNumber = 0;
                        isBuildingNumber = false;
                    }
                }
            }

          
            if (isBuildingNumber)
            {
                sum += currentNumber;
            }

            Output = sum;
        }

        public override string ToString()
        {
            return Output.ToString();
        }
    }

}
