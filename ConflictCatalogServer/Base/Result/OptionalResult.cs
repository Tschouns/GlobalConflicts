
namespace Base.Result
{
    public class OptionalResult<T>
        where T : class
    {
        public OptionalResult(T value)
        {
            this.Value = value;
        }

        public T Value { get; }
        public bool HasValue => this.Value != null;
    }
}
