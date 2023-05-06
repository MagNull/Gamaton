using DefaultNamespace;
using DG.Tweening;
using UnityEngine;
using VContainer;

public class PointExplosion : MonoBehaviour
{
    private float _scaleMultiplier;
    private float _spreadingDuration;

    [Inject]
    public void Construct(Configs configs)
    {
        _scaleMultiplier = configs.PointExplosionScaleMultiplier;
        _spreadingDuration = configs.PointExplosionSpreadingDuration;
    }

    private void Awake()
    {
        transform.DOScale(_scaleMultiplier, _spreadingDuration)
            .OnComplete(() => Destroy(gameObject, _spreadingDuration));
    }
}