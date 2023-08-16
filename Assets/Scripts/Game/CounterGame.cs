using System;
using QFrameworkTest;

namespace CounterApp
{
    public class CounterGame : Architecture<CounterGame>
    {
        protected override void Init()
        {
            RegisterSystem<IAchievementSystem>(new AchievementSystem());
            RegisterModel<ICounterAppModel>(new CounterAppModel());
            RegisterUtility<IStorage>(new PlayerStorage());
        }
    }
}