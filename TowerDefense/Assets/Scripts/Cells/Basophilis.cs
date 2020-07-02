using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basophilis : TargettingCell
{
    protected override int DamageCalculation() { return 0; }

    public float slowTime;
    public float slowPercentage;

    public override void Upgrade1() {
        upgrade1Done = true;
        slowTime *= 1.5f;
    }

    public override void Upgrade2() {
        upgrade2Done = true;
        slowPercentage /= 1.5f;
    }

    protected override void SetStats(Projectile p) {
        base.SetStats(p);
        SlowingProjectile sp = (SlowingProjectile) p;
        sp.slowPercentage = slowPercentage;
        sp.slowTime = slowTime;
        
    }

    protected override bool ValidTarget(Pathogen p) {
        return !p.slowed;
    }
}
