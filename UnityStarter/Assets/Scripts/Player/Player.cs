using Interfaces;
using System;
using UnityEngine;

namespace Characters
{
    public class Player : MonoBehaviour, IDamagable
    {
        public Action onDie { get; set; }
        public float health;

        private void Update()
        {
            if (health <= 0)
            {
                onDie?.Invoke();
                Destroy(gameObject);
            }
        }

        public void TakeDamage(float damage)
        {
            health = health - damage;
        }
    }
}