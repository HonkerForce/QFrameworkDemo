using QFrameworkTest;

namespace PointApp
{
    public interface IPointAppModel : IModel
    {
        BindableProperty<int> count { get; }
    }
    
    public class PointAppModel : IPointAppModel
    {
        public BindableProperty<int> count { get; } = new();
        
        public IArchitecture architecture { get; set; }
        
        public void Init()
        {
            
        }
    }
}