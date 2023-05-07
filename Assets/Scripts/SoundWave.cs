using DefaultNamespace;
using DG.Tweening;
using UnityEngine;
using VContainer;

public class SoundWave : DamageActor
{
    [SerializeField] private float _scaleMultiplier;
    [SerializeField] private float _spreadingDuration;

    private int _damage;
    protected override int Damage => _damage;
    private int _health;

    protected override int Health
    {
        get => _health;
        set => _health = value;
    }


    [Inject]
    public void Construct(Configs configs)
    {
        _scaleMultiplier = configs.SoundWaveScaleMultiplier;
        _spreadingDuration = configs.SoundWaveDuration;
        _damage = configs.SoundWaveDamage;
        _health = configs.SoundWaveHealth;
    }

    private void Start()
    {
        transform.DOScale(_scaleMultiplier, _spreadingDuration);
        transform.Rotate(Vector3.up, -90f);
    }

    private void Update()
    {
        transform.Translate(Vector3.right * (Time.deltaTime * _scaleMultiplier));
    }


    public override void Die()
    {
        Destroy(gameObject);
    }
}