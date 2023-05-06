using System;
using System.Linq;
using DG.Tweening;
using UnityEngine;
using VContainer;

namespace DefaultNamespace.Enemies
{
    public class Ship : MonoBehaviour
    {
        [SerializeField]
        private Bomb _bomb;
        private int _damage;
        private int _health;
        private float _speed;
        private float _centerPositionX;
        private Vector3 _endPosition;

        public event Action<int> OnAttack;
        
        [Inject]
        public void Construct(City city, Configs configs)
        {
            _centerPositionX = city.transform.position.x;
            _speed = configs.ShipSpeed;
            _damage = configs.ShipDamage;
            _health = configs.ShipHealth;
            _endPosition = configs.Spawns.Last(x => x != transform.position);
        }
        
        private void Start()
        {
            Move();
        }

        private void Move()
        {
            var position = transform.position;
            var center = new Vector2(_centerPositionX, position.y);
            var distance = Vector3.Distance(center, position);

            var sequence = DOTween.Sequence();
            sequence.Append(transform.DOMove(center, distance / _speed).SetEase(Ease.OutQuad)
                .OnComplete(Attack));
            sequence.Append(transform.DOMove(_endPosition, distance / _speed).SetEase(Ease.InQuad));
            sequence.OnComplete(() => Destroy(gameObject));
            sequence.Play();
        }

        private void Attack()
        {
            Instantiate(_bomb, transform.position, Quaternion.identity);
        }
    }
}