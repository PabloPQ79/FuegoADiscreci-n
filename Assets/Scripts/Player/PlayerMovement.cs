using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [Header("VELOCIDAD")]
    [SerializeField]
    private int speed;
    [SerializeField]
    private int turnSpeed = 200;
    [Header("ATTACK")]
    [SerializeField]
    private GameObject laserPrefab;
    [SerializeField]
    private Transform[] posLaser;
    private AudioSource shoothAudio;
    [Header("HEALTH")]
    [SerializeField]
    private float maxHealth = 100;
    [SerializeField]
    private float currentHealth = 100;
    [SerializeField]
    private float damageBullet = 5;
    [SerializeField]
    private float healRing = 10;
    [SerializeField]
    private Image lifeBar;
    [SerializeField]
    private ParticleSystem bigExplosion,
                           zapExplosion;
    [SerializeField]
    private GameManager gameManager;
    [SerializeField]
    private AudioSource ringSound;


    private void Awake()
    {
        shoothAudio = GetComponent<AudioSource>();
        Cursor.lockState = CursorLockMode.Locked;
        currentHealth = maxHealth;
        lifeBar.fillAmount = 1;
        bigExplosion.Stop();
        zapExplosion.Stop();
    }
    private void Update()
    {
        Movement();
        Turning();
        Attack();
    }
    private void Movement()
    {
        float horizontal = Input.GetAxis("Horizontal"), 
                vertical = Input.GetAxis("Vertical");
        Vector3 direccion = new Vector3(horizontal, 0, vertical);
        transform.Translate(direccion.normalized * speed * Time.deltaTime);
        Debug.Log(Input.GetAxis("Vertical"));
    }

    private void Turning()
    {
        float xMouse = Input.GetAxis("Mouse X");
        float yMouse = Input.GetAxis("Mouse Y");
        Vector3 rotation = new Vector3(yMouse, xMouse, 0);
        transform.Rotate(rotation.normalized * turnSpeed * Time.deltaTime);
    }

    private void Attack()
    {
        if (Input.GetMouseButtonDown(0))    
        {
            shoothAudio.Play();
            for (int i = 0; i < posLaser.Length; i++)
            Instantiate(laserPrefab, posLaser[i].position, posLaser[i].rotation);
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BulletEnemy"))
        {
            currentHealth -= damageBullet;
            lifeBar.fillAmount = currentHealth / maxHealth;
            Destroy(other.gameObject);
            if(currentHealth <= 0)
            {
                Death();
            }
            zapExplosion.Play();
        }
        else if (other.CompareTag("Ring") && currentHealth < 100)
        {
            currentHealth += healRing;
            lifeBar.fillAmount = currentHealth / maxHealth;
            Destroy(other.gameObject);
            ringSound.Play();
        }
    }

    private void Death()
    {
        Camera.main.transform.SetParent(null);
        bigExplosion.Play();
        Destroy(gameObject, 1);
        gameManager.GameOver();
        
    }
}
