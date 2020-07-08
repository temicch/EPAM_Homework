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
            "DROP PROCEDURE MarkAttendance",
            "CREATE PROCEDURE MarkAttendance " +
                "@StudentId INT, " +
                "@LectureId INT, " +
                "@Mark int " +
                "AS " +
                    $"INSERT INTO {Tables.Attendance} (Student_Id, Lecture_Id, Mark) VALUES " +
                    "(@StudentId, @LectureId, @Mark)" +
            "RETURN 0",
            // Table Students
            $"DROP TABLE {Tables.Students}",
            $"CREATE TABLE {Tables.Students} " +
                "(" +
                "[Id] INT NOT NULL IDENTITY(1, 1) PRIMARY KEY," +
                "[Name] VARCHAR(100) NULL," +
                ")",
            // Table Lecture
            $"DROP TABLE {Tables.Lecture}",
            $"CREATE TABLE {Tables.Lecture}" +
                "(" +
                "[Id] INT NOT NULL IDENTITY(1, 1) PRIMARY KEY," +
                "[Date] DATE NULL," +
                "[Topic] VARCHAR(100) NULL," +
                ")",
            // Table Attendance
            $"DROP TABLE {Tables.Attendance}",
            $"CREATE TABLE {Tables.Attendance} (" +
            "    [Id]         INT IDENTITY (1, 1) NOT NULL," +
            "    [Lecture_Id] INT NOT NULL," +
            "    [Student_Id] INT NOT NULL," +
            "    [Mark]" +
            "        INT NULL," +
            "    PRIMARY KEY CLUSTERED([Id] ASC)," +
            "    CONSTRAINT[FK_Attendance_Lecture] FOREIGN KEY([Lecture_Id]) REFERENCES[dbo].[Lecture] ([Id])," + 
            "    CONSTRAINT[FK_Attendance_Students] FOREIGN KEY([Student_Id]) REFERENCES[dbo].[Students] ([Id])" + 
            ");"

    };
    }
}
