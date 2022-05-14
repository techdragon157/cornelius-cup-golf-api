namespace CorneliusCup.Golf.API.Responses
{
    public class Response<T>
    {
        public Response(T value)
        {
            Value = new List<T> { value };
        }

        public Response(IEnumerable<T>? value = null)
        {
            Value = value ?? Array.Empty<T>();
        }

        public int Count => Value?.Count() ?? 0;

        public IEnumerable<T> Value { get; set; }
    }
}
