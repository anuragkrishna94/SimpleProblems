namespace LeetCodeProblems
{
    internal class LongestPalindromicSubString
    {
        public static void Solve()
        {
            string s;
            Console.WriteLine("Enter string");
            s = Console.ReadLine();
            Console.WriteLine($"Longest Palindromic SubString: {Solution.LongestPalindrome(s)}");
        }
    }

    internal static class Solution
    {
        public static string LongestPalindrome(string s)
        {
            int sLen = s.Length;
            if (sLen == 1) return s;
            string palindromicString = "";
            for (int i = 0; i < sLen; i++)
            {
                if (palindromicString.Length > sLen - i - 1) return palindromicString;
                int left = i, right = s.GetLastIndexOfCFromPivot(s[i], sLen, i);
                int end = right;
                bool isPal = false;
                while (i < end)
                {
                    left = i; right = end;
                    if (palindromicString.Length > end - i)
                    {
                        isPal = false;
                        break;
                    }
                    while (left < right && s[left] == s[right])
                    {
                        left++;
                        right--;
                    }
                    if (s[left] != s[right] && left < sLen && right > -1)
                    {
                        isPal = false;
                        end = s.GetLastIndexOfCFromPivot(s[i], end, i);
                    }
                    else
                    {
                        isPal = true;
                        break;
                    }
                }
                if (isPal) palindromicString = (i < end) ? s.Substring(i, end - i + 1) : s[i].ToString();
            }
            if (sLen > 0 && palindromicString.Length == 0) palindromicString = s[0].ToString();
            return palindromicString;
        }
    }
    internal static class StringExtension
    {
        public static int GetLastIndexOfCFromPivot(this string s, char c, int pivot, int currentIndex)
        {
            for (int i = pivot - 1; i >= currentIndex; i--)
            {
                if (s[i] == c) return i;
            }
            return -1;
        }
    }
}
