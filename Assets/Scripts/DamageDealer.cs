using DG.Tweening;
using UnityEngine;

namespace DefaultNamespace
{
    public abstract class DamageDealer : MonoBehaviour
    {
        private const float Duration = 0.1f;
        
        protected SpriteRenderer _spriteRenderer;
        protected int Health { get; set; }

        protected void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        public virtual void TakeDamage(int damage)
        {
            Health -= damage;
            PlayDamagedAnimation(damage);
        }
        
        private void PlayDamagedAnimation(int damage)
        {
            var color = _spriteRenderer.color;
            var sequence = DOTween.Sequence();
            sequence.Append(_spriteRenderer.DOColor(new Color(255 * damage / 100f, 0, 0), Duration));
            sequence.Append(_spriteRenderer.DOColor(color, Duration));
        }
    }
}