using System.Collections.Generic;
using static System.Console;

namespace ConsoleApp
{
    public class Solution
    {
        public int RomanToInt(string s)
        {
            short result = 0;
            Dictionary<char, short> romanNums = new Dictionary<char, short>
            {
                ['I'] = 1,
                ['V'] = 5,
                ['X'] = 10,
                ['L'] = 50,
                ['C'] = 100,
                ['D'] = 500,
                ['M'] = 1000
            };

            List<char> charList = new List<char>();
            charList.AddRange(s);
            for (int i = 0; i < charList.Count - 1; i++)
            {
                short first = (short)romanNums[charList[i]];
                short second = (short)romanNums[charList[i + 1]];
                if (first >= second)
                {
                    result += first;
                }
                else
                {
                    first *= -1;
                    result += first;
                }
            }
            short temp = (short)romanNums[charList[charList.Count - 1]];
            result += temp;

            return result;
        }
    }

    class Program
    {
        static void Main()
        {
            Solution solution = new Solution();
            WriteLine(solution.RomanToInt("CCXXXIII"));
            solution.RomanToInt("CCXXXIII").ToString();
        }
    }
}