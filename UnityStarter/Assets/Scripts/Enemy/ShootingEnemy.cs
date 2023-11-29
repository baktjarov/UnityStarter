using Bullets;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;

namespace Characters.Enemy
{
    public class ShootingEnemy : EnemyBase
    {
        [SerializeField] private Transform shootSocket;
        [SerializeField] private NavMeshAgent agent;
        [SerializeField] private Bullet bulletPrefab;
        [SerializeField] private int fireRate;
        [SerializeField] private float distanceToPlayer = 5f;
        private bool _canShoot = true;

        public override void Attack()
        {
            base.Attack();

            if (Vector3.Distance(transform.position, target.position) > distanceToPlayer)
            {
                GoToPlayer();
            }
            else
            {
                Shoot();
            }
        }

        public override void Stop()
        {
            agent.isStopped = true;
        }

        private void GoToPlayer()
        {
            agent.SetDestination(target.position);
        }

        private void Shoot()
        {
            transform.LookAt(target.position);

            if (_canShoot == true)
            {
                Bullet bulletInstance = Instantiate(bulletPrefab, shootSocket.position, shootSocket.rotation);
                bulletInstance.GetComponent<Rigidbody>().AddForce(bulletInstance.transform.forward * 5000f);

                bulletInstance.SetDamage(power);

                _canShoot = false;
                ResetCanShoot();
            }
        }

        private async void ResetCanShoot()
        {
            await Task.Delay(fireRate);
            _canShoot = true;
        }
    }
}