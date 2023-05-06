﻿using System.Collections.Generic;
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

    private EnemySpawner _enemySpawner;
    
    protected override void Configure(IContainerBuilder builder)
    {
        builder.RegisterComponent(_city);
        builder.RegisterComponent(_configs);
        builder.Register<EnemyFactory>(Lifetime.Singleton);
        builder.Register<EnemySpawner>(Lifetime.Singleton);
    }
    
    private void Start()
    {
        _enemySpawner = Container.Resolve<EnemySpawner>();
        _enemySpawner.InitializeTimers(new Dictionary<float, EnemyType>
        {
            { _configs.DelayBetweenSpawnDivers, EnemyType.Diver },
            { _configs.DelayBetweenSpawnShips, EnemyType.Ship },
            { _configs.DelayBetweenSpawnSubmarines, EnemyType.Submarine }
        });
    }

    private void Update()
    {
        _enemySpawner.Tick(Time.deltaTime);
    }
}