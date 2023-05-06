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
        [SerializeField]
        private Ship _shipPrefab;
        
        [Header("Driver")]
        [SerializeField]
        private float _enemySpeed = 1f;
        [SerializeField]
        private int _driverDamage = 10;
        [SerializeField] 
        private int _driverHealth = 5;
        
        [Header("Sound Wave")]
        [SerializeField]
        private GameObject _soundWavePrefab;
        [SerializeField] 
        private float _soundWaveSpreadingDuration = 5;
        [SerializeField] 
        private float _soundWaveScaleMultiplier = 5;

        [Header("Point Explosion")]
        [SerializeField] 
        private GameObject _pointExplosionPrefab;
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
        [SerializeField]
        private float _delayBetweenSpawnShips = 10f;
        
        
        public float EnemySpeed => _enemySpeed;
        
        public int DriverDamage => _driverDamage;
        public int DriverHealth => _driverHealth;
        
        public GameObject SoundWavePrefab => _soundWavePrefab;
        public float SoundWaveScaleMultiplier => _soundWaveScaleMultiplier;
        public float SoundWaveSpreadingDuration => _soundWaveSpreadingDuration;
        
        public GameObject PointExplosionPrefab => _pointExplosionPrefab;
        public float PointExplosionScaleMultiplier => _pointExplosionScaleMultiplier;
        public float PointExplosionSpreadingDuration => _pointExplosionSpreadingDuration;
        public float DelayBetweenSpawnSubmarines => _delayBetweenSpawnSubmarines;
        public float DelayBetweenSpawnDivers => _delayBetweenSpawnDivers;
        public float DelayBetweenSpawnShips => _delayBetweenSpawnShips;
        public Diver DiverPrefab => _diverPrefab;
        public Submarine SubmarinePrefab => _submarinePrefab;
        public Ship ShipPrefab => _shipPrefab;
        public IReadOnlyList<Vector3> Spawns => _spawns;
    }
}