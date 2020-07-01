using MainProgram.Utility;
using System.Text;

namespace MainProgram.ViewModels
{
    internal class Task_10ViewModel : BaseViewModel
    {
        private const string filePath = "testsResult.bin";
        private TestsStorage.TestsStorage testsStorage = new TestsStorage.TestsStorage(filePath);

        public Task_10ViewModel()
        {
            Tests = new StringBuilder();

            ShowTests();
        }

        private bool isDesc = false;
        public bool IsDesc
        {
            get => isDesc;
            set
            {
                if (value == isDesc)
                    return;
                isDesc = value;
                ShowTests();
            }
        }

        private int countToShow = 10;
        public int CountToShow
        {
            get => countToShow;
            set
            {
                if (value < 0 || countToShow == value)
                    return;
                countToShow = value;
                ShowTests();
            }
        }
        public StringBuilder Tests { get; set; }

        private void ShowTests()
        {
            Tests.Clear();
            Tests.Capacity = CountToShow;
            var tests = testsStorage.GetTests(CountToShow, IsDesc);
            foreach (var record in tests)
                Tests.AppendLine(record.ToString());
            OnPropertyChanged(nameof(Tests));
        }

    }
}
