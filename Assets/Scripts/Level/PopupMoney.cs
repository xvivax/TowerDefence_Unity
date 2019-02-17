using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupMoney : MonoBehaviour {

    private Text popUpMoneyText;
    private Spawner spawner;

    private void Start()
    {
        popUpMoneyText = GetComponent<Text>();
        spawner = FindObjectOfType<Spawner>();
        popUpMoneyText.text = "$" + spawner.GetEnemyWorth();
    }

}
