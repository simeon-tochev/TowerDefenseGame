using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour {
    private GameObject nextWaveButton;
    private GameObject cellInfoPanel;

    private Text cellName;
    private Text killCount;
    private Text damageCount;
    
    private Text upgrade1Text;
    private Text upgrade2Text;
    private Text sellButtonText;
    
    private Button upgrade1;
    private Button upgrade2;
    private Button sellButton;
    
    private Text moneyText;
    private Text healthText;
    private Text waveText;
    private Text countText;
    
    private Cell currentCell;

    private PlayerHandler playerHandler;
    private AttackerHandler attackerHandler;
    private WaveHandler waveHandler;

    // Public Methods

    public void SelectCell(Cell c) {
        if(currentCell != null) {
            currentCell.RemoveCircle();
        }
        currentCell = c;
        cellInfoPanel.SetActive(true);
        currentCell.CreateCircle();
    }

    public void DeselectCell() {
        currentCell.RemoveCircle();
        currentCell = null;
    }

    public void DoUpgrade1() {
        playerHandler.AddMoney(-currentCell.upgrade1Cost);
        currentCell.Upgrade1();
        currentCell.RemoveCircle();
        currentCell.CreateCircle();
    }

    public void DoUpgrade2() {
        playerHandler.AddMoney(-currentCell.upgrade2Cost);
        currentCell.Upgrade2();
        currentCell.RemoveCircle();
        currentCell.CreateCircle();
    }

    public void Sell() {
        currentCell.SellTower();
    }

    public void StartWave() {
        waveHandler.StartWave();
    }

    // Private Methods

    private void UpdateBottomPanel() {
        cellName.text = currentCell.name;
        if (currentCell.type == 'b') {
            killCount.text = ("Pathogens slowed: " + currentCell.killCount.ToString());
        }
        else {
            killCount.text = ("Pathogens killed: " + currentCell.killCount.ToString());
        }
        damageCount.text = ("Damage done: " + currentCell.damageDone.ToString());

        if (!currentCell.upgrade1Done) {
            upgrade1.interactable = playerHandler.money >= currentCell.upgrade1Cost;
            upgrade1Text.text = currentCell.upgrade1 + ": " + currentCell.upgrade1Cost.ToString();
        }
        else {
            upgrade1.interactable = false;
            upgrade1Text.text = currentCell.upgrade1 + " Bought!";
        }

        if (!currentCell.upgrade2Done) {
            upgrade2.interactable = playerHandler.money >= currentCell.upgrade2Cost;
            upgrade2Text.text = currentCell.upgrade2 + ": " + currentCell.upgrade2Cost.ToString();
        }
        else {
            upgrade2.interactable = false;
            upgrade2Text.text = currentCell.upgrade2 + " Bought!";
        }

        sellButtonText.text = "Sell: " + (currentCell.cost / 2).ToString();
    }

    private void Awake()
    {
        playerHandler = GameObject.Find("PlayerHandler").GetComponent<PlayerHandler>();
        attackerHandler = GameObject.Find("AttackerHandler").GetComponent<AttackerHandler>();
        waveHandler = GameObject.Find("WaveHandler").GetComponent<WaveHandler>();

        moneyText = GameObject.Find("MoneyText").GetComponent<Text>();
        healthText = GameObject.Find("HealthText").GetComponent<Text>();
        waveText = GameObject.Find("WaveText").GetComponent<Text>();
        countText = GameObject.Find("PathogenText").GetComponent<Text>();

        cellInfoPanel = GameObject.Find("CellInfo");

        upgrade1Text = GameObject.Find("Upgrade1Text").GetComponent<Text>();
        upgrade2Text = GameObject.Find("Upgrade2Text").GetComponent<Text>();
        sellButtonText = GameObject.Find("SellButtonText").GetComponent<Text>();

        upgrade1 = GameObject.Find("Upgrade1").GetComponent<Button>();
        upgrade2 = GameObject.Find("Upgrade2").GetComponent<Button>();
        sellButton = GameObject.Find("SellButton").GetComponent<Button>();

        cellName = GameObject.Find("CellName").GetComponent<Text>();
        killCount = GameObject.Find("KillCount").GetComponent<Text>();
        damageCount = GameObject.Find("DamageCount").GetComponent<Text>();

        nextWaveButton = GameObject.Find("WaveNumber");
    }

    private void Update()
    {
        if(currentCell == null) {
            cellInfoPanel.SetActive(false);
        } else {
            if (cellInfoPanel.activeSelf) {
                UpdateBottomPanel();
            }
        }
        moneyText.text = "DNA\n" + playerHandler.money.ToString();
        healthText.text = "Health\n" + playerHandler.health.ToString();
        waveText.text = "Wave\n" + (waveHandler.currentWave + 1).ToString();
        countText.text = "Remaining\n" + (attackerHandler.attackers.Count + waveHandler.remaining).ToString();

        if (!waveHandler.waveStarted) {
            nextWaveButton.GetComponent<Button>().interactable = true;
            nextWaveButton.GetComponentInChildren<Text>().text += "\nStart Wave";
        } else {
            nextWaveButton.GetComponent<Button>().interactable = false;
        }
    }
}
