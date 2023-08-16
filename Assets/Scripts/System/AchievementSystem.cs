using QFrameworkTest;
using UnityEngine;

namespace CounterApp
{
    public interface IAchievementSystem : ISystem
    {
        
    }
    
    public class AchievementSystem : IAchievementSystem
    {
        public IArchitecture architecture { get; set; }

        
        public void Init()
        {
            var model = architecture.GetModel<ICounterAppModel>();
            
            model.count.OnValueChanged += newValue =>
            {
                var preCount = model.count.Value;
                if (preCount < 10 && newValue >= 10)
                {
                    Debug.Log("达成成就！");
                }
            };
        }
    }
}