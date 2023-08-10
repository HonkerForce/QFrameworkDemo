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
                this.value = value;
                
                OnValueChanged?.Invoke();
            }
        }

        public BindableProperty()
        {
            value = default;
        }

        public Action OnValueChanged = null;
    }
}