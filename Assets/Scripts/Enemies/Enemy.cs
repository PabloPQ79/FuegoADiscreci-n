using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    [Header("MOVEMENT")]
    [SerializeField]
    private int speed = 12;
    [SerializeField]
    private float distanceToPlayer = 6;

    [Header("ATTACK")]
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private Transform posBullet;
    [SerializeField]
    private float timeBetweenBullets;

    private GameObject player;
    private AudioSource shootAudio;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        InvokeRepeating("Attack", 1, timeBetweenBullets);
        shootAudio = GetComponent<AudioSource>();
    }

    private void Update()
    {
        // Si el player no existe deja de buscarlo
        if (player == null)
        {
            return;
           
        }
        transform.LookAt(player.transform.position);
        FollowPlayer();
    }

    private void FollowPlayer()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);
        if (distance > distanceToPlayer)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }

    private void Attack()
    {
        
        if (player != null)
        {
            Instantiate(bulletPrefab, posBullet.position, posBullet.rotation);
            shootAudio.Play();
        }
    }
}
