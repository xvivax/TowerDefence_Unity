using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour {

    public static BuildManager instance;

    public GameObject upgradePanel;
    // TODO  Why is it public?
    public UpgradeSell upgradesell;

    private ShipTemplate targetToBuild;
    private Tile selectedTile;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        DeselectTile();
    }

    public void SelectShipToBuild(ShipTemplate template)
    {
        DeselectTile();

        targetToBuild = template;
        Tile.iSActive = true;
    }

    public ShipTemplate GetShipToBuild()
    {
        return targetToBuild;
    }

    public int GetCost()
    {
        return targetToBuild.cost;
    }

    public void SelectTile(Tile _tile)
    {

        DeselectTile();

        selectedTile = _tile;
        selectedTile.GetComponent<Renderer>().material.color = Color.yellow;
        upgradePanel.SetActive(true);

        upgradesell.PassTarget(selectedTile);
    }

    public void DeselectTile()
    {
        targetToBuild = null;
        upgradePanel.SetActive(false);
        Tile.iSActive = false;

        if (selectedTile)
        {
            selectedTile.TileIsSelected = false;
            selectedTile.GetComponent<Renderer>().material.color = selectedTile.GetStartColor();
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            DeselectTile();
        }
    }

}
