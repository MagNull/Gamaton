using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class City : DamageActor
    {
        [SerializeField]
        private int _damage = 1;

        protected override int Damage => _damage;

        private int _health;
        protected override int Health
        {
            get => _health;
            set => _health = value;
        }
        
        protected new void Awake()
        {
            Health = 100;
            base.Awake();
        }

        public event Action OnExplosion;

        public override void Die()
        {
            Explosion();
        }

        private void Explosion()
        {
            OnExplosion += () => Destroy(gameObject);
            OnExplosion?.Invoke();
        }
    }
}