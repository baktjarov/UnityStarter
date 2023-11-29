using Interfaces;
using UnityEngine;

namespace Bullets
{
    public class Bullet : MonoBehaviour
    {
        private float _damage;

        public void SetDamage(float newDamage)
        {
            _damage = newDamage;
        }

        private void OnTriggerEnter(Collider other)
        {
            var damagable = other.GetComponent<IDamagable>();

            if (damagable != null)
            {
                damagable.TakeDamage(_damage);
            }
        }
    }
}