using System;
using DefaultNamespace.Enemies;
using DG.Tweening;
using UnityEngine;

namespace DefaultNamespace
{
    public class City : MonoBehaviour
    {
        [SerializeField] 
        private SpriteRenderer _spriteRenderer;
        
        private int _health = 100;
        private const float Duration = 0.1f;
        
        public event Action OnExplosion;
        
        public void TakeDamage(int damage)
        {
            Debug.Log("Damage");
            PlayDamagedAnimation();
            if (damage >= _health)
            {
                Explosion();
            }
            else
            {
                _health -= damage;
            }
        }

        private void Explosion()
        {
            OnExplosion += () => Destroy(gameObject);
            OnExplosion?.Invoke();
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