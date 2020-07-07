using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using MainProgram.Utility;
using MainProgram.Views;

namespace MainProgram.ViewModels
{
    internal class MainWindowViewModel : BaseViewModel
    {
        private readonly MainWindow window = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();

        private Dictionary<string, Lazy<ContentControl>> views;

        public MainWindowViewModel()
        {
            OpenViewCommand = new BasicCommand(OpenView);
            InitViewModels();
        }

        public List<string> ViewsList => views.Select(x => x.Key).ToList();

        public BasicCommand OpenViewCommand { get; set; }

        private void InitViewModels()
        {
            views = new Dictionary<string, Lazy<ContentControl>>
            {
                //["01 Unit tests"] = null,
                //["02 Resource management. Garbage collector"] = null,
                ["03 Basic C # programming constructs"] = new Lazy<ContentControl>(() => new Task_03View()),
                ["04 Declaring and calling methods in C #"] = new Lazy<ContentControl>(() => new Task_04View()),
                ["05 Creating New Types in C #"] = new Lazy<ContentControl>(() => new Task_05View()),
                ["06 (01) Encapsulation. Overload operations"] = new Lazy<ContentControl>(() => new Task_06_01View()),
                ["06 (02) Encapsulation. Overload operations"] = new Lazy<ContentControl>(() => new Task_06_02View()),
                ["06 (03) Inheritance. Interfaces and Abstract Classes"] = new Lazy<ContentControl>(() => new Task_06_03View()),
                //["07 Exception Handling"] = null,
                ["08 Delegates and Events"] = new Lazy<ContentControl>(() => new Task_08View()),
                ["09 (01) Collections and Generic Types"] = new Lazy<ContentControl>(() => new Task_09_01View()),
                ["09 (02) Abstract factory"] = new Lazy<ContentControl>(() => new Task_09_02View()),
                ["10 LINQ Introduction"] = new Lazy<ContentControl>(() => new Task_10View()),
                ["11 (01) Garbage collector"] = new Lazy<ContentControl>(() => new Task_11_01View()),
                ["11 (02) Streams and IO"] = new Lazy<ContentControl>(() => new Task_11_02View()),
                ["12 XML Technologies"] = new Lazy<ContentControl>(() => new Task_12View()),
                ["13 ADO.NET EF"] = new Lazy<ContentControl>(() => new Task_13View()),
                //["14 Internal device types in .NET Framework. Resource management"] = null,
                //["15 Web Development Fundamentals"] = null,
                //["16 Database. Additional materials"] = null,
                //["17 Multithreading and asynchrony"] = null,
                //["18 Serialization"] = null,
                //["19 Web development (optional)"] = null,
                //["20 Reflection and Dependency Injection"] = null,
                //["21 Patterns and SOLID Principles"] = null,
                //["22 Continuous integration"] = null,
                //["23 Development methodologies"] = null,
                //["24 WCF Development Fundamentals"] = null
            };

            OnPropertyChanged(nameof(ViewsList));
        }

        private void OpenView(object obj)
        {
            var viewName = (string)obj;
            UIElement view = views[viewName].Value;
            if (view == null)
            {
                MessageBox.Show("This task is not implemented yet");
                return;
            }

            window.MainGrid.Children.Clear();
            window.MainGrid.Children.Add(view);
        }
    }
}