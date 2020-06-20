using System;

namespace TestResult
{
    public class StudentTest : IStudentTestResult
    {
        public StudentTest(string testTitle, string studentName, DateTime testDate, short score)
        {
            TestTitle = testTitle;
            StudentName = studentName;
            TestDate = testDate;
            Score = score;
        }

        public string TestTitle { get; }

        public string StudentName { get; set; }
        public DateTime TestDate { get; }

        public short Score { get; }

        public int CompareTo(IStudentTestResult other)
        {
            return Score - other.Score;
        }

        public override string ToString()
        {
            return $"[{TestDate}] {TestTitle} {StudentName} {Score}";
        }
    }
}