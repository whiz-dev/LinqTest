using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //배열 sort
            int[] nums = new int[] { 1, 3, 2, 5, 7, 2 };
            nums = nums.OrderBy(num => num).ToArray();
            nums = nums.OrderByDescending(num => num).ToArray();

            //배열 filter
            string[] chars = new string[] { "aaa", "bbb", "aac" };
            chars = chars.Where(c => c.Contains("a")).ToArray();




            //Sum, Average, Min, Max
            double avg = nums.Average();
            avg = nums.Average(num => num * 2);

            //Distinct, Reverse, OrderBy, OrderByDescending

            //Where, Skip, SkipWhile, Take, TakeWhile, First, Last, Single

            //Any, All, Contains

            //Aggregate

            //Union, Except Intersect, Concate

            //Select, GroupBy


            Console.ReadLine();
        }
    }
}
