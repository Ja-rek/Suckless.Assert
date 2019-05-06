namespace Suckless.Asserts
{
    public readonly struct Metadata<TValue>
    {
        private readonly string name;

        public Metadata(TValue value, string name)
        {
            Value = value;
            this.name = name;
        }

        public TValue Value { get; }
        internal string Name => name == null ? $"The value of {typeof(TValue)} " : $"The {name}: {typeof(TValue)} ";
    }
}
