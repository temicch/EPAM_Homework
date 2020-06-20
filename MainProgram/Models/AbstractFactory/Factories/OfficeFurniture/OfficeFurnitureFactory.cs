namespace AbstractFactory.Factories.OfficeFurniture
{
    public class OfficeFurnitureFactory : IFactory
    {
        private const string CopyRight = "From Office Furniture factory";

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