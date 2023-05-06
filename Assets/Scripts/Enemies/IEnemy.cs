using System;

namespace DefaultNamespace.Enemies
{
    public interface IEnemy
    {
        public virtual void Attack()
        {
            throw new NotImplementedException();
        }
    }
}