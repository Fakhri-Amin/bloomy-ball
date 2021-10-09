using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    Enemy[] enemies;

    void Update()
    {
        int numEnemies = FindObjectsOfType<Enemy>().Length;
        if (numEnemies <= 0)
        {
            Invoke("LoadNextScene", 1f);
        }
    }

    void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
