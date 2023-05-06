using System;
using DefaultNamespace.Enemies;
using UnityEngine;

namespace DefaultNamespace
{
    public class City : MonoBehaviour
    {
        private int _health = 100;
        
        public int Health => _health;
        public event Action OnExplosion;
        public event Action OnDamaged;
        
        
        public void TakeDamage(int damage)
        {
            Debug.Log("Damage");
            if (damage > _health)
            {
                Collapse();
            }
            else
            {
                _health -= damage;
            }
        }

        private void Collapse()
        {
            OnExplosion += () => Destroy(gameObject);
            OnExplosion?.Invoke();
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.TryGetComponent(out Diver diver))
            {
                TakeDamage(diver.Damage);
                Destroy(diver.gameObject);
            }
            else if (col.gameObject.TryGetComponent(out Bomb bomb))
            {
                Debug.Log("ffff");
                TakeDamage(bomb.Damage);
                Destroy(bomb.gameObject);
            }
        }
    }
}