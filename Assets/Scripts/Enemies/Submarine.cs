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

        [Inject]
        public void Construct(Configs configs, City city, IObjectResolver resolver)
        {
            _damage = configs.SubmarineDamage;
            _health = configs.SubmarineHealth;
            // TODO: Прокинуть duration
            
            _cityPos = city.transform.position;
            
            _resolver = resolver;
        }

        private void Start()
        {
            Move();
        }

        private void Move()
        {
            var centerCity = new Vector3(transform.position.x, _cityPos.y);
            transform.DOMove(centerCity, 2f)
                .OnComplete(Attack);
        }

        private void Attack()
        {
            var torpedo = _resolver.Instantiate(_torpedo, transform.position, Quaternion.identity);
            torpedo.OnDie += Attack;
        }

        public override void Die()
        {
            // TODO: Сделать взрыв
            Destroy(gameObject);
        }
    }
}