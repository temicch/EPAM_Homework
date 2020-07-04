using System.Text;
using MainProgram.Utility;

namespace MainProgram.ViewModels
{
    internal class Task_10ViewModel : BaseViewModel
    {
        private const string FilePath = "testsResult.bin";
        private readonly TestsStorage.TestsStorage testsStorage = new TestsStorage.TestsStorage(FilePath);

        private int countToShow = 10;

        private bool isDesc;

        public Task_10ViewModel()
        {
            Tests = new StringBuilder();

            ShowTests();
        }

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