using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeHandler : MonoBehaviour
{
    public int inflammationUpgradeCost;
    public int vaccineUpgradeCost;
    public int antibioticUpgradeCost;

    public string inflammationUpgradeinfo;
    public string vaccineUpgradeInfo;
    public string antibioticUpgradeInfo;

    private AttackerHandler attackerHandler;
    private PlayerHandler playerHandler;

    // Public Methods

    public void InflammationUpgrade() {
        playerHandler.AddMoney(-inflammationUpgradeCost);
        foreach (Pathogen p in attackerHandler.attackers) {
            p.Slow(40, 10);
        }
    }

    public void VaccineUpgrade() {
        playerHandler.AddMoney(-vaccineUpgradeCost);
        foreach (Pathogen p in attackerHandler.attackers) {
            if (p.type == 'v') {
                p.Slow(1, 8);
            }
        }
    }

    public void AntibioticUpgrade() {
        playerHandler.AddMoney(-antibioticUpgradeCost);

        LinkedListNode<Pathogen> p = attackerHandler.attackers.First; 
        while(p != null) {
            Pathogen pn = p.Value;
            if(pn.type == 'b') {
                p = p.Next;
                pn.Die();
            } else {
                p = p.Next;
            }
        }
    }

    // Private Methods

    private void Start() {
        attackerHandler = GameObject.Find("AttackerHandler").GetComponent<AttackerHandler>();
        playerHandler = GameObject.Find("PlayerHandler").GetComponent<PlayerHandler>();
    }

}
