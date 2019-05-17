namespace Suckless.Asserts
{
    public readonly ref struct Metadata<TValue>
    {
        private readonly string name;

        public Metadata(TValue value, string name)
        {
            Value = value;
            this.name = name;
        }

        public TValue Value { get; }
        public string Name => 
            name == null ? $"value: {typeof(TValue).Name}" : $"{name}: {typeof(TValue).Name}";
    }
}
