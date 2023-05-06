namespace DefaultNamespace
{
    public class EnemySpawner
    {
        private readonly EnemyFactory _enemyFactory;
        private readonly Configs _configs;
        private readonly Updater _updater;
        
        public EnemySpawner(EnemyFactory enemyFactory, Configs configs, Updater updater)
        {
            _enemyFactory = enemyFactory;
            _configs = configs;
            _updater = updater;
        }

        public void Start()
        {
            _updater.OnUpdate(() => _enemyFactory.Create(EnemyType.Diver));   
        }
    }
}