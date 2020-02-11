﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedAPIFramework
{
    public class RandomHelper
    {
        private Random _random;
        public RandomHelper()
        {
            _random = new Random();
        }
        public string RandomString(int num = 10)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            return new string(Enumerable.Repeat(chars, num).Select(s => s[_random.Next(s.Length)]).ToArray());
        }
		public string RandomStringSpecialChars(int num = 10)
        {
            const string chars = "!@#$%^&*_+-=";
            return new string(Enumerable.Repeat(chars, num).Select(s => s[_random.Next(s.Length)]).ToArray());
        }
        public int RandomNumber(int numDigits)
        {
            string min = "1";
            for (int i = 2; i <= numDigits; i++)
            {
                min += "0";
            }
            string max = "";
            for (int i = 1; i <= numDigits; i++)
            {
                max += "9";
            }
            return _random.Next(Convert.ToInt32(min), Convert.ToInt32(max));
        }

    }
}
