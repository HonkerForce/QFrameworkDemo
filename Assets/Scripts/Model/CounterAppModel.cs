using QFrameworkTest;
namespace CounterApp
{
    public class CounterAppModel : Singleton<CounterAppModel>
    {
        CounterAppModel()
        {
            
        }
        
        public BindableProperty<int> count = new();
    }
}