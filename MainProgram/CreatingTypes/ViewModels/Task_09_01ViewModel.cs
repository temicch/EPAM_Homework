using System;
using System.Collections.Generic;
using System.Linq;
using BinaryTree;
using MainProgram.Utility;
using TestResult;

namespace MainProgram.ViewModels
{
    internal class Task_09_01ViewModel : BaseViewModel
    {
        private readonly BinarySearchTree<int> digitsTree;
        private readonly BinarySearchTree<string> stringsTree;
        private readonly BinarySearchTree<IStudentTestResult> studentsTree;

        public Task_09_01ViewModel()
        {
            var rand = new Random();

            digitsTree = new BinarySearchTree<int>(Enumerable
                .Repeat(0, 10)
                .Select(i => rand.Next())
                .ToArray(), Comparer<int>.Create((x, y) => y - x));
            studentsTree = new BinarySearchTree<IStudentTestResult>(new[]
            {
                new StudentTest("EGE", "Ivanov Ivan", DateTime.Now, rand.Next(0, 100)),
                new StudentTest("EGE", "Bogdanova Elena", DateTime.Now, rand.Next(0, 100)),
                new StudentTest("EGE", "Percev Aleksandr", DateTime.Now, rand.Next(0, 100)),
                new StudentTest("EGE", "Gorelov Nikita", DateTime.Now, rand.Next(0, 100)),
                new StudentTest("EGE", "Velikaya Ariana", DateTime.Now, rand.Next(0, 100))
            }, Comparer<IStudentTestResult>.Create((x, y) => y.Score - x.Score));
            stringsTree = new BinarySearchTree<string>(new[]
            {
                "(A) In computer science, a red–black tree is a kind of self-balancing binary search tree.",
                "(D) The properties are designed such that this rearranging and recoloring can be performed efficiently.",
                "(D) Tracking the color of each node requires only 1 bit of information per node because there are only two colors.",
                "(C) In 1972, Rudolf Bayer[4] invented a data structure that was a special order-4 case of a B-tree."
            });
            OnPropertyChanged(nameof(Digits));
            OnPropertyChanged(nameof(Strings));
            OnPropertyChanged(nameof(Students));
        }

        public int[] Digits => digitsTree.ToArray();
        public string[] Students => studentsTree.Select(x => x.ToString()).ToArray();
        public string[] Strings => stringsTree.GetReversedEnumerator().ToArray();
    }
}