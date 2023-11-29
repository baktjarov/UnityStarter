using Characters;
using Characters.Enemy;
using System.Collections.Generic;
using UnityEngine;

namespace States
{
    public class GameplayState : MonoBehaviour
    {
        [Header("Positions")]
        [SerializeField] private Transform _mainPlayerPosition;
        [SerializeField] private List<Transform> _enemyPositions;

        [Header("Prefabs")]
        [SerializeField] private Player _playerPrefab;
        [SerializeField] private List<EnemyController> _enemyPrefabs;

        private void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            SpawnPlayer();

            foreach (EnemyController enemyController in _enemyPrefabs)
            {
                EnemyController newEnemy = Instantiate(enemyController, _enemyPositions[Random.Range(0, _enemyPositions.Count)]);
                newEnemy.onDie += SpawnRandomEnemy;
            }
        }

        private void SpawnRandomEnemy()
        {
            EnemyController newEnemy = Instantiate(_enemyPrefabs[Random.Range(0, _enemyPrefabs.Count)], _enemyPositions[Random.Range(0, _enemyPositions.Count)]);
            newEnemy.onDie += SpawnRandomEnemy;

        }

        private void SpawnPlayer()
        {
            Player newPlayer = Instantiate(_playerPrefab, _mainPlayerPosition.position, _mainPlayerPosition.rotation);
            newPlayer.onDie += SpawnPlayer;
        }
    }
}
