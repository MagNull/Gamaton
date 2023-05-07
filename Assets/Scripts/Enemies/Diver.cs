using System;
using DG.Tweening;
using UnityEngine;
using VContainer;

namespace DefaultNamespace.Enemies
{
    public class Diver : DamageActor
    {
        private int _damage;
        private float _speed;
        private Vector3 _endPosition;
        private Action<int> _onAttack;
        private AudioClip _deathSound;
        protected override int Damage => _damage;
        private int _health;
        protected override int Health
        {
            get => _health;
            set => _health = value;
        }

        [Inject]
        public void Construct(City city, Configs configs)
        {
            _endPosition = city.transform.position;
            _speed = configs.DiverSpeed;
            _damage = configs.DiverDamage;
            _health = configs.DiverHealth;
            _deathSound = configs.DiverDeathSound;
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


        public override void Die()
        {
            var source = new GameObject().AddComponent<AudioSource>();
            source.PlayOneShot(_deathSound, .1f);
            GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<Animator>().SetBool("Die", true);
        }

        public void Destroy() => Destroy(gameObject);
    }
}