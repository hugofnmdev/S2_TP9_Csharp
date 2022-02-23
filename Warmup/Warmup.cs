using System;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;


namespace Warmup
{
    public class Warmup
    {
		public static bool IsPalindrome(string str)
		{
			str = Regex.Replace(str, @"[^a-zA-Z\._]", "");
			str = str.ToLower();
			int length = str.Length;
			if (str == "" || str == null)
			{
			throw new ArgumentException("str cannot be null or void");
			}
			else
			{
			for (int i = 0; i < length / 2; i++)
			{
				if (str[i] != str[length - i - 1])
				{
				return false;
				}
			}
			return true;
			}
		}

		public static char RotChar(char c, int key)
		{
			{
				int keyLetter = key % 26;
				if (keyLetter < 0)
				{
					keyLetter += 26;
				}
				int keyNumber = key % 10;
				if (keyNumber < 0)
				{
					keyNumber += 10;
				}

				if (c >= 'a' && c <= 'z')
				{
					c = (char) ((c - 'a' + keyLetter) % 26 +'a');
				}
				if (c >= 'A' && c <= 'Z')
				{
					c = (char) ((c - 'A' + keyLetter) % 26 + 'A');
				}
				if (c >= '0' && c <= '9')
				{
					c = (char) ((c - '0' + keyNumber) % 10 + '0');
				}
				return c;
			}
		}	

		public static ulong Fibo(uint n)
        {
            ulong oldnum = 0;
            ulong currnum = 1;

            ulong nextNumber;

            if (n <= 2)
            {
                return  (ulong) n;
            }

            while (n > 1)
            {

                nextNumber = currnum + oldnum;

                oldnum = currnum;
                currnum = nextNumber;
                n--;
            }

            return currnum;
        }

		public static string RotString(string str, int key)
		{
			string rtn = " ";
			foreach (char c in str)
			{
				rtn += RotChar(c,key);
			}
			return rtn;
		}
	}
}
