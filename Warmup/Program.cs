using System;

namespace Warmup
{
    public class Program
    {
	public static void Main(string[] argv)
	{
	    Console.WriteLine("je hais emacs");
	    Console.WriteLine(Warmup.IsPalindrome(Console.ReadLine()));
		Console.WriteLine(Warmup.RotChar('C', -30));
		Console.WriteLine(Warmup.RotString("CISCO > MIDLAB", 42));
	}
    }
}

