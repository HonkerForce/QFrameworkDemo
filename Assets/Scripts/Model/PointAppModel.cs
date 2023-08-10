using QFrameworkTest;

namespace CounterApp
{
    public class PointAppModel : Singleton<PointAppModel>
    {
        PointAppModel()
        {
            
        }
        
        public BindableProperty<int> count = new();
    }
}