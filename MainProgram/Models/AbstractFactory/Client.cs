namespace AbstractFactory
{
    public class Client
    {
        private readonly IProductA productA;
        private readonly IProductB productB;

        public Client(IFactory factory)
        {
            productA = factory.CreateProductA();
            productB = factory.CreateProductB();
        }

        public string GetProductsInfo()
        {
            return $"{productA.Name} {productA.Parent}\n{productB.Name} {productB.Parent}";
        }
    }
}