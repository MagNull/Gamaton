using System;
using DG.Tweening;
using UnityEngine;
using VContainer;

namespace DefaultNamespace.Enemies
{
    public class Ship : MonoBehaviour, IEnemy
    {
        private int _damage;
        private int _health;
        private float _speed;
        private float _endPositionY;

        public event Action<int> OnAttack;
        
        [Inject]
        public void Construct(City city, Configs configs)
        {
            _endPositionY = city.transform.position.y;
            _speed = configs.EnemySpeed;
            _damage = configs.DriverDamage;
            _health = configs.DriverHealth;
        }
        
        private void Start()
        {
            Move();
        }

        private void Move()
        {
            var direction = new Vector2(0, _endPositionY);
            var distance = Vector3.Distance(direction, transform.position);
            var move = transform.DOMove(direction, distance / _speed);
            move.onComplete += () => Attack();
            move.onComplete += () => transform.DOMove(direction, distance / _speed);
            move.onComplete += () => Destroy(this.gameObject);
        }

        public void Attack()
        {
            OnAttack?.Invoke(_damage);
        }
    }
}