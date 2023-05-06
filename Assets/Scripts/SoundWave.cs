using System;
using DefaultNamespace;
using DG.Tweening;
using UnityEngine;
using VContainer;

public class SoundWave : MonoBehaviour
{
    [SerializeField]
    private float _scaleMultiplier;
    [SerializeField]
    private float _spreadingDuration;

    [Inject]
    public void Construct(Configs configs)
    {
        _scaleMultiplier = configs.SoundWaveScaleMultiplier;
        _spreadingDuration = configs.SoundWaveSpreadingDuration;
    }
    

    private void Start()
    {
        transform.DOScale(_scaleMultiplier, _spreadingDuration);
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * _scaleMultiplier);
    }
}
