using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevel : MonoBehaviour {

    public static NextLevel NLinstance;

    private void Awake()
    {
        NLinstance = this;
    }

    public string levelToGo = "Level02";
    public int LevelUnlock = 2;

}
