namespace PointApp
{
    public struct PointStartCommand : QFrameworkTest.ICommand
    {
        public void Execute()
        {
            GameStartEvent.Trigger();
        }
    }
}