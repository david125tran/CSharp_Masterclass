using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section22
{
    internal class Box<T> // Generic class "Type", <T>
    {
        // --------------------- Part 1 ---------------------
        //public T Content { get; set; }
        //public string Log()
        //{
        //    return $"Box contains {Content}";
        //}

        // --------------------- Part 2 ---------------------
        //private T content;
        //public Box(T initialValue)
        //{
        //    content = initialValue;
        //}

        //public void UpdateContent(T newContent)
        //{
        //    content = newContent;
        //    Console.WriteLine($"Updated content to {content}");
        //}
        //public T GetContent()
        //{
        //    return content;
        //}
    }
    // --------------------- Part 3 ---------------------
    internal class Box<TFirst, TSecond>
    {
        public TFirst First { get; set; }
        public TSecond Second { get; set; }
        public Box(TFirst first, TSecond second)
        {
            First = first;
            Second = second;
        }

        public void Display()
        {
            Console.WriteLine($"First: {First}, Second: {Second}");
        }
    }
}

