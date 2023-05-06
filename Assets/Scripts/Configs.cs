using System.Collections.Generic;
using DefaultNamespace.Enemies;
using UnityEngine;
using UnityEngine.Serialization;

namespace DefaultNamespace
{
    [CreateAssetMenu(fileName = "Configs", menuName = "Configs", order = 0)]
    public class Configs : ScriptableObject
    {
        [Header("Enemies")] [SerializeField]
        private Diver _diverPrefab;
        
        [Header("Driver")]
        [SerializeField]
        private float _enemySpeed = 1f;
        [SerializeField]
        private int _driverDamage = 10;
        [SerializeField] 
        private int _driverHealth = 5;
        
        [Header("Attack")]
        [SerializeField] 
        private float _soundWaveSpreadingDuration = 5;
        [SerializeField] 
        private float _soundWaveScaleMultiplier = 5;
        [SerializeField] 
        private float _pointExplosionSpreadingDuration = 5;
        [SerializeField] 
        private float _pointExplosionScaleMultiplier = 5;
        [SerializeField]
        private List<Vector3> _spawns;

        [Header("GameSettings")] [SerializeField]
        private float _delayBetweenSpawnEnemies = 1f;
        


        public float EnemySpeed => _enemySpeed;
        public int DriverDamage => _driverDamage;
        public int DriverHealth => _driverHealth;
        public float SoundWaveScaleMultiplier => _soundWaveScaleMultiplier;
        public float SoundWaveSpreadingDuration => _soundWaveSpreadingDuration;
        public float PointExplosionScaleMultiplier => _pointExplosionScaleMultiplier;
        public float PointExplosionSpreadingDuration => _pointExplosionSpreadingDuration;
        public float DelayBetweenSpawnEnemies => _delayBetweenSpawnEnemies;
        public Diver DiverPrefab => _diverPrefab;
        public IReadOnlyList<Vector3> Spawns => _spawns;
    }
}