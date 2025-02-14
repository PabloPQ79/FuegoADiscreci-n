using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;
    [SerializeField]
    private Transform[] posEnemy;
    [SerializeField]
    private float timeBetweenEnemies = 5.0f;

    private void Start()
    {
        InvokeRepeating("CreateEnemies", 1.0f, timeBetweenEnemies);
    }
    private void CreateEnemies()
    {
        int n = Random.Range(0, posEnemy.Length);
        Instantiate(enemyPrefab, posEnemy[n].position, posEnemy[n].rotation);
    }
}
