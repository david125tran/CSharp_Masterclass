﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section22
{
    internal class Comparer
    {
        // --------------------- Part 7 ---------------------
        public static bool AreEqual<T>(T first, T second) where T : class
        {
            return first == second;
        }
    }
}
