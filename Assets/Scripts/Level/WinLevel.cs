using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinLevel : MonoBehaviour {

    private NextLevel nextLevel;

    public string menuName = "Menu";

    private void Start()
    {
        nextLevel = NextLevel.NLinstance;
        PlayerPrefs.SetInt("currentLevel", nextLevel.LevelUnlock);
    }

    public void GoToNextLevel()
    {
        SceneManager.LoadScene(nextLevel.levelToGo);
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene(menuName);
    }
}
