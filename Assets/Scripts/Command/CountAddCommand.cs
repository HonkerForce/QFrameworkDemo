using QFrameworkTest;

namespace CounterApp
{
    public struct CountAddCommand : QFrameworkTest.ICommand
    {
        public void Execute()
        {
            CounterGame.Get<ICounterAppModel>().count.Value++;
        }
    }
}