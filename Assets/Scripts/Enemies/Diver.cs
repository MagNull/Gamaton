using System;
using DG.Tweening;
using UnityEngine;
using VContainer;

namespace DefaultNamespace.Enemies
{
    public class Diver : MonoBehaviour, IEnemy
    {
        private int _damage;
        private int _health;
        private float _speed;
        private Vector3 _endPosition;
        private Action<int> _onAttack;
        public int Damage => _damage;

        public event Action<int> OnAttack;

        [Inject]
        public void Construct(City city, Configs configs)
        {
            _endPosition = city.transform.position;
            _speed = configs.DriverSpeed;
            _damage = configs.DriverDamage;
            _health = configs.DriverHealth;
        }

        private void Start()
        {
            Move();
        }

        private void Move()
        {
            var distance = Vector3.Distance(_endPosition, transform.position);
            transform.DOMove(_endPosition, distance / _speed);
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            Debug.Log("OnCollisionEnter");
            if (col.gameObject.TryGetComponent(out City city))
            {
                Attack();
            }
        }

        private void Attack()
        {
            OnAttack?.Invoke(_damage);
            OnDie();
        }
        

        private void OnDie()
        {
            Destroy(gameObject);
        }
    }
}