using System;
using System.Text;
using System.Windows;
using MainProgram.Utility;

namespace MainProgram.ViewModels
{
    internal class Task_11_01ViewModel : BaseViewModel
    {
        private const string fileName = "test.txt";
        private const string text = "[01] Привет, мир!";
        private const int arrayLength = 100;

        private readonly StringBuilder output;

        public Task_11_01ViewModel()
        {
            output = new StringBuilder();
            ExecuteTask();
        }

        public string Output => output.ToString();

        private void ExecuteTask()
        {
            try
            {
                CreateFile();
                ReadFile();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void ReadFile()
        {
            Task11.FileEditor file;
            using (file = Task11.FileEditor.Read(fileName))
            {
                OutputWriteLine(
                    "With the help of the created class, open the created file and change one character in it:");
                file[2] = '2';
                var str = new StringBuilder(arrayLength);
                for (var i = 0; i < file.Length; i++)
                    str.Append(file[i]);
                OutputWriteLine(str.ToString());
            }
        }

        private void CreateFile()
        {
            Task11.FileEditor file = null;
            try
            {
                OutputWriteLine($"Create a file \"{fileName}\" with a string \"{text}\":");
                file = Task11.FileEditor.Create(fileName, arrayLength);
                for (var i = 0; i < text.Length; i++)
                    file[i] = text[i];
                OutputWriteLine(string.Concat(file.String));
            }
            finally
            {
                file?.Dispose();
            }

            OutputWriteLine("");
        }

        private void OutputWriteLine(string str)
        {
            output.AppendLine(str);
            OnPropertyChanged(nameof(Output));
        }
    }
}