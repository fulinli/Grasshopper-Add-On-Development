using System;
using System.Text.RegularExpressions;

namespace RegExApplication
{
    class Program
    {
        struct rules
        {
            public string functionname;
            public string[] entities;
            public int value;
            public int type;
        };
        private static void showMatch(string text, string expr)
        {
            Console.WriteLine("The Expression: " + expr);
            Match mc = Regex.Match(text, expr);

            string str = mc.ToString();

            int left = str.IndexOf('(');
            int right = str.IndexOf(')');
            if (right > left)
                str = str.Substring(left + 1, right - left - 1);
            Console.WriteLine(str);

        }
        static void Main(string[] args)
        {
            string str = "Distance1(±­×Ó,Ò£¿ØÆ÷,300,type);Distance1(±­×Ó,Ò£¿ØÆ÷,300,type)";
            string Regexsplit = ";";
            string[] arr;
            arr = Regex.Split(str, Regexsplit);
            Console.WriteLine(arr.Length);
            for (int i = 0; i < 2; i++)
            {
                showMatch(arr[i], @"^\w*");

                showMatch(arr[i], @"\(\S*\)");
            }
            Console.ReadKey();
        }
    }
}