using QFrameworkTest;

namespace CounterApp
{
    public struct CountAddCommand : QFrameworkTest.ICommand
    {
        public void Execute()
        {
            CounterAppModel.Instance.count.Value++;
        }
    }
}