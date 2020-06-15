using MainProgram.Utility;
using Newton;
using System;
using System.Windows;

namespace MainProgram.ViewModels
{
    class Task_03ViewModel:BaseViewModel
    {
        public string RootNumber { get; set; } = "27";
        public string RootDegree { get; set; } = "3";

        private string newtonResult = "0";
        private string powResult = "0";
        public string NewtonResult
        {
            get => newtonResult;
            set
            {
                newtonResult = value;
                OnPropertyChanged();
            }
        }
        public string PowResult
        {
            get => powResult;
            set
            {
                powResult = value;
                OnPropertyChanged();
            }
        }

        public string BinNumber { get; set; } = "12345";

        private string binResult = "0";
        private string binNetResult = "0";
        public string BinResult
        {
            get => binResult;
            set
            {
                binResult = value;
                OnPropertyChanged();
            }
        }
        public string BinNetResult
        {
            get => binNetResult;
            set
            {
                binNetResult = value;
                OnPropertyChanged();
            }
        }
        public BasicCommand BinCalculateCommand { get; set; }
        public BasicCommand RootCalculateCommand { get; set; }

        public Task_03ViewModel()
        {
            BinCalculateCommand = new BasicCommand(BinCalculate);
            RootCalculateCommand = new BasicCommand(RootCalculate);
        } 
        private void RootCalculate(object parameter)
        {
            string valueFormatter = "{0:0.##}";
            try
            {
                double number = double.Parse(RootNumber);
                double degree = double.Parse(RootDegree);
                NewtonResult = string.Format(valueFormatter, NewtonMethods.Root(number, degree));
                PowResult = string.Format(valueFormatter, Math.Pow(number, 1 / degree));
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void BinCalculate(object parameter)
        {
            try
            {
                uint number = uint.Parse(BinNumber);
                BinResult = BinFormatter.BinFormatter.IntToBinString(number);
                BinNetResult = Convert.ToString(number, 2);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
    }
}
