using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics;

namespace Study
{
    internal class AttendanceDBDAL
    {
        private readonly IDbConnection dbConnection;

        public AttendanceDBDAL(string provider, string connection)
        {
            var dbProviderFactory = DbProviderFactories.GetFactory(provider);
            dbConnection = dbProviderFactory.CreateConnection();
            dbConnection.ConnectionString = connection;
        }

        public int InsertLecture(DateTime date, string topic)
        {
            string query = $"insert into {Utils.Tables.Lecture} (Date, Topic) values (@Date, @Topic)";

            using (var command = CreateDefaultCommand(query))
            {
                return ExecuteCommand(command, new Dictionary<string, object>
                {
                    ["@Date"] = date,
                    ["@Topic"] = topic,
                });
            }
        }

        public int InsertStudent(string studentName)
        {
            string query = $"insert into {Utils.Tables.Students} (Name) values (@Name)";

            using (var command = CreateDefaultCommand(query))
            {
                return ExecuteCommand(command, new Dictionary<string, object>
                {
                    ["@Name"] = studentName
                });
            }
        }

        public int MarkAttendance(string studentName, DateTime date, int mark)
        {
            using (SqlCommand procedureCommand = CreateDefaultCommand("MarkAttendance"))
            {
                procedureCommand.CommandType = CommandType.StoredProcedure;

                return ExecuteCommand(procedureCommand, new Dictionary<string, object>
                {
                    ["@StudentName"] = studentName,
                    ["@LectureDate"] = date,
                    ["@Mark"] = mark,
                });
            }
        }

        public DataAdapter GetDataAdapter(string tableName)
        {
            SqlDataAdapter dataAdapter = null;
            using (IDbCommand command = new SqlCommand($"select * from {tableName}", dbConnection as SqlConnection))
            {
                dataAdapter = new SqlDataAdapter(command as SqlCommand);
            }
            return dataAdapter;
        }

        public void InitDefaultTablesAndProcedure()
        {
            foreach(var commandString in Utils.DefaultCommands)
            {
                using(var command = CreateDefaultCommand(commandString))
                {
                    ExecuteCommand(command, null);
                }
            }
        }

        private SqlCommand CreateDefaultCommand(string commandString) =>
            new SqlCommand(commandString, (SqlConnection) dbConnection);

        private int ExecuteCommand(SqlCommand sqlCommand, IDictionary<string, object> parameters)
        {
            try
            {
                dbConnection.Open();
                if(parameters != null)
                    foreach (var parameter in parameters)
                    {
                        sqlCommand.Parameters
                            .Add(new SqlParameter(parameter.Key, parameter.Value));
                    }
                return sqlCommand.ExecuteNonQuery();
            }
            catch(Exception exception)
            {
                Debug.WriteLine(exception);
            }
            finally
            {
                dbConnection.Close();
            }
            return 0;
        }
    }
}
