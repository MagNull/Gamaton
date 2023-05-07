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
        
        
        [Header("Diver")]
        [SerializeField]
        private float _diverSpeed = 1f;
        [SerializeField]
        private int _diverDamage = 10;
        [SerializeField] 
        private int _diverHealth = 5;
        [SerializeField]
        private AudioClip _diverDeathSound;

        [Header("Ship")] 
        [SerializeField] 
        private float _shipSpeed = 1f;
        [SerializeField]
        private int _shipDamage = 10;
        [SerializeField]
        private int _shipHealth = 5;
        [SerializeField]
        private AudioClip _shipDeathSound;
        [SerializeField]
        private AudioClip _shipBombReleaseSound;
        
        [Header("Bomb")]
        [SerializeField]
        private int _bombHealth;
        [SerializeField]
        private int _bombDamage;
        [SerializeField]
        private AudioClip _bombExplosionSound;
        
        [Header("Submarine")]
        [SerializeField]
        private float _submarineDuration = 2f;
        [SerializeField]
        private int _submarineDamage = 10;
        [SerializeField]
        private int _submarineHealth = 5;
        [SerializeField]
        private float _submarineCooldown;
        [SerializeField]
        private AudioClip _submarineDeathSound;
        [SerializeField]
        private AudioClip _submarineTorpedoReleaseSound;
        
        [Header("Torpedo")]
        [SerializeField]
        private float _torpedoDuration;
        [SerializeField]
        private int _torpedoHealth;
        [SerializeField]
        private int _torpedoDamage;
        [SerializeField]
        private AudioClip _torpedoDeathSound;

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
        [SerializeField]
        private AudioClip _soundWaveReleaseSound;

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
        private AudioClip _pointExplosionReleaseSound;
        
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


        public AudioClip DiverDeathSound => _diverDeathSound;
        public AudioClip ShipDeathSound => _shipDeathSound;
        public AudioClip ShipBombReleaseSound => _shipBombReleaseSound;
        public AudioClip BombExplosionSound => _bombExplosionSound;
        public AudioClip SubmarineDeathSound => _submarineDeathSound;
        public AudioClip SubmarineTorpedoReleaseSound => _submarineTorpedoReleaseSound;
        public AudioClip TorpedoDeathSound => _torpedoDeathSound;
        public AudioClip SoundWaveReleaseSound => _soundWaveReleaseSound;
        public AudioClip PointExplosionReleaseSound => _pointExplosionReleaseSound;

        
        public float DiverSpeed => _diverSpeed;
        public float ShipSpeed => _shipSpeed;
        public float SubmarineDuration => _submarineDuration;

        public int DiverDamage => _diverDamage;
        public int ShipDamage => _shipDamage;
        public int BombDamage => _bombDamage;
        public int BombHealth => _bombHealth;
        public int SubmarineDamage => _submarineDamage;
        
        public int DiverHealth => _diverHealth;
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