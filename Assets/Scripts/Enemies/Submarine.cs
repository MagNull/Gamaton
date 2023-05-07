using System;
using DG.Tweening;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace DefaultNamespace.Enemies
{
    public class Submarine : DamageActor
    {
        [SerializeField] private Torpedo _torpedo;
        private int _damage;
        protected override int Damage => _damage;
        private int _health;

        protected override int Health
        {
            get => _health;
            set => _health = value;
        }

        private Vector3 _cityPos;
        private IObjectResolver _resolver;
        private float _duration;
        private float _cooldown;

        [Inject]
        public void Construct(Configs configs, City city, IObjectResolver resolver)
        {
            _damage = configs.SubmarineDamage;
            _health = configs.SubmarineHealth;
            _duration = configs.SubmarineDuration;

            _cooldown = configs.SubmarineCooldown;
            
            _cityPos = city.transform.position;

            _resolver = resolver;
            
            Health = 10;
        }

        private void Start()
        {
            Move();
        }

        private void Move()
        {
            var centerCity = new Vector3(transform.position.x, _cityPos.y);
            var sequence = DOTween.Sequence();
            sequence.Append(transform.DOMove(centerCity, _duration)
                .OnComplete(Attack))
                .AppendInterval(_cooldown);
        }

        private void Attack()
        {
            _resolver.Instantiate(_torpedo, transform.position, transform.rotation);
        }

        public override void Die()
        {
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            GetComponent<Animator>().SetBool("Explode", true);
            Destroy(gameObject);
        }
    }
}