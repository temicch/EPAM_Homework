using Converter;
using MainProgram.Utility;
using System;
using System.Windows;

namespace MainProgram.ViewModels
{
    class Task_06_03ViewModel : BaseViewModel
    {
        public string Output { get; set; }

        public int ConvertersCount { get; set; } = 2;

        public BasicCommand CalculateCommand { get; set; }
        public BasicCommand ClearOutputCommand { get; set; }

        public Task_06_03ViewModel()
        {
            CalculateCommand = new BasicCommand(Calculate);
            ClearOutputCommand = new BasicCommand((obj) => { Output = string.Empty; OnPropertyChanged(nameof(Output)); });
        }

        private void OutputWriteLine(string str)
        {
            Output += $"{str}\n";
        }

        public void Calculate(object obj)
        {
            try
            {
                ProgramConverter[] programConverters = new ProgramConverter[ConvertersCount];

                for (int i = 0; i < programConverters.Length / 2; i++)
                    programConverters[i] = new ProgramConverter();
                for (int i = programConverters.Length / 2; i < programConverters.Length; i++)
                    programConverters[i] = new ProgramHelper();
                OutputWriteLine($"[0 - {-1 + programConverters.Length / 2}] elements is {nameof(ProgramConverter)}");
                OutputWriteLine($"[{programConverters.Length / 2} - {programConverters.Length - 1}] elements is {nameof(ProgramHelper)}");
                OutputWriteLine(string.Empty);

                const string vbCode = "var";

                for (int i = 0; i < programConverters.Length; i++)
                {
                    ProgramConverter converter = programConverters[i];
                    if (converter is ICodeChecker)
                    {
                        ICodeChecker codeChecker = converter as ICodeChecker;

                        OutputWriteLine($"[{i}] is ICodeChecker");

                        if (codeChecker.CheckCodeSyntax(vbCode, Language.CSharp_Code))
                            OutputWriteLine($"\t{vbCode} -> {converter.ConvertToVB(vbCode)}");
                        else if (codeChecker.CheckCodeSyntax(vbCode, Language.VB_Code))
                            OutputWriteLine($"\t{vbCode} -> {converter.ConvertToCSharp(vbCode)}");
                        else
                            OutputWriteLine("\t{str} - Unknown language");
                    }
                    else
                    {
                        OutputWriteLine($"[{i}] is not ICodeChecker");
                        OutputWriteLine($"\t{programConverters[i].ConvertToCSharp(vbCode)}");
                        OutputWriteLine($"\t{programConverters[i].ConvertToVB(vbCode)}");
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            OnPropertyChanged(nameof(Output));
        }
    }
}
