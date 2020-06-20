using System;
using System.Collections.Generic;
using BinaryTree;
using MainProgram.Utility;
using TestResult;

namespace MainProgram.ViewModels
{
    internal class Task_09_01ViewModel : BaseViewModel
    {
        private readonly BinarySearchTree<IStudentTestResult> tree;

        public Task_09_01ViewModel()
        {
            tree = new BinarySearchTree<IStudentTestResult>(new[]
                {
                    new StudentTest("EGE", "A Ivanov Ivan", DateTime.Now, 20),
                    new StudentTest("EGE", "B Hilov Egor", DateTime.Now, 50),
                    new StudentTest("EGE", "C Makarev Igor", DateTime.Now, 43),
                    new StudentTest("EGE", "D Novikova Anna", DateTime.Now, 2)
                },
                Comparer<IStudentTestResult>.Create((x, y) =>
                    string.Compare(x.StudentName, y.StudentName, StringComparison.InvariantCulture)));
        }
    }
}