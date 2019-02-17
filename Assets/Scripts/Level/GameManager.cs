using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public static GameManager GInstance;

    public static bool isGamePaused;

    public GameObject gameOverUI;
    public GameObject winLevelUI;
    public GameObject pauseMenuUI;
 
    private bool error;

    private void Awake()
    {
        GInstance = this;
    }

    void Start () {

        error = false;
        isGamePaused = false;
    }

	void Update ()
    {
        if (error)
        {
            return;
        }

        if (Stats.lives <= 0)
        {
            GameOver();
        }

        if (Spawner.isLevelEnd)
        {
            WinLevel();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!pauseMenuUI.activeSelf)
            {
                pauseMenuUI.SetActive(true);
            }
            else
            {
                pauseMenuUI.SetActive(false);
            }
        }
    }

    void GameOver()
    {
        gameOverUI.SetActive(true);
        error = true;
        return;
    }

    void WinLevel()
    {
        winLevelUI.SetActive(true);
        error = true;
        return;
    }
}