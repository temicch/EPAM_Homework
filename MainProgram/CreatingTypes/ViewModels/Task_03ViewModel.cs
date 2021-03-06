﻿using System;
using System.Windows;
using MainProgram.Utility;
using NewtonSQRT;

namespace MainProgram.ViewModels
{
    internal class Task_03ViewModel : BaseViewModel
    {
        private string binNetResult = "0";

        private string binResult = "0";

        private string newtonResult = "0";
        private string powResult = "0";

        public Task_03ViewModel()
        {
            BinCalculateCommand = new BasicCommand(BinCalculate);
            RootCalculateCommand = new BasicCommand(RootCalculate);
        }

        public string RootNumber { get; set; } = "27";
        public string RootDegree { get; set; } = "3";

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

        private void RootCalculate(object parameter)
        {
            var valueFormatter = "{0:0.##}";
            try
            {
                var number = double.Parse(RootNumber);
                var degree = double.Parse(RootDegree);
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
                var number = uint.Parse(BinNumber);
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