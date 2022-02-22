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
	    int length = str.Length;
	    str = str.Trim();
	    str = str.ToLower();
	    if (str == "" || str == null)
	    {
		throw new ArgumentException("str cannot be null");
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


    
    }
}
