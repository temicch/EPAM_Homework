namespace AbstractFactory.Factories.OfficeFurniture
{
    public class Sofa : IProductB
    {
        public string Name { get; } = "I'm an office sofa";
        public string Parent { get; }

        public Sofa(string parent)
        {
            Parent = parent;
        }
    }
}