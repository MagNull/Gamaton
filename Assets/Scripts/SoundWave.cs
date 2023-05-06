using DefaultNamespace;
using DG.Tweening;
using UnityEngine;
using VContainer;

public class SoundWave : MonoBehaviour
{
    private float _scaleMultiplier;
    private float _spreadingDuration;

    [Inject]
    public void Construct(Configs configs)
    {
        _scaleMultiplier = configs.SoundWaveScaleMultiplier;
        _spreadingDuration = configs.SoundWaveSpreadingDuration;
    }

    private void Awake()
    {
        transform.DOScale(_scaleMultiplier, _spreadingDuration);
    }
}
