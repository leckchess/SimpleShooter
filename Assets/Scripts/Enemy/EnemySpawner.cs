using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _enemyPrefabs;
    [SerializeField] private int _enemyCapacity;

    [SerializeField] private FloatRange XBoundiries;
    [SerializeField] private FloatRange ZBoundiries;

    private void Start()
    {
        SpawnEnemy();
    }

    private void SpawnEnemy()
    {
        Vector3 playerPosition = FindObjectOfType<Player>().transform.position;

        for (int i = 0; i < _enemyCapacity; i++)
        {
            Vector3 randPos = playerPosition + new Vector3(XBoundiries.Value, playerPosition.y, ZBoundiries.Value);
            Instantiate(_enemyPrefabs[Random.Range(0, _enemyPrefabs.Length)], randPos, Quaternion.identity);
        }
    }
}
