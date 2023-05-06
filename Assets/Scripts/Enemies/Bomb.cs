using System;
using UnityEngine;

namespace DefaultNamespace.Enemies
{
    public class Bomb : DamageActor
    {
        private int _damage;

        private void Start()
        {
            Health = 1;
        }

        protected override int Damage => _damage;
        private int _health;
        protected override int Health
        {
            get => _health;
            set => _health = value;
        }

        protected override void OnDie()
        {
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            GetComponent<Animator>().SetBool("Explode", true);
        }
        
        public void Destroy() => Destroy(gameObject);
    }
}