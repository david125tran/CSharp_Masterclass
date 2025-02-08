using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section22
{
    internal class Logger
    {
        // --------------------- Part 4 ---------------------
        public void Log<T>(T message)
        {
            Console.WriteLine(message.ToString());
        }
    }
}
