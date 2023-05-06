using System;
using UnityEngine;

namespace DefaultNamespace.Enemies
{
    public class Submarine : MonoBehaviour, IEnemy
    {
        public event Action OnAttack;
        
        public void Move()
        {
            throw new NotImplementedException();
        }
        
        private void Attack()
        {
            OnAttack?.Invoke();
        }
    }
}