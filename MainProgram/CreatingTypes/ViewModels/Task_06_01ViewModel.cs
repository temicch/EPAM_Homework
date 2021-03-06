﻿using System;
using System.Text;
using System.Windows;
using MainProgram.Utility;
using Vector;

namespace MainProgram.ViewModels
{
    internal class Task_06_01ViewModel : BaseViewModel
    {
        public Task_06_01ViewModel()
        {
            CalculateCommand = new BasicCommand(obj => Calculate(obj));
        }

        public double X1 { get; set; } = 1;
        public double Y1 { get; set; } = 2;
        public double Z1 { get; set; } = 3;
        public double D1 { get; set; } = 50;

        public double X2 { get; set; } = 4;
        public double Y2 { get; set; } = 5;
        public double Z2 { get; set; } = 6;
        public double D2 { get; set; } = 100;

        public string Vector1 { get; set; }
        public string Vector2 { get; set; }

        public string Output { get; set; }

        public BasicCommand CalculateCommand { get; set; }

        public void Calculate(object obj)
        {
            try
            {
                var vector1 = new Vector3D(X1, Y1, Z1);
                var vector2 = new Vector3D(X2, Y2, Z2);

                Vector1 = VectorInfo(vector1, D1);
                Vector2 = VectorInfo(vector2, D2);

                Output = OutputInfo(vector1, vector2);

                OnPropertyChanged(nameof(Vector1));
                OnPropertyChanged(nameof(Vector2));
                OnPropertyChanged(nameof(Output));
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private string OutputInfo(Vector3D vector1, Vector3D vector2)
        {
            var output = new StringBuilder();
            output.Append($"{vector1} + {vector2} = {vector1 + vector2}\n");
            output.Append($"{vector1} - {vector2} = {vector1 - vector2}\n\n");
            output.Append($"The angle between the vectors: {Vector3D.Angle(vector1, vector2)}\n");
            output.Append($"Scalar product of vectors: {Vector3D.ScalarProduct(vector1, vector2)}");
            return output.ToString();
        }

        private string VectorInfo(Vector3D vector, double D)
        {
            var result = new StringBuilder();
            result.Append($"Vector {vector}\nLength = {vector.Length}\n\n");
            result.Append($"{vector} / {D} = {vector / D}\n");
            result.Append($"{D} / {vector} = {D / vector}\n");
            result.Append($"{vector} * {D} = {vector * D}\n");
            result.Append($"{D} * {vector} = {D * vector}\n");
            return result.ToString();
        }
    }
}