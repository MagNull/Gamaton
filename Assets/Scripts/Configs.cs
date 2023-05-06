using System.Collections.Generic;
using DefaultNamespace.Enemies;
using UnityEngine;
using UnityEngine.Serialization;

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
        private float _driverSpeed = 1f;
        [SerializeField]
        private int _driverDamage = 10;
        [SerializeField] 
        private int _driverHealth = 5;

        [Header("Ship")] 
        [SerializeField] 
        private float _shipSpeed = 1f;
        [SerializeField]
        private int _shipDamage = 10;
        [SerializeField]
        private int _shipHealth = 5;
        
        [Header("Submarine")]
        [SerializeField]
        private float _submarineSpeed = 1f;
        [SerializeField]
        private int _submarineDamage = 10;
        [SerializeField]
        private int _submarineHealth = 5;
        
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
        private float _startSpawnDivers = 0.5f;
        [SerializeField]
        private float _endSpawnDivers = 2f;
        [SerializeField]
        private float _startSpawnSubmarines = 5f;
        [SerializeField]
        private float _endSpawnSubmarines = 7.5f;
        [SerializeField]
        private float _startSpawnShips = 10f;
        [SerializeField]
        private float _endSpawnShips = 15f;
        
        
        public float DriverSpeed => _driverSpeed;
        public float ShipSpeed => _shipSpeed;
        public float SubmarineSpeed => _submarineSpeed;

        public int DriverDamage => _driverDamage;
        public int ShipDamage => _shipDamage;
        public int SubmarineDamage => _submarineDamage;
        
        public int DriverHealth => _driverHealth;
        public int ShipHealth => _shipHealth;
        public int SubmarineHealth => _submarineHealth;
        
        public GameObject SoundWavePrefab => _soundWavePrefab;
        public float SoundWaveScaleMultiplier => _soundWaveScaleMultiplier;
        public float SoundWaveSpreadingDuration => _soundWaveSpreadingDuration;
        
        public GameObject PointExplosionPrefab => _pointExplosionPrefab;
        public float PointExplosionScaleMultiplier => _pointExplosionScaleMultiplier;
        public float PointExplosionSpreadingDuration => _pointExplosionSpreadingDuration;

        public float StartSpawnDivers => _startSpawnDivers;
        public float EndSpawnDivers => _endSpawnDivers;
        public float StartSpawnSubmarines => _startSpawnSubmarines;
        public float EndSpawnSubmarines => _endSpawnSubmarines;
        public float StartSpawnShips => _startSpawnShips;
        public float EndSpawnShips => _endSpawnShips;
        public Diver DiverPrefab => _diverPrefab;
        public Submarine SubmarinePrefab => _submarinePrefab;
        public Ship ShipPrefab => _shipPrefab;
        public IReadOnlyList<Vector3> Spawns => _spawns;
    }
}