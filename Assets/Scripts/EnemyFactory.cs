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
        private readonly City _city;
        
        public EnemyFactory(Configs configs, IObjectResolver objectResolver, City city)
        {
            _configs = configs;
            _objectResolver = objectResolver;
            _city = city;
        }

        public GameObject Create(EnemyType type)
        {
            GameObject enemy = type switch
            {
                EnemyType.Submarine => CreateSubmarine().gameObject,
                EnemyType.Ship => CreateShip().gameObject,
                EnemyType.Diver => CreateDiver().gameObject,
                _ => throw new ArgumentException("Unknown enemy type")
            };

            return enemy;
        }

        private Diver CreateDiver()
        {
            var position = GetRandomPosition();
            var rotation = GetRotation(position);
            return _objectResolver.Instantiate(_configs.DiverPrefab, position, rotation);
        }

        private Submarine CreateSubmarine()
        {
            var position = GetRandomPosition();
            var rotation = GetRotation(position);
            return _objectResolver.Instantiate(_configs.SubmarinePrefab, position, rotation);
        }
        
        private Ship CreateShip()
        {
            var spawnNum = Random.Range(0, 2);
            var position = spawnNum == 0 ? _configs.Spawns[1] : _configs.Spawns[2];
            var rotation = GetRotation(position);
            return _objectResolver.Instantiate(_configs.ShipPrefab, position, rotation);

        }

        private Vector3 GetRandomPosition()
        {
            var spawnNum = Random.Range(0, 2);
            var height = _configs.Spawns[1].y - _configs.Spawns[0].y;
            if (spawnNum == 0)
                return _configs.Spawns[0] + new Vector3(0, Random.Range(0f, height));
            
            return _configs.Spawns[1] - new Vector3(0, Random.Range(0f, height));
        }

        private Quaternion GetRotation(Vector3 position)
        {
            var direction = position.x > _city.transform.position.x ? new Vector3(0, 180) : Vector3.zero;
            return Quaternion.Euler(direction);
        }
    }
}