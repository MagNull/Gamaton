using System;

namespace DefaultNamespace.Enemies
{
    public interface IEnemy
    {
        public abstract event Action<int> OnAttack;
        
        public virtual void Attack()
        {
            throw new NotImplementedException();
        }
    }
}