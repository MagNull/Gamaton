using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class City : MonoBehaviour
    {
        private int _health;
        
        public int Health => _health;
        public event Action OnExplosion;
        
        
        public void TakeDamage(int damage)
        {
            if (damage > _health)
            {
                Exlposion();
            }
            else
            {
                _health -= damage;
            }
        }

        private void Exlposion()
        {
            OnExplosion?.Invoke();
        }
    }
}