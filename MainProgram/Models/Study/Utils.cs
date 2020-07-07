using System;

namespace Study
{
    internal static class Utils
    {
        public enum Tables
        {
            Attendance,
            Lecture,
            Students
        }
        public static string[] DefaultCommands =
        {
            // Procedure MarkAttendance
            $"DROP PROCEDURE MarkAttendance",
            "CREATE PROCEDURE MarkAttendance " +
                "@StudentName VARCHAR(100), " +
                "@LectureDate DATE, " +
                "@Mark int " +
                "AS " +
                    $"INSERT INTO {Tables.Attendance} (LectureDate, StudentName, Mark) VALUES " +
                    "(@LectureDate, @StudentName, @Mark)" +
            "RETURN 0",
            // Table Students
            $"DROP TABLE {Tables.Students}",
            $"CREATE TABLE {Tables.Students} " +
                "(" +
                "[Id] INT NOT NULL IDENTITY(1, 1) PRIMARY KEY," +
                "[Name] VARCHAR(100) NULL" +
                ")",
            // Table Lecture
            $"DROP TABLE {Tables.Lecture}",
            $"CREATE TABLE {Tables.Lecture}" +
                "(" +
                "[Id] INT NOT NULL IDENTITY(1, 1) PRIMARY KEY," +
                "[Date] DATE NULL," +
                "[Topic] VARCHAR(100) NULL" +
                ")",
            // Table Attendance
            $"DROP TABLE {Tables.Attendance}",
            $"CREATE TABLE {Tables.Attendance}" +
                "(" +
                "[Id] INT NOT NULL IDENTITY(1, 1) PRIMARY KEY," +
                "[LectureDate] DATE NULL," +
                "[StudentName] VARCHAR(100) NULL, " +
                "[Mark] INT NULL" +
                ")",
        };
    }
}
