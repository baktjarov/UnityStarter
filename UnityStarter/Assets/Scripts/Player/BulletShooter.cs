using Bullets;
using UnityEngine;

namespace Shooter
{
    public class BulletShooter : MonoBehaviour
    {
        [SerializeField] private Bullet _bullet;
        [SerializeField] private Transform _socket;
        [SerializeField] private float _shootPower = 2500f;
        [SerializeField] private float _damage;

        private void Update()
        {
            if (Input.GetMouseButtonUp(0))
            {
                Bullet bulletInstance = Instantiate(_bullet, _socket.position, _socket.rotation);
                bulletInstance.GetComponent<Rigidbody>().AddForce(bulletInstance.transform.forward * _shootPower);

                bulletInstance.SetDamage(_damage);
            }
        }
    }
}