using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows;

namespace Task11
{
    public class TextEditor : INotifyPropertyChanged
    {
        private string text;
        public string Text
        {
            get => text;
            set 
            {
                text = value;
                OnPropertyChanged();
            }
        }

        private string fileName;
        public string FileName
        {
            get => fileName;
            private set
            {
                fileName = value;
                OnPropertyChanged();
            }
        }

        private FileEditor fileEditor;

        public TextEditor()
        {
            CreateNewFile();
        }

        public void OpenFile(string path)
        {
            SaveFile();
            fileEditor?.Dispose();
            fileEditor = FileEditor.Read(path);
            Text = string.Concat(fileEditor.String);
            FileName = Path.GetFileName(path);
        }

        public void CreateNewFile()
        {
            fileEditor?.Dispose();

            fileEditor = null;
            Text = string.Empty;
            FileName = string.Empty;
        }

        public void SaveFile()
        {
            if (fileEditor == null)
                return;
            fileEditor.WriteAllText(Text);
        }

        public void SaveFileAs(string path)
        {
            fileEditor?.Dispose();
            fileEditor = FileEditor.Create(path, Text.Length);
            FileName = Path.GetFileName(path);

            SaveFile();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}