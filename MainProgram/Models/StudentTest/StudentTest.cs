using System;

namespace TestResult
{
    /// <summary>
    ///     Class for storing student test results
    /// </summary>
    [Serializable]
    public class StudentTest : IStudentTestResult
    {
        /// <summary>
        ///     Initialize student test record
        /// </summary>
        /// <param name="testTitle">Test title</param>
        /// <param name="studentName">Student name</param>
        /// <param name="testDate">Date test</param>
        /// <param name="score">The number of points scored on the test</param>
        public StudentTest(string testTitle, string studentName, DateTime testDate, int score)
        {
            TestTitle = testTitle;
            StudentName = studentName;
            TestDate = testDate;
            Score = score;
        }

        public string TestTitle { get; }
        public string StudentName { get; set; }
        public DateTime TestDate { get; }

        /// <summary>
        ///     The number of points scored on the test
        /// </summary>
        public int Score { get; }

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