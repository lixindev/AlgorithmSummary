using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgorithmSummary
{
    class Program
    {
        static void Main(string[] args)
        {
            MinRefuelStops minRefuelStops = new MinRefuelStops();
            int a = minRefuelStops.Min_Refuel_Stops1(1000, 299, new int[][] { new int[] { 13, 21 }, new int[] { 26, 115 }, new int[] { 100, 47 }
            , new int[] { 225, 99 }, new int[] { 299, 141 }, new int[] { 444, 198 }, new int[] { 608, 190 }, new int[] { 636, 157 }
            , new int[] { 647, 255 }, new int[] { 841, 123 }});
            Console.WriteLine(a);

            Console.ReadLine();
        }
    }
}
