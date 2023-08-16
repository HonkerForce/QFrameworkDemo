using CounterApp;
using QFrameworkTest;

namespace PointApp
{
    public class PointGame : Architecture<PointGame>
    {
        protected override void Init()
        {
            RegisterModel<IPointAppModel>(new PointAppModel());
        }
    }
}