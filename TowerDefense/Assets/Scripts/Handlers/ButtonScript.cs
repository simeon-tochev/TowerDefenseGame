using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour {
    public static bool placing;

    public GameObject cell;
    public int upgradeNumber;

    private int cost;

    private Cell cellScript;
    private Button button;
    private Text infoText;

    private PlayerHandler playerHandler;
    private UpgradeHandler upgradeHandler;

    // Public Methods

    public void BuyCell() {
        GameObject g = Instantiate(cell, transform.position, transform.rotation);
        Cell boughtCell = g.GetComponent<Cell>();
        boughtCell.placing = true;
        boughtCell.placeable = true;
        boughtCell.CreateCircle();
        playerHandler.AddMoney(-cost);
        placing = true;
    }

    public void OnHover() {
        if (cell == null) {
            switch (upgradeNumber) {
                case 1: infoText.text = upgradeHandler.inflammationUpgradeinfo; break;
                case 2: infoText.text = upgradeHandler.vaccineUpgradeInfo; break;
                case 3: infoText.text = upgradeHandler.antibioticUpgradeInfo; break;
            }
            return;
        }
        infoText.text = cellScript.info;
    }

    public void OnExit() {
        infoText.text = "";
    }

    // Private Methods

    private void OnClick() {
        if (cell == null) {
            switch (upgradeNumber) {
                case 1: upgradeHandler.InflammationUpgrade(); break;
                case 2: upgradeHandler.VaccineUpgrade(); break;
                case 3: upgradeHandler.AntibioticUpgrade(); break;
            }
            return;
        }
        BuyCell();
    }

    private void Start() {
        upgradeHandler = GameObject.Find("UpgradeHandler").GetComponent<UpgradeHandler>();
        infoText = GameObject.Find("InfoText").GetComponent<Text>();
        playerHandler = GameObject.Find("PlayerHandler").GetComponent<PlayerHandler>();
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);
        if (cell == null) { return; }
        cellScript = cell.GetComponent<Cell>();
    }

    private void Update() {
        if (cell == null) {
            switch (upgradeNumber) {
                case 1: cost = upgradeHandler.inflammationUpgradeCost; break;
                case 2: cost = upgradeHandler.vaccineUpgradeCost; break;
                case 3: cost = upgradeHandler.antibioticUpgradeCost; break;
            }
        } else {
            cost = cellScript.cost;
        }
        button.interactable = cost <= playerHandler.money && placing == false ;
        GetComponentInChildren<Text>().text = cost.ToString();
    }
}
