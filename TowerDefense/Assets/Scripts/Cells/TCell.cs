using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TCell : TargettingCell {

    public int virusDamage;
    public int otherDamage;

    public override void Upgrade1() {
        upgrade1Done = true;
        radius *= 1.5f;
        RemoveCircle();
        CreateCircle();
    }

    public override void Upgrade2() {
        upgrade2Done = true;
        cooldown /= 2f;
    }

    protected override int DamageCalculation() {
        switch (target.type) {
            case 'v':
                return virusDamage;
            default:
                return otherDamage;
        }
    }
}
