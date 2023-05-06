using System;
using UnityEngine;
using VContainer;

namespace DefaultNamespace.Enemies
{
    public class Submarine : MonoBehaviour, IEnemy
    {
        private float _speed; 
        private int _damage;
        private int _health;
        public event Action<int> OnAttack;
        
        [Inject]
        public void Construct(City city, Configs configs)
        {
            _speed = configs.SubmarineSpeed;
            _damage = configs.SubmarineDamage;
            _health = configs.SubmarineHealth;
        }
        
        public void Move()
        {
            throw new NotImplementedException();
        }

        private void Attack()
        {
            OnAttack?.Invoke(_damage);
        }
    }
}