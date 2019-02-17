using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMenu : MonoBehaviour {

    public string LevelSelector = "LevelSelector";

    public void GoToLevelSelector()
    {
        SceneManager.LoadScene(LevelSelector);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ResetGame()
    {
        PlayerPrefs.DeleteAll();
    }

}
