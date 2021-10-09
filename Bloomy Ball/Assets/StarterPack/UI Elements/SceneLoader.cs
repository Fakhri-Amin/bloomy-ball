using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] Animator transition;
    [SerializeField] float transitionTime = 1f;
    [SerializeField] AudioClip clickSound;

    private void Start()
    {
        if (!transition) return;
    }

    public void MainMenu()
    {
        Time.timeScale = 1f;
        PlayClickSound();
        SceneManager.LoadScene("Main Menu");
    }

    public void LoadNextScene()
    {
        Time.timeScale = 1f;
        PlayClickSound();
        StartCoroutine(LoadScene(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadScene(int levelIndex)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelIndex);
    }

    public void LoadPreviousScene()
    {
        Time.timeScale = 1f;
        PlayClickSound();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        PlayClickSound();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
        PlayClickSound();
        Application.Quit();
    }

    public void PlayClickSound()
    {
        GetComponent<AudioSource>().PlayOneShot(clickSound);
    }
}
