using System;
using System.Linq;

namespace CSharpPracticum.Common
{
    public static class StringExtensions
    {
        public static bool IsPalindrome(this string str)
        {
            string clean = new string(str.ToLower().Where(c => !char.IsWhiteSpace(c)).ToArray());
            return clean.SequenceEqual(clean.Reverse());
        }

        public static int WordCount(this string str)
        {
            return str.Split(new[] { ' ', ',', '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries).Length;
        }

        public static string ReverseString(this string str)
        {
            char[] charArray = str.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}