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
        
        [Header("Bomb")]
        [SerializeField]
        private int _bombHealth;
        [SerializeField]
        private int _bombDamage;
        
        [Header("Submarine")]
        [SerializeField]
        private float _submarineDuration = 2f;
        [SerializeField]
        private int _submarineDamage = 10;
        [SerializeField]
        private int _submarineHealth = 5;
        [SerializeField]
        private float _submarineCooldown;
        
        [Header("Torpedo")]
        [SerializeField]
        private float _torpedoDuration;
        [SerializeField]
        private int _torpedoHealth;
        [SerializeField]
        private int _torpedoDamage;

        [Header("Sound Wave")]
        [SerializeField]
        private GameObject _soundWavePrefab;
        [SerializeField] 
        private float _soundWaveDuration = 5;
        [SerializeField] 
        private float _soundWaveScaleMultiplier = 5;
        [SerializeField]
        private int _soundWaveDamage;
        [SerializeField]
        private int _soundWaveHealth;

        [Header("Point Explosion")]
        [SerializeField] 
        private GameObject _pointExplosionPrefab;
        [SerializeField]
        private float _pointExplosionDuration = 5;
        [SerializeField] 
        private float _pointExplosionScaleMultiplier = 5;
        [SerializeField]
        private int _pointExplosionDamage;
        [SerializeField]
        private int _pointExplosionHealth;
        
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
        public float SubmarineDuration => _submarineDuration;

        public int DriverDamage => _driverDamage;
        public int ShipDamage => _shipDamage;
        public int BombDamage => _bombDamage;
        public int BombHealth => _bombHealth;
        public int SubmarineDamage => _submarineDamage;
        
        public int DriverHealth => _driverHealth;
        public int ShipHealth => _shipHealth;
        public int SubmarineHealth => _submarineHealth;
        public float SubmarineCooldown => _submarineCooldown;
        public float TorpedoDuration => _torpedoDuration;
        public int TorpedoHealth => _torpedoHealth;
        public int TorpedoDamage => _torpedoDamage;
        
        public GameObject SoundWavePrefab => _soundWavePrefab;
        public float SoundWaveScaleMultiplier => _soundWaveScaleMultiplier;
        public float SoundWaveDuration => _soundWaveDuration;
        public int SoundWaveDamage => _soundWaveDamage;
        public int SoundWaveHealth => _soundWaveHealth;
        
        public GameObject PointExplosionPrefab => _pointExplosionPrefab;
        public float PointExplosionScaleMultiplier => _pointExplosionScaleMultiplier;
        public float PointExplosionDuration => _pointExplosionDuration;

        public int PointExplosionDamage => _pointExplosionDamage;
        public int PointExplosionHealth => _pointExplosionHealth;


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