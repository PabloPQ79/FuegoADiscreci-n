using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject panelGameOver;
    [SerializeField]
    private EnemySpawner enemyManager;
    [SerializeField]
    private AudioSource shootAudio;
    [SerializeField]
    private AudioSource shootLaugh;

    public void GameOver()
    {
        panelGameOver.SetActive(true);
        enemyManager.enabled = false;
        Cursor.lockState = CursorLockMode.Confined;
        shootAudio.Stop();
        shootLaugh.Play();
    }

    public void _LoadSceneLevel()
    {
        SceneManager.LoadScene("MetalSonic01");
    }
}
