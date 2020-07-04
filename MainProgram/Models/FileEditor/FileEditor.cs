using System;
using System.IO;
using System.Text;

namespace Task11
{
    public class FileEditor : IDisposable
    {
        private readonly FileAccess fileAccess;

        private readonly FileMode fileMode;

        private Stream fileStream;
        private StreamReader streamReader;
        private StreamWriter streamWriter;

        private FileEditor()
        {
            Encoding = Encoding.Default;
        }

        /// <summary>
        ///     Create new file
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="arrayLength"></param>
        private FileEditor(string filePath, int arrayLength) : this()
        {
            BaseURI = filePath;
            Length = arrayLength;
            String = new char[Length];
            fileAccess = FileAccess.ReadWrite;
            fileMode = FileMode.Create;

            InitStreams();
        }

        /// <summary>
        ///     Open for read
        /// </summary>
        /// <param name="filePath"></param>
        private FileEditor(string filePath) : this()
        {
            BaseURI = filePath;
            fileAccess = FileAccess.ReadWrite;
            fileMode = FileMode.Open;

            InitStreams();

            String = new char[fileStream.Length];
            Length = (int) fileStream.Length;

            for (var i = 0; i < Length; i++)
                _ = this[i];
        }

        public Encoding Encoding { get; }

        public char[] String { get; private set; }

        public int Length { get; private set; }
        public string BaseURI { get; }

        public char this[int index]
        {
            get => GetCharAtIndex(index);
            set => SetCharAtIndex(index, value);
        }

        private void InitStreams()
        {
            Close();

            fileStream = new FileStream(BaseURI, fileMode, fileAccess, FileShare.ReadWrite);

            streamReader = new StreamReader(fileStream, Encoding);
            streamWriter = new StreamWriter(fileStream, Encoding);
        }

        public static FileEditor Create(string filePath, int arrayLength)
        {
            return new FileEditor(filePath, arrayLength);
        }

        public static FileEditor Read(string filePath)
        {
            return new FileEditor(filePath);
        }

        private char GetCharAtIndex(int index)
        {
            if (index < 0 || index >= Length)
                throw new ArgumentOutOfRangeException(nameof(index));

            streamReader.Read(String, index, 1);
            return String[index];
        }

        private void SetCharAtIndex(int index, char chr)
        {
            if (index < 0 || index >= Length)
                throw new ArgumentOutOfRangeException(nameof(index));
            String[index] = chr;
            InitStreams();
            streamWriter.Write(String);
            streamWriter.Flush();
        }
        public void WriteAllText(string text)
        {
            Length = text.Length;
            String = new char[Length];
            for (int i = 0; i < Length; i++)
                String[i] = text[i];
            InitStreams();
            streamWriter.Write(String);
            streamWriter.Flush();
        }
        /// <summary>
        /// Same as Dispose
        /// </summary>
        public void Close()
        {
            try
            {
                fileStream?.Dispose();
                streamReader?.Dispose();
                streamWriter?.Dispose();
            }
            catch (Exception)
            {
            }
        }

        #region Dispose

        private bool disposedValue;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                Close();
                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        ~FileEditor()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}