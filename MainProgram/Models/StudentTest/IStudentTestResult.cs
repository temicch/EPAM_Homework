﻿using System;

namespace TestResult
{
    public interface IStudentTestResult : IComparable<IStudentTestResult>
    {
        string TestTitle { get; }
        string StudentName { get; }
        DateTime TestDate { get; }
        int Score { get; }
    }
}