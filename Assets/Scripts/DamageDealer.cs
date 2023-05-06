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
            PlayDamagedAnimation();
        }
        
        private void PlayDamagedAnimation()
        {
            var color = _spriteRenderer.color;
            var sequence = DOTween.Sequence();
            sequence.Append(_spriteRenderer.DOColor(Color.red, Duration));
            sequence.Append(_spriteRenderer.DOColor(color, Duration));
        }
    }
}