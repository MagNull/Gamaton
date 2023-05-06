using System;

namespace DefaultNamespace
{
    public class City : DamageDealer
    {
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
        

        public override void TakeDamage(int damage)
        {
            base.TakeDamage(damage);
            if (Health < 0)
            {
                Explosion();
            }
        }

        private void Explosion()
        {
            OnExplosion += () => Destroy(gameObject);
            OnExplosion?.Invoke();
        }
    }
}