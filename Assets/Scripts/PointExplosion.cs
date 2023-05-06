using DefaultNamespace;
using DG.Tweening;
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
        transform.DOScale(_scaleMultiplier, _spreadingDuration)
            .SetEase(Ease.OutCubic)
            .OnComplete(() => Destroy(gameObject));
    }

    protected override void OnDie()
    {
        Destroy(gameObject);
    }
}