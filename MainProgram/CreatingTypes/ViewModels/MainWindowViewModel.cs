using MainProgram.Utility;
using MainProgram.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace MainProgram.ViewModels
{
    class MainWindowViewModel : BaseViewModel
    {
        MainWindow window = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();

        Dictionary<string, ContentControl> views;

        public List<string> ViewsList => views.Select(x => x.Key).Distinct().ToList();

        public BasicCommand OpenViewCommand { get; set; }

        public MainWindowViewModel()
        {
            OpenViewCommand = new BasicCommand((obj) => OpenView(obj));
            InitViewModels();
        }

        private void InitViewModels()
        {
            views = new Dictionary<string, ContentControl>();
            views["01 Unit tests"] = null;
            views["02 Resource management. Garbage collector"] = null;
            views["03 Basic C # programming constructs"] = new Task_03View();
            views["04 Declaring and calling methods in C #"] = new Task_04View();
            views["05 Creating New Types in C #"] = new Task_05View();
            views["06 Encapsulation. Overload operations. Inheritance. Interfaces and Abstract Classes"] = new Task_06View();
            views["07 Exception Handling"] = null;
            views["08 Delegates and Events"] = null;
            views["09 Collections and Generic Types"] = null;
            views["10 LINQ Introduction"] = null;
            views["11 Streams and IO"] = null;
            views["12 XML Technologies"] = null;
            views["13 ADO.NET EF"] = null;
            views["14 Internal device types in .NET Framework. Resource management"] = null;
            views["15 Web Development Fundamentals"] = null;
            views["16 Database. Additional materials"] = null;
            views["17 Multithreading and asynchrony"] = null;
            views["18 Serialization"] = null;
            views["19 Web development (optional)"] = null;
            views["20 Reflection and Dependency Injection"] = null;
            views["21 Patterns and SOLID Principles"] = null;
            views["22 Continuous integration"] = null;
            views["23 Development methodologies"] = null;
            views["24 WCF Development Fundamentals"] = null;

            OnPropertyChanged(nameof(ViewsList));
        }

        private void OpenView(object obj)
        {
            string viewName = (string)obj;
            UIElement view = views[viewName];
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
