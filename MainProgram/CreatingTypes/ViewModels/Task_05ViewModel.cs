﻿using MainProgram.Utility;
using MyShapes;
using System;
using System.Windows;
using System.Windows.Input;

namespace MainProgram.ViewModels
{
    class Task_05ViewModel: BaseViewModel
    {
        public string ASide { get; set; } = "2";
        public string BSide { get; set; } = "2";
        public string CSide { get; set; } = "2";

        private string area = "0";
        private string perimeter = "0";

        public string Area
        {
            get => area;
            set
            {
                area = value;
                OnPropertyChanged();
            }
        }

        public string Perimeter
        {
            get => perimeter;
            set
            {
                perimeter = value;
                OnPropertyChanged();
            }
        }

        BasicCommand _calculate;

        public ICommand calculate
        {
            get
            {
                if (_calculate == null)
                    _calculate = new BasicCommand(Calculate);
                return _calculate;
            }
        }

        private void Calculate(object parameter)
        {
            try
            {
                string valueFormatter = "{0:0.##}";
                double a, b, c;
                a = double.Parse(ASide);
                b = double.Parse(BSide);
                c = double.Parse(CSide);
                Triangle triangle = new Triangle(a, b, c);
                Perimeter = triangle.GetPerimeter().ToString();
                Area = string.Format(valueFormatter, triangle.GetArea());
            }
            catch (Exception exception)
            {
                Perimeter = "0";
                Area = "0";
                MessageBox.Show(exception.Message);
            }
        }
    }
}