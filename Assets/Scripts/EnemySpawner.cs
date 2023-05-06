using System.Collections.Generic;

namespace DefaultNamespace
{
    public class EnemySpawner
    {
        private readonly EnemyFactory _enemyFactory;
        private readonly Configs _configs;
        private readonly List<Timer> _timers;

        public EnemySpawner(EnemyFactory enemyFactory, Configs configs)
        {
            _enemyFactory = enemyFactory;
            _configs = configs;
            _timers = new List<Timer>();
        }

        public void InitializeTimers(Dictionary<(float, float), EnemyType> timeTypes)
        {
            foreach (var timeType in timeTypes)
            {
                var timer = new Timer(timeType.Key.Item1, timeType.Key.Item2);
                timer.OnEnd += () => _enemyFactory.Create(timeType.Value);
                _timers.Add(timer);
            }
        }

        public void Tick(float deltaTime)
        {
            foreach(var timer in _timers)
                timer.Tick(deltaTime);
        }
    }
}