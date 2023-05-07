using DG.Tweening;
using UnityEngine;

namespace DefaultNamespace
{
    public abstract class DamageActor : MonoBehaviour
    {
        private const float Duration = 0.1f;
        
        protected SpriteRenderer _spriteRenderer;
        
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
            if(Health <= 0)
                return;
            
            Health -= damage;
            if (Health <= 0)
            {
                Die();
            }

            PlayDamagedAnimation();
        }

        public abstract void Die();    
        
        private void PlayDamagedAnimation()
        {
            var color = _spriteRenderer.color;
            var sequence = DOTween.Sequence();
            sequence.Append(_spriteRenderer.DOColor(Color.red, Duration));
            sequence.Append(_spriteRenderer.DOColor(color, Duration));
        }
    }
}