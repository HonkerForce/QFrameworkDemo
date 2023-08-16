using QFrameworkTest;
using UnityEngine;

namespace CounterApp
{
    public interface ICounterAppModel : IModel
    {
        BindableProperty<int> count { get; }
    }
    
    public class CounterAppModel : ICounterAppModel
    {
        public CounterAppModel()
        {
            
        }
        
        public BindableProperty<int> count { get; } = new()
        {
            Value = 0
        };

        public IArchitecture architecture { get; set; }

        public void Init()
        {
            count.Value = architecture.GetUtility<IStorage>().LoadInt("Counter_Count");
            count.OnValueChanged += newValue =>
            {
                architecture.GetUtility<IStorage>().SaveInt("Counter_Count", newValue);
            };
        }
    }
}