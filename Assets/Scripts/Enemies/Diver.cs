using System;
using DG.Tweening;
using UnityEngine;
using VContainer;

namespace DefaultNamespace.Enemies
{
    public class Diver : DamageDealer
    {
        private int _damage;
        private float _speed;
        private Vector3 _endPosition;
        private Action<int> _onAttack;
        public override int Damage => _damage;
        
        [Inject]
        public void Construct(City city, Configs configs)
        {
            _endPosition = city.transform.position;
            _speed = configs.DriverSpeed;
            _damage = configs.DriverDamage;
             Health = configs.DriverHealth;
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
        

        protected override void OnDie()
        {
            Debug.Log("Diver die");
            GetComponent<Animator>().SetBool("Die", true);
        }

        public void Destroy() => Destroy(gameObject);
    }
}