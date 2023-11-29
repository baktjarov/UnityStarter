using UnityEngine;

namespace Characters.Enemy
{
    public abstract class EnemyBase : MonoBehaviour
    {
        public float power;
        public float speed;
        public Transform target;

        public virtual void Attack()
        {
            if(target == null)
            {
                target = FindObjectOfType<Player>().transform;
            }
        }

        public virtual void Stop()
        {

        }
    }
}