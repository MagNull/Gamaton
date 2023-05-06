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

    private void Start()
    {
        transform.DOScale(_scaleMultiplier, _spreadingDuration)
            .SetEase(Ease.OutCubic)
            .OnComplete(() => Destroy(gameObject));
    }
}