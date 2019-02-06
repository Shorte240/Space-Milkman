using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class KillPlayer : LevelLoader
{
    public LevelManager levelManager;
    public LevelLoader currentLevel;

    // Use this for initialization
    void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            //levelManager.RespawnPlayer();
            SceneManager.LoadScene(levelToLoad);
        }
    }
}
