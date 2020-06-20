namespace AbstractFactory.Factories.WickerFurniture
{
    public class Chair : IProductA
    {
        public string Name { get; } = "I'm an Wicker chair!";
        public string Parent { get; }

        public Chair(string parent)
        {
            Parent = parent;
        }
    }
}