using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2017.Logic
{
    public class CaptchaCalculator
    {
        public int CalculateCaptch(string input)
        {
            int captchaSum = 0;

            for (int i = 0; i < input.Length - 1; i++)
            {
                if (input[i] == input[i + 1])
                {
                    captchaSum += int.Parse(input[i].ToString());
                }
            }
            //Check the last digit
            if (input[input.Length - 1] == input[0])
            {
                captchaSum += int.Parse(input[input.Length - 1].ToString());
            }

            return captchaSum;
        }

        public int CalculateAdvancedCaptch(string input)
        {

            int captchaSum = 0;

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == input[(i+(input.Length / 2)) % input.Length])
                {
                    captchaSum += int.Parse(input[i].ToString());
                }
            }

            return captchaSum;
        }
    }
}
