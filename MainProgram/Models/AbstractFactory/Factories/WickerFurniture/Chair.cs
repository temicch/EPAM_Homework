namespace AbstractFactory.Factories.WickerFurniture
{
    public class Chair : IProductA
    {
        public Chair(string parent)
        {
            Parent = parent;
        }

        public string Name { get; } = "I'm an Wicker chair!";
        public string Parent { get; }
    }
}