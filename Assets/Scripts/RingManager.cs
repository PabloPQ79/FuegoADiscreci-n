using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingManager : MonoBehaviour
{
    [SerializeField]
    private GameObject ringPrefab;
    [SerializeField]
    private Transform[] posRing;
    [SerializeField]
    private float timeBetweenEnemies = 10.0f;

    private void Start()
    {
        InvokeRepeating("CreateRing", 1.0f, timeBetweenEnemies);
    }
    private void CreateRing()
    {
        int n = Random.Range(0, posRing.Length);
        Instantiate(ringPrefab, posRing[n].position, posRing[n].rotation);
    }
}
