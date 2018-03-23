using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class GarantiPrisValueConverter
    {
        
        public int[] GetIndividualNumbers(string input)
        {
            if (input != string.Empty)
            {
                bool[] stringCanConvertToInt = { false, false };
                string[] temp = input.Split('-');
                int[] numbers = new int[2];

                stringCanConvertToInt[0] = Int32.TryParse(temp[0], out numbers[0]);
                stringCanConvertToInt[1] = Int32.TryParse(temp[1], out numbers[1]);

                if (stringCanConvertToInt[0] && stringCanConvertToInt[1])
                {
                    return numbers;
                }
                return null;
            }
            return null;
        }

        

        public int GetNumberOfWeeksOff(string input) // Need to test and connect this method
        {
            // + symbol to divide the week periods, - symbol to show the range of weeks.
            int ret = 0;
            int[] numbers;
            string[] str = input.Split('+');

            foreach (string item in str)
            {
                if (item.Contains("-"))
                {
                    numbers = GetIndividualNumbers(item);
                    ret += numbers[1] - numbers[0];
                }
                else
                {
                    ret++;
                }
            }
            return ret;
        }

        
        public int NumberOfHours(string input)
        {
            int[] numbers = GetIndividualNumbers(input);
            if(numbers != null)
            {
                int num1 = numbers[0];
                int num2 = numbers[1];
                int ret = 0;
                // Works before pm and between am-pm.
                if ((num1 > 00 && num1 <= 12) && (num2 <= 24 && num2 > 12))
                {
                    ret = (12 - num1) + (num2 - 12);
                }
                // Need to find a solution that fits all possible inputs.
                return ret;
            }
            return 0;
        }
    }
}
