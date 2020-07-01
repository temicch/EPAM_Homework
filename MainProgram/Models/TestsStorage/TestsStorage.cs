using BinarySerializer;
using BinaryTree;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TestResult;

namespace TestsStorage
{
    /// <summary>
    /// Provides a convenient repository for reading student test results from binary files
    /// </summary>
    public class TestsStorage
    {
        /// <summary>
        /// Path to binary file
        /// </summary>
        public string FilePath { get; }
        private BinarySearchTree<IStudentTestResult> studentsTree;
        /// <summary>
        /// Create a repository of student test results. Data is taken from the specified file. If the file does not exist, a file with standard data will be created.
        /// </summary>
        /// <param name="filePath">Path to binary file</param>
        public TestsStorage(string filePath)
        {
            FilePath = filePath;
            InitBinFileIfNotExist();
            LoadTestsFromFile();
        }
        /// <summary>
        /// Create a file with standard data, if one does not exist
        /// </summary>
        public void InitBinFileIfNotExist()
        {
            if (File.Exists(FilePath))
                return;
            var randGenerator = new Random();
            var _studentsTree = new BinarySearchTree<IStudentTestResult>(new[]
            {
                new StudentTest("EGE", "Ivanov Ivan", DateTime.Now, 50),
                new StudentTest("EGE", "Bogdanova Elena", DateTime.Now, randGenerator.Next(0, 100)),
                new StudentTest("EGE", "Percev Aleksandr", DateTime.Now, randGenerator.Next(0, 100)),
                new StudentTest("EGE", "Gorelov Nikita", DateTime.Now, randGenerator.Next(0, 100)),
                new StudentTest("EGE", "Maddison Waller", DateTime.Now, randGenerator.Next(0, 100)),
                new StudentTest("EGE", "Edgar Odom", DateTime.Now, randGenerator.Next(0, 100)),
                new StudentTest("EGE", "Poppy - Mae Weston", DateTime.Now, randGenerator.Next(0, 100)),
                new StudentTest("EGE", "Donovan Hanson", DateTime.Now, randGenerator.Next(0, 100)),
                new StudentTest("EGE", "Jorden Mcfadden", DateTime.Now, randGenerator.Next(0, 100)),
                new StudentTest("EGE", "Rylan Parsons", DateTime.Now, randGenerator.Next(0, 100)),
                new StudentTest("EGE", "Charles Simmons", DateTime.Now, randGenerator.Next(0, 100)),
                new StudentTest("EGE", "Rahma Begum", DateTime.Now, randGenerator.Next(0, 100)),
                new StudentTest("EGE", "Ada Garrett", DateTime.Now, randGenerator.Next(0, 100)),
                new StudentTest("EGE", "Rosa Ellis", DateTime.Now, randGenerator.Next(0, 100)),
                new StudentTest("EGE", "Indi Larsen", DateTime.Now, randGenerator.Next(0, 100)),
                new StudentTest("EGE", "Efe Roche", DateTime.Now, randGenerator.Next(0, 100)),
                new StudentTest("EGE", "Scott Pruitt", DateTime.Now, randGenerator.Next(0, 100)),
                new StudentTest("EGE", "Korban Chapman", DateTime.Now, randGenerator.Next(0, 100)),
                new StudentTest("EGE", "Charlize Wang", DateTime.Now, randGenerator.Next(0, 100)),
                new StudentTest("EGE", "Anayah Jordan", DateTime.Now, randGenerator.Next(0, 100)),
                new StudentTest("EGE", "Miley Moses", DateTime.Now, randGenerator.Next(0, 100)),
                new StudentTest("EGE", "Steven Mckenna", DateTime.Now, randGenerator.Next(0, 100)),
                new StudentTest("EGE", "Varun England", DateTime.Now, randGenerator.Next(0, 100))
            });
            using (var fileStream = File.OpenWrite(FilePath))
                _studentsTree.WriteToFile(fileStream);
        }
        /// <summary>
        /// Download data from storage
        /// </summary>
        public void LoadTestsFromFile()
        {
            if (!File.Exists(FilePath))
                return;
            using (var fileStream = File.OpenRead(FilePath))
            {
                var collection = CollectionSerializer.ReadFromFile<IStudentTestResult>(fileStream);
                studentsTree = collection as BinarySearchTree<IStudentTestResult>;
            }
        }
        /// <summary>
        /// Get a collection of the specified number of student test results from the repository with the sort flag
        /// </summary>
        /// <param name="count">Number of records</param>
        /// <param name="isDesc">Sort flag</param>
        /// <returns></returns>
        public ICollection<IStudentTestResult> GetTests(int count, bool isDesc)
        {
            var enumerable = isDesc == false ? studentsTree.Take(count) : studentsTree.GetReversedEnumerator().Take(count);
            return enumerable.ToList();
        }
        /// <summary>
        /// Get a collection of all student test results with a sort flag
        /// </summary>
        /// <param name="isDesc">Sort flag</param>
        /// <returns></returns>
        public ICollection<IStudentTestResult> GetAllTests(bool isDesc)
        {
            var enumerable = isDesc == false ? studentsTree : studentsTree.GetReversedEnumerator();
            return enumerable.ToList();
        }
    }
}
