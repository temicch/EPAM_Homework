namespace AbstractFactory
{
    public class Client
    {
        public IProductA ProductA;
        public IProductB ProductB;

        public Client(IFactory factory)
        {
            ProductA = factory.CreateProductA();
            ProductB = factory.CreateProductB();
        }
    }
}