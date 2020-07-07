using MainProgram.Utility;
using System;
using Study;

namespace MainProgram.ViewModels
{
    internal class Task_13ViewModel : BaseViewModel
    {
        public string Output { get; set; }

        public AttendanceDB InformationData { get; set; }

        public BasicCommand AddAttendanceCommand { get; set; }
        public BasicCommand AddStudentCommand { get; set; }
        public BasicCommand AddLectureCommand { get; set; }
        public BasicCommand SetDefaultsCommand { get; set; }

        public BasicCommand ReloadTablesCommand { get; set; }

        public string StudentName { get; set; }

        public DateTime LectureDate { get; set; }
        public string LectureTopic { get; set; }

        public string AttendanceStudentName { get; set; }
        public DateTime AttendanceDate { get; set; }
        public int AttendanceMark { get; set; }

        public Task_13ViewModel()
        {
            InitViewProperties();
            InitCommands();

            InformationData = new AttendanceDB();

            InformationData.Init();
            InformationData.SetDefaultStructure();
            InformationData.ReloadTables();
            OnPropertyChanged(nameof(InformationData));
        }

        private void InitCommands()
        {
            AddAttendanceCommand = new BasicCommand(AddAttendance);
            AddStudentCommand = new BasicCommand(AddStudent);
            AddLectureCommand = new BasicCommand(AddLecture);
            ReloadTablesCommand = new BasicCommand(ReloadTables);
            SetDefaultsCommand = new BasicCommand(SetDefaults);
        }

        private void SetDefaults(object obj)
        {
            InformationData.SetDefaultStructure();
            ReloadTables(null);
        }

        private void ReloadTables(object obj)
        {
            InformationData.ReloadTables();
        }

        private void AddLecture(object obj)
        {
            InformationData.AddLecture(LectureDate, LectureTopic);
            ReloadTables(null);
        }

        private void AddStudent(object obj)
        {
            InformationData.AddStudent(StudentName);
            ReloadTables(null);
        }

        private void AddAttendance(object obj)
        {
            InformationData.AddAttendance(AttendanceStudentName, AttendanceDate, AttendanceMark);
            ReloadTables(null);
        }

        private void InitViewProperties()
        {
            StudentName = "Ivanov Liev";

            LectureDate = DateTime.Now;
            LectureTopic = "ADO .NET";

            AttendanceStudentName = "Ivanov Liev";
            AttendanceDate = DateTime.Now;
            AttendanceMark = 5;
        }

        private void OutputWriteLine(string str)
        {
            Output += $"{str}{Environment.NewLine}";
            OnPropertyChanged(nameof(Output));
        }
    }
}