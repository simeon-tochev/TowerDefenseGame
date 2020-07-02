using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Macrophag : TargettingCell
{
    public int damage;

    public override void Upgrade1() {
        upgrade1Done = true;
        damage = (damage*3) / 2;
    }

    public override void Upgrade2() {
        upgrade2Done = true;
        cooldown /= 1.5f;
    }

    protected override int DamageCalculation() {
        return damage;
    }

    protected override bool ValidTarget(Pathogen p) {
        return true;
    }
}
