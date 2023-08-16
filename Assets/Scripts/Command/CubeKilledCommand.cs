using CounterApp;

namespace PointApp
{
    public struct CubeKilledCommand : QFrameworkTest.ICommand
    {
        public void Execute()
        {
            var model = PointGame.Get<IPointAppModel>();
            model.count.Value++;
            
            if (model.count.Value >= 9)
            {
                GamePassEvent.Trigger();
            }
        }
    }
}