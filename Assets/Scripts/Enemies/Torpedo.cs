using System;
using DG.Tweening;
using UnityEngine;
using VContainer;

namespace DefaultNamespace.Enemies
{
    public class Torpedo : DamageActor
    {
        private int _damage;

        protected override int Damage => _damage;

        private int _health;

        protected override int Health
        {
            get => _health;
            set => _health = value;
        }

        private Vector3 _cityPos;
        private float _duration;

        public event Action OnDie; 

        [Inject]
        private void Construct(Configs configs, City city)
        {
            _cityPos = city.transform.position;
            _duration = configs.TorpedoDuration;
        }
        
        private void Start()
        {
            Health = 1;
            Launch();
        }

        private void Launch()
        {
            var target = _cityPos - transform.position;
            var sequence = DOTween.Sequence();
            sequence.Append(transform.DOMoveY(-1f, 0.1f))
                .Append(transform.DOMoveX(6f, 0.4f))
                .Append(transform.DOMove(target, _duration));
        }

        

        public override void Die()
        {
            OnDie?.Invoke();
            // TODO: Сделать анимацию
            // GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            // GetComponent<Animator>().SetBool("Explode", true);
            Destroy();
        }
        
        public void Destroy() => Destroy(gameObject);
    }
}