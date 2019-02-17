using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tile : MonoBehaviour
{
    public static bool iSActive = false;

    private BuildManager buildManager;

    // Tile doesn't have any buildings on it
    private bool isEmpty = true;

    private Renderer rend;
    private Color startColor;

    private Vector3 offset = new Vector3(0, 1.8f, 0);

    private GameObject currentShip;
    [HideInInspector]
    public ShipTemplate ShipTempl;
    [HideInInspector]
    public bool isUpgraded = false;

    public GameObject sellPopUpPref;


    private bool tileIsSelected = false;
    public bool TileIsSelected
    {
        get
        {
            return tileIsSelected;
        }

        set
        {
            tileIsSelected = value;
        }
    }

    private void Start()
    {
        buildManager = BuildManager.instance;

        rend = GetComponent<Renderer>();
        startColor = rend.material.color;        
    }

    public Color GetStartColor()
    {
        return startColor;
    }

    void OnMouseEnter()
    {
        if (iSActive)
        {
            if (!isEmpty)
            {
                rend.material.color = Color.blue;
            }
            else
            {
                rend.material.color = Color.black;
            }
        }
    }

    void OnMouseExit()
    {
        if (tileIsSelected)
        {
            return;
        }

        rend.material.color = startColor;
    }


    private void OnMouseDown()
    {
        if (GameManager.isGamePaused)
        {
            return;
        }

        if (!isEmpty)
        {
            buildManager.SelectTile(this);
            tileIsSelected = true;
            return;
        }

        if (iSActive == false)
        {
            return;
        }


        if (Stats.money < buildManager.GetCost())
        {
            Debug.Log("Not enough money to buy this building");
            return;
        }

        BuildShip(buildManager.GetShipToBuild());

        isEmpty = false;
        rend.material.color = Color.blue;

    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            rend.material.color = startColor;
        }
    }

    void BuildShip(ShipTemplate template)
    {
        currentShip = Instantiate(template.ship, transform.position, Quaternion.identity);

        Stats.money -= template.cost;

        ShipTempl = template;
    }

    public void UpgradeShip()
    {
        if (Stats.money < ShipTempl.upgradeCost)
        {
            Debug.Log("Not enough money for the upgrade");
            return;
        }

        Stats.money -= ShipTempl.upgradeCost;

        //Old Ship
        Destroy(currentShip);

        //Upgraded Ship
        currentShip = Instantiate(ShipTempl.upgradedShip, transform.position, Quaternion.identity);

        ShipTempl.sellCost = ShipTempl.upgradeSellCost;

        isUpgraded = true;
        buildManager.DeselectTile();
    }

    public void SellShip()
    {
        Stats.money += ShipTempl.sellCost;

        //Old Ship
        Destroy(currentShip);

        GameObject temp = Instantiate(sellPopUpPref, transform.position + offset, Quaternion.identity);
        Destroy(temp, 1f);

        isEmpty = true;
        buildManager.DeselectTile();
    }
}
