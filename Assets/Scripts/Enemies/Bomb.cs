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

        private AudioClip _explosionSound;
        [Inject]
        public void Construct(Configs configs)
        {
            _damage = configs.BombDamage;
            _health = configs.BombHealth;
            _explosionSound = configs.BombExplosionSound;
        }

        public override void Die()
        {
            var audioSource = new GameObject().AddComponent<AudioSource>();
            audioSource.PlayOneShot(_explosionSound, 2f);
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            GetComponent<Animator>().SetBool("Explode", true);
        }

        public void Destroy() => Destroy(gameObject);
    }
}