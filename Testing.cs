using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Explorer
{
    internal class Zesting
    {
        public static void TestConditions(bool condition, string errorMessage)
        {
            Debug.Assert(condition, errorMessage);
        }
    }
}
