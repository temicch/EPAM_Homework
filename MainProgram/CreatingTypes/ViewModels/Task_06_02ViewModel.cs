using MainProgram.Utility;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace MainProgram.ViewModels
{
    class Task_06_02ViewModel: BaseViewModel
    {
        public double A1 { get; set; } = 1;
        public double B1 { get; set; } = 2;
        public double C1 { get; set; } = 3;
        public double D1 { get; set; } = 50;
        public double X1 { get; set; } = 2;

        public double A2 { get; set; } = 4;
        public double B2 { get; set; } = 5;
        public double C2 { get; set; } = 6;
        public double D2 { get; set; } = 100;
        public double X2 { get; set; } = 4;

        public string Polynomial1 { get; set; }
        public string Polynomial2 { get; set; }

        public string Output { get; set; }

        public BasicCommand CalculateCommand { get; set; }

        public Task_06_02ViewModel()
        {
            CalculateCommand = new BasicCommand((obj) => Calculate(obj));
        }

        public void Calculate(object obj)
        {
            try
            {
                var polynomial1 = new Polynomial.Polynomial(new List<double> { A1, B1, C1 });
                var polynomial2 = new Polynomial.Polynomial(new List<double> { A2, B2, C2 });

                Polynomial1 = PolynomialInfo(polynomial1, D1, X1);
                Polynomial2 = PolynomialInfo(polynomial2, D2, X2);

                Output = OutputInfo(polynomial1, polynomial2);

                OnPropertyChanged(nameof(Polynomial1));
                OnPropertyChanged(nameof(Polynomial2));
                OnPropertyChanged(nameof(Output));
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }

        }

        private string OutputInfo(Polynomial.Polynomial polynomial1, Polynomial.Polynomial polynomial2)
        {
            StringBuilder output = new StringBuilder();
            output.Append($"{polynomial1} + {polynomial2} = {polynomial1 + polynomial2}\n");
            output.Append($"{polynomial1} - {polynomial2} = {polynomial1 - polynomial2}\n\n");
            //output.Append($"The angle between the vectors: {Vector3D.Angle(polynomial1, polynomial2)}\n");
            //output.Append($"Scalar product of vectors: {Vector3D.ScalarProduct(polynomial1, polynomial2)}");
            return output.ToString();
        }

        private string PolynomialInfo(Polynomial.Polynomial polynomial, double D, double x)
        {
            StringBuilder result = new StringBuilder();
            result.Append($"f(x) = {polynomial}\n\n");
            result.Append($"f({x}) = {polynomial.GetSolution(x)}\n\n");
            result.Append($"f'(x) = {polynomial.Derivative()}\n\n");
            result.Append($"({polynomial}) * {D} = {polynomial * D}\n");
            return result.ToString();
        }

    }
}
