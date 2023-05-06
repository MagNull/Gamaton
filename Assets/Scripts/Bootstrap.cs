using System.Collections.Generic;
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
    [SerializeField]
    private InputBinder _inputBinder;

    private EnemySpawner _enemySpawner;
    
    protected override void Configure(IContainerBuilder builder)
    {
        builder.RegisterComponent(_city);
        builder.RegisterComponent(_configs);
        builder.RegisterComponent(_inputBinder);

        var shooter = new Shooter(_city, _configs);
        builder.RegisterComponent(shooter);

        builder.Register<EnemyFactory>(Lifetime.Singleton);
        builder.Register<EnemySpawner>(Lifetime.Singleton);
    }
    
    private void Start()
    {
        _inputBinder.BindLMBCLick(Container.Resolve<Shooter>().AttackSoundWave);
        _inputBinder.BindRMBCLick(Container.Resolve<Shooter>().AttackPointExplosion);
        _enemySpawner = Container.Resolve<EnemySpawner>();
        _enemySpawner.InitializeTimers(new Dictionary<(float, float), EnemyType>
        {
            { (_configs.StartSpawnDivers, _configs.EndSpawnDivers), EnemyType.Diver },
            { (_configs.StartSpawnShips, _configs.EndSpawnShips), EnemyType.Ship },
            { (_configs.StartSpawnSubmarines, _configs.EndSpawnSubmarines), EnemyType.Submarine }
        });
    }

    private void Update()
    {
        _enemySpawner.Tick(Time.deltaTime);
    }
}