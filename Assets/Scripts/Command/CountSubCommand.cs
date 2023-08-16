using QFrameworkTest;

namespace CounterApp
{
    public struct CountSubCommand : QFrameworkTest.ICommand
    {
        public void Execute()
        {
            CounterGame.Get<ICounterAppModel>().count.Value--;
        }
    }
}