using System;
using System.Collections.Generic;

namespace Home_Task_9
{
    //Изначальный вариант (Poor optimization)
    public class Solution
    {
        char[] charArray = new char[] { '(', ')', '[', ']', '{', '}' };
        char[] tmpl_1 = new char[] { '(', ')' };
        char[] tmpl_2 = new char[] { '[', ']' };
        char[] tmpl_3 = new char[] { '{', '}' };
        bool flag = true;
        bool forFlag = true;

        public bool IsValid(string s)
        {
            if (IsLength(s) == true)
            {
                if (IsSymbol(s) == true)
                {
                    List<char> charList = new List<char>();
                    charList.AddRange(s);


                    while (flag == true)
                    {
                        for (int i = 1; i < charList.Count; i++)
                        {
                            if (forFlag == false)
                            {
                                i = 1;
                                forFlag = true;
                            }
                            if (charList[i - 1] == tmpl_1[0] && charList[i] == tmpl_1[1])
                            {
                                charList.RemoveAt(i);
                                charList.RemoveAt(i - 1);
                                forFlag = false;
                                if (IsEmpty(charList) == true)
                                    flag = false;
                                continue;
                            }
                            else if (charList[i - 1] == tmpl_2[0] && charList[i] == tmpl_2[1])
                            {
                                charList.RemoveAt(i);
                                charList.RemoveAt(i - 1);
                                forFlag = false;
                                if (IsEmpty(charList) == true)
                                    flag = false;
                                continue;
                            }
                            else if (charList[i - 1] == tmpl_3[0] && charList[i] == tmpl_3[1])
                            {
                                charList.RemoveAt(i);
                                charList.RemoveAt(i - 1);
                                forFlag = false;
                                if (IsEmpty(charList) == true)
                                    flag = false;
                                continue;
                            }

                            else if (i < charList.Count && i == charList.Count - 1)
                            {
                                if (IsGoOn(charList) == true)
                                {
                                    continue;
                                }
                                else
                                {
                                    return false;
                                }
                            }
                            else if (i < charList.Count)
                            {
                                continue;
                            }
                            else
                            {
                                flag = false;
                                return false;
                            }
                        }
                    }
                    if (IsEmpty(charList) == true)
                    {
                        return true;
                    }
                    else
                        return false;
                }
                else
                    return false;
            }
            else
                return false;
        }

        public bool IsLength(string s)
        {
            return s.Length <= 10000 && s.Length % 2 == 0;
        }

        public bool IsSymbol(string s)
        {
            short counter = 0;
            foreach (char item in s)
            {
                for (int i = 0; i < charArray.Length; i++)
                {
                    if (item == charArray[i])
                    {
                        counter++;
                        break;
                    }

                }
            }
            if (counter == s.Length)
            {
                return true;
            }
            return false;
        }

        public bool IsEmpty(List<char> list)
        {
            return list.Count == 0;
        }

        public bool IsGoOn(List<char> list)
        {
            for (int i = 1; i < list.Count; i++)
            {
                if ((list[i - 1] == tmpl_1[0] && list[i] == tmpl_1[1]) || (list[i - 1] == tmpl_2[0] && list[i] == tmpl_2[1]) || (list[i - 1] == tmpl_3[0] && list[i] == tmpl_3[1]))
                {
                    return true;
                }
            }
            return false;
        }
    }

    //Лучший вариант с использованием Stack
    //public class Solution
    //{
    //    public bool IsValid(string s)
    //    {
    //        short counter = 0;
    //        char temp;
    //        Stack<char> charStack = new Stack<char>();
    //        charStack.Push(s[0]);
    //        for (int i = 1; i < s.Length; i++)
    //        {
    //            if (charStack.Count == 0)
    //            {
    //                temp = s[i];
    //            }
    //            else
    //            {
    //                temp = charStack.Peek();
    //            }

    //            charStack.Push(s[i]);
    //            if ((temp == '(' && s[i] == ')') || (temp == '[' && s[i] == ']') || (temp == '{' && s[i] == '}'))
    //            {
    //                charStack.Pop();
    //                charStack.Pop();
    //                counter += 2;
    //            }
    //        }
    //        return counter == s.Length;
    //    }
    //}



    class Program
    {

        static void Main(string[] arguments)
        {
            Solution solution = new Solution();
            Console.WriteLine(solution.IsValid("[{(){{{{{{{{{()}}}}}}}}}}]u"));
        }
    }
}