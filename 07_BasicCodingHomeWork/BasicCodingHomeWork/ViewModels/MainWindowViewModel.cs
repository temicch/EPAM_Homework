using BasicCodingHomeWork.Utility;
using Newton;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

namespace BasicCodingHomeWork
{
    class MainWindowViewModel: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

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

        BasicCommand _binCalculate;
        BasicCommand _rootCalculate;

        public ICommand binCalculate
        {
            get
            {
                if (_binCalculate == null)
                    _binCalculate = new BasicCommand(BinCalculate);
                return _binCalculate;
            }
        }
        public ICommand rootCalculate
        {
            get
            {
                if (_rootCalculate == null)
                    _rootCalculate = new BasicCommand(RootCalculate);
                return _rootCalculate;
            }
        }

        public MainWindowViewModel()
        {

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

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
