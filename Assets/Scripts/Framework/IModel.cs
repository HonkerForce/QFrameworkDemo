namespace QFrameworkTest
{
    public interface IModel<T> where T : new()
    {
        T Value { get; set; }
    }

    public abstract class Model<T> : IModel<T> where T : new()
    {
        public delegate void ModelChangeCB(T value);
        
        protected T m_value;
        public abstract T Value { get; set; }

        public ModelChangeCB OnValueChanged = null;
    }
}