using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqTest
{
    internal class Program
    {
        public class Student
        {
            public string Name { get; set; }
            public string Class { get; set; }
            public int Score { get; set; }
        }

        static void Main(string[] args)
        {
            int[] nums = new int[] { 1, 3, 2, 5, 7, 2 };
            int[] nums1 = new int[] { 1, 3, 2, 55, 77, 2 };
            string[] chars = new string[] { "aaa", "bbb", "aac" };
            List<Student> students = new List<Student>
            {
                new Student { Name = "aaa", Class="A", Score = 88 },
                new Student { Name = "bbb", Class="A", Score = 50 },
                new Student { Name = "ccc", Class="A", Score = 70 },
                new Student { Name = "ddd", Class="B", Score = 45 },
                new Student { Name = "eee", Class="B", Score = 84 },
                new Student { Name = "fff", Class="B", Score = 98 }
            };


            /**************************************************************
             * Sum, Average, Min, Max, Count, Aggregate
             *************************************************************/
            int numsSum = nums.Sum();
            double numsAvg = nums.Average();
            int numsMin = nums.Min();
            int numsMax = nums.Max();
            int numsCount = nums.Count();
            int numsAggregate = nums.Aggregate((num1, num2) => num1 * num2);
            string charsAggregate = chars.Aggregate((char1, char2) => char1 + "," + char2);

            /**************************************************************
             * Distinct, Reverse
             *************************************************************/
            int[] numsDistinct = nums.Distinct().ToArray();
            int[] numsReverse = nums.Reverse().ToArray();

            /**************************************************************
             * Skip, SkipWhile, Take, TakeWhile, First, Last, Single
             *************************************************************/
            int[] numsSkip = nums.Skip(3).ToArray();
            int[] numsSkipWhile = nums.SkipWhile(num => num == 5).ToArray();
            int[] numsTake = nums.Take(3).ToArray();
            int[] numsTakeWhile = nums.TakeWhile(num => num == 5).ToArray();
            int numsFirst = nums.First();
            int numsLast = nums.Last();
            try { nums.Single(num => num >= 5); } catch { Console.WriteLine("Not Single!"); }

            /**************************************************************
             * Any, All, Contains
             *************************************************************/
            bool numsAny = nums.Any(num => num == 7);
            bool numsAll = nums.All(num => num == 7);
            bool numsContains = nums.Contains(7);

            /**************************************************************
             * Union, Except Intersect, Concate
             *************************************************************/
            int[] numsUnion = nums.Union(nums1).ToArray();
            int[] numsExcept = nums.Except(nums1).ToArray();
            int[] numsIntersect = nums.Intersect(nums1).ToArray();
            int[] numsConcate = nums.Concat(nums1).ToArray();

            /**************************************************************
             * Select, Where, GroupBy, OrderBy, OrderByDescending
             *************************************************************/
            string[] numsSelect = nums.Select(num => num.ToString().PadLeft(5, '0')).ToArray();
            int[] numsWhere = nums.Where(num => num > 3).ToArray();
            var lstClassAverage = students.GroupBy(student => student.Class).Select(group => new { Class = group.Key, Average = group.Average(student => student.Score) }).ToList();
            int[] numsOrderBy = nums.OrderBy(num => num).ToArray();
            int[] numsOrderByDesc = nums.OrderByDescending(num => num).ToArray();
            

            Console.ReadLine();
        }
    }
}
