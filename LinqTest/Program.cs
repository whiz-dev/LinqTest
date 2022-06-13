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
            public string ClassId { get; set; }
            public int Score { get; set; }
        }

        public class Class
        {
            public string ClassId { get; set; }
            public string ClassName { get; set; }
        }

        static void Main(string[] args)
        {
            int[] nums = new int[] { 1, 3, 2, 5, 7, 2 };
            int[] nums1 = new int[] { 1, 3, 2, 55, 77, 2 };
            string[] chars = new string[] { "aaa", "bbb", "aac" };
            List<Student> students = new List<Student>
            {
                new Student { Name = "aaa", ClassId="A", Score = 88 },
                new Student { Name = "bbb", ClassId="A", Score = 50 },
                new Student { Name = "ccc", ClassId="A", Score = 70 },
                new Student { Name = "ddd", ClassId="B", Score = 45 },
                new Student { Name = "eee", ClassId="B", Score = 84 },
                new Student { Name = "fff", ClassId="B", Score = 98 }
            };
            List<Class> classes = new List<Class>
            {
                new Class { ClassId = "A", ClassName="Class A" },
                //new Class { ClassId = "B", ClassName="Class B" }
            };


            /**************************************************************
             * Sum : 요소들의 전체 합계
             * Average : 요소들의 평균
             * Min : 요소들의 최소값
             * Max : 요소들의 최대값
             * Count : 요소들의 갯수
             * Aggregate : 요소들의 누적 계산 값
             *************************************************************/
            int numsSum = nums.Sum();
            double numsAvg = nums.Average();
            int numsMin = nums.Min();
            int numsMax = nums.Max();
            int numsCount = nums.Count();
            int numsAggregate = nums.Aggregate((num1, num2) => num1 * num2);
            string charsAggregate = chars.Aggregate((char1, char2) => char1 + "," + char2);

            /**************************************************************
             * Distinct : 중복 제거한 결과
             * Reverse : 역배열 결과
             *************************************************************/
            int[] numsDistinct = nums.Distinct().ToArray();
            int[] numsReverse = nums.Reverse().ToArray();

            /**************************************************************
             * Skip : 인덱스 만큼 건너뛴 나머지 배열
             * SkipWhile : 해당 조건을 만족하지 않는 요소가 나올때까지 건너뜀
             * Take : 인덱스 만큼 포함한 배열
             * TakeWhile : 해당 조건을 만족하지 않는 요소가 나올때까지 포함
             * First : 배열의 첫번째 요소
             * Last : 배열의 마지막 요소
             * Single : 지정한 조건을 만족하는 요소를 반환. 조건을 만족하는 요소가 2개 이상이면 예외 발생
             *************************************************************/
            int[] numsSkip = nums.Skip(3).ToArray();
            int[] numsSkipWhile = nums.SkipWhile(num => num == 5).ToArray();
            int[] numsTake = nums.Take(3).ToArray();
            int[] numsTakeWhile = nums.TakeWhile(num => num == 5).ToArray();
            int numsFirst = nums.First();
            int numsLast = nums.Last();
            try { nums.Single(num => num >= 5); } catch { Console.WriteLine("Not Single!"); }

            /**************************************************************
             * Any : 지정한 조건을 만족하는 요소가 1개라도 있는지 여부
             * All : 지정한 조건을 모든 요소가 만족하는지 여부
             * Contains : 해당 요소를 포함하는지 여부
             *************************************************************/
            bool numsAny = nums.Any(num => num == 7);
            bool numsAll = nums.All(num => num == 7);
            bool numsContains = nums.Contains(7);

            /**************************************************************
             * Union : 합집합
             * Except : 차집합
             * Intersect : 교집합
             * Concate : 두 배열 이어 붙이기 (Union All)
             *************************************************************/
            int[] numsUnion = nums.Union(nums1).ToArray();
            int[] numsExcept = nums.Except(nums1).ToArray();
            int[] numsIntersect = nums.Intersect(nums1).ToArray();
            int[] numsConcate = nums.Concat(nums1).ToArray();

            /**************************************************************
             * Select : 새로운 요소로 변환하여 반환
             * Where : 지정한 조건을 만족하는 요소만 반환
             * GroupBy : 지정한 조건으로 Grouping
             * OrderBy : 오름차순 정렬
             * OrderByDescending : 내림차순 정렬
             *************************************************************/
            string[] numsSelect = nums.Select(num => num.ToString().PadLeft(5, '0')).ToArray();
            int[] numsWhere = nums.Where(num => num > 3).ToArray();
            var lstClassAverage = students.GroupBy(student => student.ClassId).Select(group => new { Class = group.Key, Average = group.Average(student => student.Score) }).ToList();
            int[] numsOrderBy = nums.OrderBy(num => num).ToArray();
            int[] numsOrderByDesc = nums.OrderByDescending(num => num).ToArray();

            /**************************************************************
             * Join : 새로운 요소로 변환하여 반환
             * GroupJoin : 지정한 조건을 만족하는 요소만 반환
             *************************************************************/
            var lstStudentClassJoin = students.Join(classes,
                                                    student => new { ClassId = student.ClassId },
                                                    cls => new { ClassId = cls.ClassId },
                                                    (person, cls) => new { Name = person.Name, Class = cls.ClassName, Score = person.Score });

            var lstStudentClassGroupJoin = students.GroupJoin(classes,
                                                              student => student.ClassId,
                                                              cls => cls.ClassId,
                                                              (person, clsGroup) => new { Name = person.Name, Class = clsGroup.Count() > 0 ? clsGroup.First().ClassName : null, Score = person.Score });


            Console.ReadLine();
        }
    }
}
