namespace AbstractFactory.Factories.WickerFurniture
{
    public class Sofa : IProductB
    {
        public Sofa(string parent)
        {
            Parent = parent;
        }

        public string Name { get; } = "I'm a wicker sofa";
        public string Parent { get; }
    }
}