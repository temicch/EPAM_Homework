using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Study
{
    public class AttendanceDB
    {
        public Dictionary<string, DataTable> DataTables { get; set; }

        AttendanceDBDAL attendanceDBDAL;

        public AttendanceDB()
        {
            DataTables = new Dictionary<string, DataTable>();
            foreach (var tableName in Enum.GetValues(typeof(Utils.Tables)))
                DataTables.Add(tableName.ToString(), new DataTable(tableName.ToString()));
        }

        public void ReloadTables()
        {
            foreach (var tableName in Enum.GetValues(typeof(Utils.Tables)))
                using (var adapter = attendanceDBDAL.GetDataAdapter(tableName.ToString()) as SqlDataAdapter)
                {
                    DataTables[tableName.ToString()].Clear();
                    adapter.Fill(DataTables[tableName.ToString()]);
                }
        }

        public void Init()
        {
            var provider = ConfigurationManager.AppSettings["provider"];
            var connection = ConfigurationManager.AppSettings["cnStr"];

            attendanceDBDAL = new AttendanceDBDAL(provider, connection);
        }

        public int AddLecture(DateTime date, string topic)
        {
            return attendanceDBDAL.InsertLecture(date, topic);
        }

        public int AddStudent(string studentName)
        {
            return attendanceDBDAL.InsertStudent(studentName);
        }

        public int AddAttendance(int studentId, int lectureId, int mark)
        {
            return attendanceDBDAL.MarkAttendance(studentId, lectureId, mark);
        }

        public void SetDefaultStructure()
        {
            attendanceDBDAL.InitDefaultTablesAndProcedure();
        }
    }
}
