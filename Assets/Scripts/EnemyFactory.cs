using UnityEngine;

namespace DefaultNamespace
{
    public class EnemyFactory
    {
        public EnemyFactory(Configs configs)
        {
               
        }
        
        public void Create(EnemyType type)
        {
            switch (type)
            {
                case EnemyType.Submarine:
                    return;
                case EnemyType.Ship:
                    return;
                case EnemyType.Diver:
                    return;
            }   
        }
    }
}