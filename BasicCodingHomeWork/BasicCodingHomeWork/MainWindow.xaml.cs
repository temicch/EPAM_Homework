using Newton;
using BinFormatter;
using System;
using System.Windows;

namespace BasicCodingHomeWork
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void NewtonCalculateButton_Click(object sender, RoutedEventArgs e)
        {
            string valueFormatter = "{0:0.##}";
            try
            {
                double number = double.Parse(NumberTextBox.Text);
                double degree = double.Parse(DegreeTextBox.Text);
                NewtonResult.Text = string.Format(valueFormatter, NewtonMethods.Root(number, degree));
                PowResult.Text = string.Format(valueFormatter, Math.Pow(number, 1 / degree));
            }
            catch(Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void BinCalculateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                uint number = uint.Parse(BinNumberTextBox.Text);
                BinResult.Text = BinFormatter.BinFormatter.IntToBinString(number);
                BinNetResult.Text = Convert.ToString(number, 2);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
    }
}
