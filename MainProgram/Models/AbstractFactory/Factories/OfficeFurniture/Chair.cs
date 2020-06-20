namespace AbstractFactory.Factories.OfficeFurniture
{
    public class Chair : IProductA
    {
        public Chair(string parent)
        {
            Parent = parent;
        }

        public string Name { get; } = "I'm an office chair!";
        public string Parent { get; }
    }
}