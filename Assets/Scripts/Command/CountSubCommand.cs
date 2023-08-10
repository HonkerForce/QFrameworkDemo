using QFrameworkTest;

namespace CounterApp
{
    public struct CountSubCommand : QFrameworkTest.ICommand
    {
        public void Execute()
        {
            CounterAppModel.Instance.count.Value--;
        }
    }
}