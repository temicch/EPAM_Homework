using LiveCharts;
using LiveCharts.Wpf;
using MainProgram.Utility;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace MainProgram.ViewModels
{
    class Task_04ViewModel: BaseViewModel
    {
        public string Number1 { get; set; } = "18";
        public string Number2 { get; set; } = "9";
        public string Number3 { get; set; } = "36";
        public string Number4 { get; set; } = "72";
        public string Number5 { get; set; } = "144";

        public string NumberCount { get; set; } = "2";

        private string newtonGcd = "0";
        private string steinGcd = "0";

        public string NewtonGcd
        {
            get => newtonGcd;
            set
            {
                newtonGcd = value;
                OnPropertyChanged();
            }
        }

        public string SteinGcd
        {
            get => steinGcd;
            set
            {
                steinGcd = value;
                OnPropertyChanged();
            }
        }

        public string CyclesCount { get; set; } = "100000";

        public bool IsHorizontal { get; set; }

        public bool GreenRadio { get; set; } = true;
        public bool RedRadio { get; set; }
        public bool BlueRadio { get; set; }

        public SeriesCollection SeriesCollection { get; set; }

        BasicCommand _calculateGcd;
        BasicCommand _calculateWatchers;

        public ICommand calculateGcd
        {
            get
            {
                if (_calculateGcd == null)
                    _calculateGcd = new BasicCommand(CalculateGcd);
                return _calculateGcd;
            }
        }
        public ICommand calculateWatchers => _calculateWatchers ?? (_calculateWatchers = new BasicCommand(CalculateWatchers));

        public Task_04ViewModel()
        {
            SeriesCollection = new SeriesCollection();
        }

        public void TimeMeter(Func<uint, uint, uint> function, uint cycles, out long time)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            for (uint i = 0; i < cycles; i++)
            {
                function(i, 64);
            }
            stopWatch.Stop();
            time = stopWatch.ElapsedMilliseconds;
        }

        private void CalculateGcd(object parameter)
        {
            try
            {
                int count = int.Parse(NumberCount);
                uint num1, num2, num3, num4, num5;
                num1 = uint.Parse(Number1);
                num2 = uint.Parse(Number2);
                if (count == 2)
                {
                    NewtonGcd = Euclidean.Euclidean.Gcd(num1, num2).ToString();
                    SteinGcd = Euclidean.Stein.Gcd(num1, num2).ToString();
                }
                else if (count == 3)
                {
                    num3 = uint.Parse(Number3);
                    NewtonGcd = Euclidean.Euclidean.Gcd3(num1, num2, num3).ToString();
                    SteinGcd = Euclidean.Stein.Gcd3(num1, num2, num3).ToString();
                }
                else if (count == 4)
                {
                    num3 = uint.Parse(Number3);
                    num4 = uint.Parse(Number4);
                    NewtonGcd = Euclidean.Euclidean.Gcd4(num1, num2, num3, num4).ToString();
                    SteinGcd = Euclidean.Stein.Gcd4(num1, num2, num3, num4).ToString();
                }
                else if (count == 5)
                {
                    num3 = uint.Parse(Number3);
                    num4 = uint.Parse(Number4);
                    num5 = uint.Parse(Number5);
                    NewtonGcd = Euclidean.Euclidean.Gcd5(num1, num2, num3, num4, num5).ToString();
                    SteinGcd = Euclidean.Stein.Gcd5(num1, num2, num3, num4, num5).ToString();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void CalculateWatchers(object parameter)
        {
            try
            {
                uint cyclesCount = uint.Parse(CyclesCount);

                TimeMeter(Euclidean.Euclidean.Gcd, cyclesCount, out long euclideTime);
                TimeMeter(Euclidean.Stein.Gcd, cyclesCount, out long steinTime);

                Brush barColor = null;

                if (RedRadio == true)
                    barColor = Brushes.Red;
                else if (GreenRadio == true)
                    barColor = Brushes.Green;
                else if (BlueRadio == true)
                    barColor = Brushes.Blue;

                CreateChart(euclideTime, steinTime, isHorisontal: !IsHorizontal, color: barColor);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
        void CreateChart(long euclideTime, long steinTime, Brush color = null, bool? isHorisontal = true)
        {
            if (color == null)
                color = Brushes.DarkGreen;

            Brush steinColor = color.Clone();
            steinColor.Opacity = 0.5;

            object[][] values = new[]
            {
                new object[]{ "Classic Euclide algorithm", new ChartValues<long> { euclideTime }, color },
                new object[]{ "Stein algorithm", new ChartValues<long> { steinTime }, steinColor }
            };

            SeriesCollection.Clear();

            foreach (var array in values)
            {
                Series series;
                if (isHorisontal == true)
                    series = new ColumnSeries();
                else
                    series = new RowSeries();
                series.Title = array[0] as string;
                ChartValues<long> vs = (ChartValues<long>)array[1];
                series.Values = vs;
                series.Fill = array[2] as Brush;

                SeriesCollection.Add(series);
            }
        }
    }
}
