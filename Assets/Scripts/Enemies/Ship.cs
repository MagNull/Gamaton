using System;
using System.Linq;
using DG.Tweening;
using UnityEngine;
using VContainer;

namespace DefaultNamespace.Enemies
{
    public class Ship : DamageActor
    {
        [SerializeField]
        private Bomb _bomb;
        private int _damage;
        private int _health;
        private float _speed;
        private float _centerPositionX;
        private Vector3 _endPosition;
        private Sequence _sequence;
        
        protected override int Damage => _damage;
        protected override int Health 
        {
            get => _health;
            set => _health = value;
        }

        [Inject]
        public void Construct(City city, Configs configs)
        {
            _centerPositionX = city.transform.position.x;
            _speed = configs.ShipSpeed;
            _damage = configs.ShipDamage;
            _health = configs.ShipHealth;
            _endPosition = configs.Spawns.Last(x => x != transform.position);
        }
        
        private void Start()
        {
            Move();
        }

        private void Move()
        {
            var position = transform.position;
            var center = new Vector2(_centerPositionX, position.y);
            var distance = Vector3.Distance(center, position);

            _sequence = DOTween.Sequence();
            _sequence.Append(transform.DOMove(center, distance / _speed).SetEase(Ease.OutQuad)
                .OnComplete(Attack));
            _sequence.Append(transform.DOMove(_endPosition, distance / _speed).SetEase(Ease.InQuad));
            _sequence.OnComplete(() => Destroy(gameObject));
            _sequence.Play();
        }

        private void Attack()
        {
            Instantiate(_bomb, transform.position, Quaternion.identity);
        }

        public override void Die()
        {
            if(_sequence is not null && _sequence.IsActive())
                _sequence.Kill();
            Destroy(gameObject);
        }
    }
}