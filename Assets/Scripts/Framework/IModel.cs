namespace QFrameworkTest
{
    public interface IModel<T> where T : new()
    {
        T Value { get; set; }
    }
}