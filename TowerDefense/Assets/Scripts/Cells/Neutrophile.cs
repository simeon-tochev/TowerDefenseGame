using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Neutrophile : TargettingCell
{
    public int bacteriaDamage;
    public int otherDamage;

    public override void Upgrade1() {
        upgrade1Done = true;
        radius *= 1.25f;
    }

    public override void Upgrade2() {
        upgrade2Done = true;
        bacteriaDamage = (bacteriaDamage * 5) / 4;
        otherDamage = (otherDamage * 5) / 4;
    }

    protected override int DamageCalculation() {
        switch (target.type) {
            case 'b':
                return bacteriaDamage;
            default:
                return otherDamage;
        }
    }
}
