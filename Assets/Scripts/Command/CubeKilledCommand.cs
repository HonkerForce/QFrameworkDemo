using CounterApp;

namespace PointApp
{
    public struct CubeKilledCommand : QFrameworkTest.ICommand
    {
        public void Execute()
        {
            PointAppModel.Instance.count.Value++;
            
            if (PointAppModel.Instance.count.Value >= 9)
            {
                GamePassEvent.Trigger();
            }
        }
    }
}