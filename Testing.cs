using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DE_Testing_Project
{
    internal class Zesting
    {
        public static void TestConditions(bool condition, string errorMessage)
        {
            Debug.Assert(condition, errorMessage);
        }
    }
}
