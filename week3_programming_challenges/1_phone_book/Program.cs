using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace _1_phone_book
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] a = new string[3];
            for (int i = 0; i < n; i++)
            {
                a[i] = Console.ReadLine();
            }
            string[] answer = Solve(a);
            for (int i = 0; i < answer.Length; i++)
            {
                Console.WriteLine(answer[i]);
            }

        }
        public class Contact
        {
            public string Name;
            public int Number;

            public Contact(string name, int number)
            {
                Name = name;
                Number = number;
            }
        }
        protected static Dictionary<long,string> PhoneBookList;

        public static string[] Solve(string [] commands)
        {
            PhoneBookList = new Dictionary<long,string>();
            List<string> result = new List<string>();
            foreach(var cmd in commands)
            {
                var toks = cmd.Split();
                var cmdType = toks[0];
                var args = toks.Skip(1).ToArray();
                int number = int.Parse(args[0]);
                switch (cmdType)
                {
                    case "add":
                        Add(args[1], number);
                        break;
                    case "del":
                        Delete(number);
                        break;
                    case "find":
                        result.Add(Find(number));
                        break;
                }
            }
            return result.ToArray();
        }

        public static void Add(string name, int number)
        {
            if (PhoneBookList.ContainsKey(number))
            {
                PhoneBookList.Remove(number);
            }
            PhoneBookList.Add(number, name);
        }

        public static string Find(int number)
        {
            if (PhoneBookList.ContainsKey(number))
            {
                return PhoneBookList[number];
            }
            return "not found";
        }

        public static void Delete(int number)
        {
            if (PhoneBookList.ContainsKey(number))
            {
                PhoneBookList.Remove(number);
            }
        }
    }
}
