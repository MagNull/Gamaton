using System;
using UnityEngine;
using UnityEngine.Events;

namespace DefaultNamespace
{
    public class City : DamageActor
    {
        [SerializeField]
        private int _damage = 1;
        [SerializeField]
        private SpriteRenderer _renderer;
        [SerializeField]
        private Sprite _explosed;
        [SerializeField]
        private ProgressBar _bar;
        protected override int Damage => _damage;

        [SerializeField]
        private int _health;
        protected override int Health
        {
            get => _health;
            set => _health = value;
        }
        
        protected new void Awake()
        {
            base.Awake();
            OnExplosion.AddListener( () => _renderer.sprite = _explosed);
            OnExplosion.AddListener(() => _renderer.color = Color.white);
            OnExplosion.AddListener(() => Time.timeScale = 0);
            _bar._startHealth = Health;
            _bar._health = Health;
            OnDamage += x => _bar.SetProperty(x);
        }

        public UnityEvent OnExplosion;

        public override void Die()
        {
            Explosion();
        }

        private void Explosion()
        {
            OnExplosion?.Invoke();
        }
    }
}