using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class City : DamageDealer
    {
        [SerializeField]
        private int _damage = 1;

        public override int Damage => _damage;

        protected new int Health
        {
            get => base.Health;
            set => base.Health = value;
        }
        
        protected new void Awake()
        {
            Health = 100;
            base.Awake();
        }

        public event Action OnExplosion;

        protected override void OnDie()
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