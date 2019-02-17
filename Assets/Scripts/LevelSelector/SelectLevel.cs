using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectLevel : MonoBehaviour {

    public string menuName = "Menu";

    public void GoToMenu()
    {
        SceneManager.LoadScene(menuName);
    }

    public Button[] buttons;

    private void Start()
    {
        int currentLevel = PlayerPrefs.GetInt("currentLevel", 1);

        for (int i = 0; i < buttons.Length; i++)
        {
            if (i + 1 > currentLevel)
            {
                buttons[i].interactable = false;
            }
        }
    }

    public void GoToLevel(string name)
    {
        SceneManager.LoadScene(name);
    }

}
