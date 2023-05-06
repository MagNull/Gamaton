using UnityEngine;
using VContainer;

namespace DefaultNamespace
{
    public class Shooter
    {
        private City _city;
        private GameObject _soundWavePrefab;
        private GameObject _pointExplosionPrefab;

        [Inject]
        public void Construct(City city, Configs configs)
        {
            _city = city;
        }

        public void AttackSoundWave()
        {
            var mousePos = UnityEngine.Input.mousePosition;
            var mouseWorldPos = Camera.current.ScreenToWorldPoint(mousePos);
            var cityPos = _city.transform.position;
            var soundWave = Object.Instantiate(_soundWavePrefab, cityPos, Quaternion.identity);
            var targetPos = mouseWorldPos - cityPos;
            soundWave.transform.right = targetPos;
        }
        
        public void AttackPointExplosion()
        {
            var mousePos = UnityEngine.Input.mousePosition;
            var mouseWorldPos = Camera.current.ScreenToWorldPoint(mousePos);
            Object.Instantiate(_pointExplosionPrefab, mouseWorldPos, Quaternion.identity);
        }
    }
}