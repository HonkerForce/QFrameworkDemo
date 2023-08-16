using System;

namespace QFrameworkTest
{
    public class BindableProperty<T> where T : new()
    {
        private T value;
        public T Value
        {
            get => value;
            set
            {
                OnValueChanged?.Invoke(value);
                this.value = value;
            }
        }

        public BindableProperty()
        {
            value = default;
        }

        public Action<T> OnValueChanged = null;
    }
}