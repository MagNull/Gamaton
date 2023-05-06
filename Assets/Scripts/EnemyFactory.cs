using System;
using DefaultNamespace.Enemies;
using UnityEngine;
using VContainer;
using VContainer.Unity;
using Random = UnityEngine.Random;

namespace DefaultNamespace
{
    public class EnemyFactory
    {
        private readonly Configs _configs;
        private readonly IObjectResolver _objectResolver;
        public EnemyFactory(Configs configs, IObjectResolver objectResolver)
        {
            _configs = configs;
            _objectResolver = objectResolver;
        }

        public IEnemy Create(EnemyType type)
        {
            return type switch
            {
                EnemyType.Submarine => throw new NotImplementedException("Submarine enemy not implemented"),
                EnemyType.Ship => throw new NotImplementedException("Ship enemy not implemented"),
                EnemyType.Diver => CreateDiver(),
                _ => throw new ArgumentException("Unknown enemy type")
            };
        }

        private Diver CreateDiver()
        {
            var spawnNum = Random.Range(0, 2);
            var height = _configs.Spawns[1].y - _configs.Spawns[0].y;
            Vector3 position;
            if (spawnNum == 0)
            {
                position = _configs.Spawns[0] + new Vector3(0, Random.Range(0, height));
            }
            else
            {
                position = _configs.Spawns[1] - new Vector3(0, Random.Range(0, height));
            }
            
            return _objectResolver.Instantiate(_configs.DiverPrefab, position, Quaternion.identity);
        }
    }
}