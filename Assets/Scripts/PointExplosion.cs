using DefaultNamespace;
using DG.Tweening;
using UnityEngine;
using VContainer;

public class PointExplosion : DamageActor
{
    private float _scaleMultiplier;
    private float _spreadingDuration;
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
        _scaleMultiplier = configs.PointExplosionScaleMultiplier;
        _spreadingDuration = configs.PointExplosionDuration;
        _damage = configs.PointExplosionDamage;
        _health = configs.PointExplosionHealth;
    }

    private void Start()
    {
        transform.localScale = Vector3.zero;
        transform.DOScale(_scaleMultiplier, _spreadingDuration)
            .SetEase(Ease.Flash)
            .OnComplete(() =>  transform.DOScale(0, _spreadingDuration)
                .SetEase(Ease.Flash).OnComplete(() => Destroy(gameObject)));
    }

    public override void Die()
    {
        Destroy(gameObject);
    }
}