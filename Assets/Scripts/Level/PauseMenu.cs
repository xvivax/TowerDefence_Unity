using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public string menuName = "Menu";

    private void OnEnable()
    {
        TogglePause();
    }
    private void OnDisable()
    {
        TogglePause();
    }

    public void TogglePause()
    {
        if (gameObject.activeSelf)
        {
            Time.timeScale = 0;
            GameManager.isGamePaused = true;
        }
        else
        {
            Time.timeScale = 1;
            GameManager.isGamePaused = false;
        }
    }

    public void ResumeGame()
    {
        TogglePause();
        gameObject.SetActive(false);
    }

    public void RetryGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene(menuName);
    }

}
