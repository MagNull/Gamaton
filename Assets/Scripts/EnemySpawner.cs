namespace DefaultNamespace
{
    public class EnemySpawner
    {
        private readonly EnemyFactory _enemyFactory;
        private readonly Configs _configs;

        public EnemySpawner(EnemyFactory enemyFactory, Configs configs)
        {
            _enemyFactory = enemyFactory;
            _configs = configs;
        }

        public void Start()
        {
            
        }
    }
}