using AbstractFactory;
using AbstractFactory.Factories.OfficeFurniture;
using AbstractFactory.Factories.WickerFurniture;
using MainProgram.Utility;

namespace MainProgram.ViewModels
{
    internal class Task_09_02ViewModel : BaseViewModel
    {
        public Task_09_02ViewModel()
        {
            var client1 = new Client(new OfficeFurnitureFactory());
            var client2 = new Client(new WickerFurnitureFactory());
            Output += "Client1:\n";
            Output += $"{client1.GetProductsInfo()}\n";
            Output += "Client2:\n";
            Output += $"{client2.GetProductsInfo()}\n";
        }

        public string Output { get; } = string.Empty;
    }
}