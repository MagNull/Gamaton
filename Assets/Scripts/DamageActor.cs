using System;
using DG.Tweening;
using UnityEngine;

namespace DefaultNamespace
{
    public abstract class DamageActor : MonoBehaviour
    {
        private const float Duration = 0.1f;
        
        protected SpriteRenderer _spriteRenderer;
        public Action<int> OnDamage;
        
        protected abstract int Damage { get; }
        protected abstract int Health { get; set; }

        protected void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.TryGetComponent(out DamageActor dd))
            {
                dd.TakeDamage(Damage);
            }
        }

        public void TakeDamage(int damage)
        {
            if (damage >= Health)
                damage = Health;
            OnDamage?.Invoke(damage);
            Health -= damage;
            if (Health <= 0)
            {
                GetComponent<Collider2D>().enabled = false;
                Die();
            }

            PlayDamagedAnimation();
        }

        public abstract void Die();    
        
        private void PlayDamagedAnimation()
        {
            _spriteRenderer.DOComplete();
            var color = _spriteRenderer.color;
            _spriteRenderer.DOColor(Color.red, Duration).OnComplete(() => _spriteRenderer.DOColor(color, Duration));
        }
    }
}