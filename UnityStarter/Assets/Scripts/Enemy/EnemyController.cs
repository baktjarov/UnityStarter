using Interfaces;
using System;
using UnityEngine;

namespace Characters.Enemy
{
    public class EnemyController : MonoBehaviour, IDamagable
    {
        public Action onDie { get; set; }
        [SerializeField] private float _health;
        [SerializeField] private EnemyBase _enemyBase;

        private void Start()
        {
            _health = 100;
        }

        private void Update()
        {
            if(_health <= 0)
            {
                onDie?.Invoke();

                Destroy(gameObject);
                return;
            }

            if (_health > 0)
            {
                _enemyBase.Attack();
            }
            else
            {
                _enemyBase.Stop();
            }
        }

        public void TakeDamage(float damage)
        {
            _health = _health - damage;
        }
    }
}