namespace AbstractFactory.Factories.OfficeFurniture
{
    public class Chair : IProductA
    {
        public string Name { get; } = "I'm an office chair!";
        public string Parent { get; }

        public Chair(string parent)
        {
            Parent = parent;
        }
    }
}