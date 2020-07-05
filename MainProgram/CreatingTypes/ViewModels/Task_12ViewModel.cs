using MainProgram.Utility;
using Task12;
using System;
using Microsoft.Win32;
using System.Linq;
using System.Text;
using Microsoft.WindowsAPICodePack.Dialogs;
using System.Collections.Generic;

namespace MainProgram.ViewModels
{
    internal class Task_12ViewModel : BaseViewModel
    {
        public string Output { get; set; }

        private string xPathExpression;
        public string XPathExpression 
        {
            get => xPathExpression;
            set
            {
                xPathExpression = value;
                OnPropertyChanged();
            }
        }

        public BasicCommand OpenFilesCommand { get; set; }
        public BasicCommand OpenDirectoryCommand { get; set; }

        public void OpenFiles(object obj)
        {
            var openFileDialog = new OpenFileDialog 
            { 
                Multiselect = true, 
                Filter = "Xml files|*.xml|All files|*.*" 
            };

            bool? dialogResult = openFileDialog.ShowDialog();
            if (dialogResult != true)
                return;

            var evaluateResult = XmlParser.EvaluateFiles(openFileDialog.FileNames, XPathExpression);
            string result = ParseFiles(evaluateResult);
            OutputWriteLine(result);
        }

        public void OpenDirectory(object obj)
        {
            using (var dialog = new CommonOpenFileDialog())
            {
                dialog.IsFolderPicker = true;
                var dialogResult = dialog.ShowDialog();
                if (dialogResult == CommonFileDialogResult.Ok)
                {
                    var evaluateResult = XmlParser.EvaluateDirectory(dialog.FileName, XPathExpression);
                    string result = ParseFiles(evaluateResult);
                    OutputWriteLine(result);
                }
            }
        }

        public string ParseFiles(IDictionary<string, int> dictionary)
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append($"XPath expression:{xPathExpression}{Environment.NewLine}");
            stringBuilder.Append(string.Concat(dictionary.Select(x => $"{x.Key} {x.Value}{Environment.NewLine}").ToArray()));

            return stringBuilder.ToString();
        }

        public Task_12ViewModel()
        {
            OpenFilesCommand = new BasicCommand(OpenFiles);
            OpenDirectoryCommand = new BasicCommand(OpenDirectory);

            XPathExpression = "docID";
        }

        private void OutputWriteLine(string str)
        {
            Output += $"{str}{Environment.NewLine}";
            OnPropertyChanged(nameof(Output));
        }
    }
}