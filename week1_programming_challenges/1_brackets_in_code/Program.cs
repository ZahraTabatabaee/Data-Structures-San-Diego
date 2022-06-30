using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace _1_brackets_in_code
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            if(Solve(input) == -1)
                Console.WriteLine("Success");
            else
                Console.WriteLine(Solve(input));
        }
        public static long Solve(string str)
        {
            Stack<string> stack = new Stack<string>();
            int i = 0 ;
            int idx = 0 ;
            char[] chars = {')', '(', '[', ']', '{', '}'};
            while(i < str.Length)
            {
                char c = str[i];
                if(!chars.Contains(c))
                {
                    i++;
                    continue;
                }
                if( c.ToString() == "(" || c.ToString() == "[" || c.ToString() == "{")
                {
                    idx = i;
                    stack.Push(c.ToString());
                    i++;
                }
                else if(c.ToString() == ")" || c.ToString() == "]" || c.ToString() == "}")
                {
                    if(stack.Count==0) return i+1;
                    string top = stack.Pop();
                    if((top == "[" && c.ToString() == "]")||(top == "(" && c.ToString() == ")")||(top == "{" && c.ToString() == "}"))
                    {
                        i++;
                        idx--;
                        continue;
                    }
                    return i+1;
                }
            }
            if(stack.Count==0) return -1;
            return idx+1 ;

        }
    }
}
