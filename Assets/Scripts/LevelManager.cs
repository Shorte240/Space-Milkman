using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public Transform mainMenu;
    public GameObject spawnPoint;
    private PlayerController player;
    public int pointPenaltyOnDeath;

    void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }

    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void RespawnPlayer()
    {
        player.transform.position = spawnPoint.transform.position;
        ScoreManager.AddPoints(-pointPenaltyOnDeath);
    }
}
