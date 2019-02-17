using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveText : MonoBehaviour {

    private Text waveText;

	// Use this for initialization
	void Start () {
        waveText = GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Stats.wave <= 0)
        {
            waveText.text = "Wave 1";
        }
        else
        {
            waveText.text = "Wave " + Stats.wave;
        }
	}
}
