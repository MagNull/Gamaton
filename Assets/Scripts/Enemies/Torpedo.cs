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
            var onLeftSide = transform.position.x < _cityPos.x;
            transform.DOMoveY(-1f, 1f)
                .OnComplete(() => transform.DOMoveX(onLeftSide ? 2f : -2f, 0.5f)
                    .OnComplete(() => transform.DOMove(_cityPos, _duration)));
        }


        public override void Die()
        {
            transform.DOKill();
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            GetComponent<Animator>().SetBool("Explode", true);
        }

        public void Destroy() => Destroy(gameObject);
    }
}