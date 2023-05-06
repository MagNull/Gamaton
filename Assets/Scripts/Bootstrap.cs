using DefaultNamespace;
using UnityEngine;
using VContainer;
using VContainer.Unity;

public class Bootstrap : LifetimeScope
{
    [SerializeField]
    private Configs _configs;
    [SerializeField] 
    private City _city;

    private Updater _updater;
    private float _timer = 0f;
    
    protected override void Configure(IContainerBuilder builder)
    {
        _updater = new Updater();
        
        builder.RegisterComponent(_city);
        builder.RegisterComponent(_configs);
        builder.RegisterComponent(_updater);
        builder.Register<EnemyFactory>(Lifetime.Singleton);
        builder.Register<EnemySpawner>(Lifetime.Singleton);
    }
    
    private void Start()
    {
        var enemySpawner = Container.Resolve<EnemySpawner>();
        enemySpawner.Start();
    }

    private void Update()
    {
        _timer += Time.deltaTime;
        if (_timer < _configs.DelayBetweenSpawnEnemies)
            return;
        
        _updater.Update();
        _timer = 0;
    }
}