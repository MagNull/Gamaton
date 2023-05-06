using UnityEngine;
using UnityEngine.InputSystem;
using VContainer;
using VContainer.Unity;

namespace DefaultNamespace
{
    public class Shooter
    {
        private City _city;
        private IObjectResolver _resolver;
        private GameObject _soundWavePrefab;
        private GameObject _pointExplosionPrefab;

        public Shooter(City city, Configs configs)
        {
            _city = city;
            _soundWavePrefab = configs.SoundWavePrefab;
            _pointExplosionPrefab = configs.PointExplosionPrefab;
        }
        
        [Inject]
        public void Construct(IObjectResolver resolver)
        {
            _resolver = resolver;
        }

        public void AttackSoundWave()
        {
            var soundWave = _resolver.Instantiate(_soundWavePrefab, _city.transform.position, Quaternion.identity);
            
            var mouseWorldPos = GetMousePosition();

            soundWave.transform.LookAt(mouseWorldPos);
        }

        private Vector3 GetMousePosition()
        {
            var mousePos = Mouse.current.position.ReadValue();
            var plane = new Plane(Vector3.forward, _city.transform.position);
            var ray = Camera.main.ScreenPointToRay(mousePos);
            plane.Raycast(ray, out var enter);
            var mouseWorldPos = ray.GetPoint(enter);
            return mouseWorldPos;
        }

        public void AttackPointExplosion()
        {
            var mouseWorldPos = GetMousePosition();
            _resolver.Instantiate(_pointExplosionPrefab, mouseWorldPos, Quaternion.identity);
        }
    }
}