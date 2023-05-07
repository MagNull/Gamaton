using System;
using UnityEngine;
using VContainer;

namespace DefaultNamespace.Enemies
{
    public class Bomb : DamageActor
    {
        private int _damage;

        protected override int Damage => _damage;

        private int _health;

        protected override int Health
        {
            get => _health;
            set => _health = value;
        }

        [Inject]
        public void Construct(Configs configs)
        {
            _damage = configs.BombDamage;
            _health = configs.BombHealth;
        }

        public override void Die()
        {
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            GetComponent<Animator>().SetBool("Explode", true);
        }

        public void Destroy() => Destroy(gameObject);
    }
}