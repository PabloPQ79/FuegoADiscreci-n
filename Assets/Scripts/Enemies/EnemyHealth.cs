using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    [Header("HEALTH")]
    [SerializeField]
    private float maxHealth = 100;
    [SerializeField]
    private float currentHealth = 100;
    [SerializeField]
    private float damage = 20;
    [SerializeField]
    private Image lifeBar;
    [SerializeField]
    private ParticleSystem smallExplosion,
                           largeExplosion;

    private void Awake()
    {
        smallExplosion.Stop();
        largeExplosion.Stop();
        currentHealth = maxHealth;
        lifeBar.fillAmount = 1;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Laser"))
        {
            smallExplosion.Play();
            currentHealth -= damage;
            lifeBar.fillAmount = currentHealth / maxHealth;
            Destroy(other.gameObject);
            if (currentHealth <= 0)
            {
                Death();
            }
        }
    }

    private void Death()
    {
        largeExplosion.Play();
        Destroy(gameObject, 1);
    }
}
