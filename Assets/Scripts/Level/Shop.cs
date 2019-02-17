using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour {

    BuildManager buildManager;

    public ShipTemplate ShipNumber01;
    public ShipTemplate ShipNumber02;
    public ShipTemplate ShipNumber03;
    public ShipTemplate ShipNumber04;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void SelectShipNumber01()
    {
        buildManager.SelectShipToBuild(ShipNumber01);
    }

    public void SelectShipNumber02()
    {
        buildManager.SelectShipToBuild(ShipNumber02);
    }

    public void SelectShipNumber03()
    {
        buildManager.SelectShipToBuild(ShipNumber03);
    }

    public void SelectShipNumber04()
    {
        buildManager.SelectShipToBuild(ShipNumber04);
    }
}
