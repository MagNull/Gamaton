using UnityEngine;

namespace DefaultNamespace
{
    [CreateAssetMenu(fileName = "Configs", menuName = "Configs", order = 0)]
    public class Configs : ScriptableObject
    {
        [Header("Enemy")] 
        [SerializeField] 
        private Vector3 _cityPosition;
    }
}