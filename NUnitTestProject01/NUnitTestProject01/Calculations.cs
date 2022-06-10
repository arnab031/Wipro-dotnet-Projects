using System;
namespace NUnitTestProject01
{
	public class Calculations
	{
		public static int Factorial(int n)
        {
			int f = 1;
			for(int i = n; i >= 1; i--)
            {
				f *= i;
            }
			return f;
        }
		public static int Reverse(int n)
        {
			int rev = 0;
            while (n > 0)
            {
				int d = n % 10;
				rev = rev * 10 + d;
				n /= 10;
            }
			return rev;
        }
	}
}

