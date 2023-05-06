using System;
using UnityEngine;
using VContainer;

namespace DefaultNamespace.Enemies
{
    public class Diver : MonoBehaviour, IEnemy
    {
        private Vector3 _endPosition;
        
        [Inject]
        public void Construct(Vector3 endPosition)
        {
            _endPosition = endPosition;
        }
        
        private void Start()
        {
            Move();
        }

        public void Move()
        {
            
        }
        
        public void Attack()
        {
            throw new NotImplementedException();
        }
    }
}