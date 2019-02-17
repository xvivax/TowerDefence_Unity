using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipPrice : MonoBehaviour {

    public enum Ships { ShipNumber01, ShipNumber02, ShipNumber03, ShipNumber04 };
    public Ships ships;

    private Text priceTag;

    private Shop shopScr;

    private void Start()
    {
        priceTag = GetComponent<Text>();
        shopScr = FindObjectOfType<Shop>();
        SelectShip();
    }

    void SelectShip()
    {
        switch (ships)
        {
            case Ships.ShipNumber01:
                priceTag.text = "$" + shopScr.ShipNumber01.cost;
                break;
            case Ships.ShipNumber02:
                priceTag.text = "$" + shopScr.ShipNumber02.cost;
                break;
            case Ships.ShipNumber03:
                priceTag.text = "$" + shopScr.ShipNumber03.cost;
                break;
            case Ships.ShipNumber04:
                priceTag.text = "$" + shopScr.ShipNumber04.cost;
                break;
            default:
                Debug.Log("Non Ship");
                break;
        }
    }
}
