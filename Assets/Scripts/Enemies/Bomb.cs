using System;
using UnityEngine;

namespace DefaultNamespace.Enemies
{
    public class Bomb : DamageDealer
    {
        public int Damage = 3;

        private void Start()
        {
            Health = 1;
        }

        protected override void OnDie()
        {
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            GetComponent<Animator>().SetBool("Explode", true);
        }
        
        public void Destroy() => Destroy(gameObject);
    }
}