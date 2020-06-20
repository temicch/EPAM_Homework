namespace AbstractFactory.Factories.WickerFurniture
{
    public class WickerFurnitureFactory : IFactory
    {
        private const string CopyRight = "From Wicker Furniture factory";

        public IProductA CreateProductA()
        {
            return new Chair(CopyRight);
        }

        public IProductB CreateProductB()
        {
            return new Sofa(CopyRight);
        }
    }
}