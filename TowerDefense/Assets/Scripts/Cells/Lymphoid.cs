using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lymphoid : Cell {

    public int damage;

    public override void CreateCircle() {}
    public override void RemoveCircle() { }

    public override void Upgrade1() {
        upgrade1Done = true;
    }

    public override void Upgrade2() {
        upgrade2Done = true;
        cooldown /= 1.5f;
    }

    protected override int DamageCalculation() {
        return damage ;
    }

    protected override void Shoot() {
        if (!upgrade1Done) {
            ShootAtDirection(0);
            ShootAtDirection(Mathf.PI / 3);
            ShootAtDirection(2 * Mathf.PI / 3);
            ShootAtDirection(Mathf.PI);
            ShootAtDirection(4 * Mathf.PI / 3);
            ShootAtDirection(5 * Mathf.PI / 3);
        }
        else {
            ShootAtDirection(0);
            ShootAtDirection(Mathf.PI / 5);
            ShootAtDirection(2 * Mathf.PI / 5);
            ShootAtDirection(3 * Mathf.PI / 5);
            ShootAtDirection(4 * Mathf.PI / 5);
            ShootAtDirection(Mathf.PI);
            ShootAtDirection(6 * Mathf.PI / 5);
            ShootAtDirection(7 * Mathf.PI / 5);
            ShootAtDirection(8 * Mathf.PI / 5);
            ShootAtDirection(9 * Mathf.PI / 5);
        }
        timer = 0;
    }

    protected override void SetStats(Projectile p) {
        p.FindRigidBody();
        p.sender = this;
        p.speed = projectileSpeed;
        p.damage = DamageCalculation();
    }

    private void ShootAtDirection(float rad) {
        GameObject pGO = GameObject.Instantiate(projectile, transform.position, transform.rotation);
        Projectile p = pGO.GetComponent<Projectile>();
        SetStats(p);
        Vector3 direction = new Vector3(Mathf.Cos(rad), Mathf.Sin(rad), 0);
        p.SetDirection(direction);
    }
}
