using MainProgram.Utility;
using Microsoft.Win32;
using Task11;

namespace MainProgram.ViewModels
{
    internal class Task_11_02ViewModel : BaseViewModel
    {
        public BasicCommand NewCommand { get; set; }
        public BasicCommand OpenCommand { get; set; }
        public BasicCommand SaveCommand { get; set; }
        public BasicCommand SaveAsCommand { get; set; }

        public TextEditor TextEditor { get; set; }

        public Task_11_02ViewModel()
        {
            TextEditor = new TextEditor();

            NewCommand = new BasicCommand(_CreateNewFile);
            OpenCommand = new BasicCommand(_OpenFile);
            SaveCommand = new BasicCommand(_SaveFile);
            SaveAsCommand = new BasicCommand(_SaveFileAs);
        }

        private void _CreateNewFile(object obj)
        {
            CreateNewFile();
        }

        public void CreateNewFile()
        {
            TextEditor.CreateNewFile();
        }

        private void _OpenFile(object obj)
        {
            var openFileDialog = new OpenFileDialog { Multiselect = false };

            bool? result = openFileDialog.ShowDialog();
            if (result != true)
                return;
            string filename = openFileDialog.FileName;

            OpenFile(filename);
        }

        public void OpenFile(string path)
        {
            TextEditor.OpenFile(path);
        }

        private void _SaveFile(object obj)
        {
            if (string.IsNullOrEmpty(TextEditor.FileName))
            {
                _SaveFileAs(obj);
                return;
            }
            SaveFile();
        }

        public bool SaveFile()
        {
            if (string.IsNullOrEmpty(TextEditor.FileName))
            {
                return false;
            }
            TextEditor.SaveFile();
            return true;
        }

        private void _SaveFileAs(object obj)
        {
            var openFileDialog = new SaveFileDialog();

            bool? result = openFileDialog.ShowDialog();
            if (result != true)
                return;
            string filename = openFileDialog.FileName;

            SaveFileAs(filename);
        }

        public void SaveFileAs(string path)
        {
            TextEditor.SaveFileAs(path);
        }
    }
}