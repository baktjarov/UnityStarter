using Characters;
using Characters.Enemy;
using UnityEngine;

public class FireEnemy : EnemyBase
{
    [SerializeField] private float _minDistanceToPlayer;
    [SerializeField] private bool _canAttack = true;
    private Player _currentPlayer;

    private void Update()
    {
        if (_currentPlayer != null)
        {
            _currentPlayer.TakeDamage(power);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        var player = other.gameObject.GetComponent<Player>();

        if (player != null)
        {
            _currentPlayer = player;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        var player = other.gameObject.GetComponent<Player>();

        if (player != null)
        {
            _currentPlayer = null;
        }
    }

    public override void Attack()
    {
        base.Attack();

        if (_canAttack == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed);
        }
    }

    public override void Stop()
    {
        _canAttack = false;
    }
}