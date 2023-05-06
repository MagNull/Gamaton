using System.Collections.Generic;
using DefaultNamespace.Enemies;
using UnityEngine;

namespace DefaultNamespace
{
    [CreateAssetMenu(fileName = "Configs", menuName = "Configs", order = 0)]
    public class Configs : ScriptableObject
    {
        [Header("Enemies")]
        [SerializeField]
        private Diver _diverPrefab;
        [SerializeField]
        private Submarine _submarinePrefab;
        
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

        [Header("GameSettings")]
        [SerializeField]
        private float _delayBetweenSpawnDivers = 1f;
        [SerializeField]
        private float _delayBetweenSpawnSubmarines = 5f;
        


        public float EnemySpeed => _enemySpeed;
        public int DriverDamage => _driverDamage;
        public int DriverHealth => _driverHealth;
        public float SoundWaveScaleMultiplier => _soundWaveScaleMultiplier;
        public float SoundWaveSpreadingDuration => _soundWaveSpreadingDuration;
        public float PointExplosionScaleMultiplier => _pointExplosionScaleMultiplier;
        public float PointExplosionSpreadingDuration => _pointExplosionSpreadingDuration;
        public float DelayBetweenSpawnDivers => _delayBetweenSpawnDivers;
        public float DelayBetweenSpawnSubmarines => _delayBetweenSpawnSubmarines;
        public Diver DiverPrefab => _diverPrefab;
        public Submarine SubmarinePrefab => _submarinePrefab;
        public IReadOnlyList<Vector3> Spawns => _spawns;
    }
}