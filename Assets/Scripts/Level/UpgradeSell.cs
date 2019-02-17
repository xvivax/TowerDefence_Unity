using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeSell : MonoBehaviour {

    public Text sellCost;
    public SellPopUp sellPopup;
    public Text upgradeCost;
    public Button upgradeButton;

    private Tile target;

    public void PassTarget(Tile _tile)
    {
        target = _tile;

        sellCost.text = "$" + target.ShipTempl.sellCost;
        sellPopup.GetComponent<Text>().text = "$" + target.ShipTempl.sellCost;

        if (!target.isUpgraded)
        {
            upgradeCost.text = "$" + target.ShipTempl.upgradeCost;
            upgradeButton.interactable = true;
        }
        else
        {
            upgradeCost.text = "MAX";
            sellCost.text = "$" + target.ShipTempl.upgradeSellCost;
            upgradeButton.interactable = false;
        }

    }

    public void Sell()
    {
        target.SellShip();
    }

    public void Upgrade1()
    {
        target.UpgradeShip();
    }

}
