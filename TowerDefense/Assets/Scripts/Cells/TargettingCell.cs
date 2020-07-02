using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TargettingCell : Cell
{
    public float radius;

    protected int segments = 20;

    protected Pathogen target;
    protected LineRenderer lr;

    // Public Methods

    public override void CreateCircle() {
        lr.positionCount = segments + 1;
        lr.useWorldSpace = false;

        float x;
        float y;
        float z = -1f;

        float angle = 20f;

        for (int i = 0; i < (segments + 1); i++) {
            x = Mathf.Sin(Mathf.Deg2Rad * angle) * radius / transform.localScale.x;
            y = Mathf.Cos(Mathf.Deg2Rad * angle) * radius / transform.localScale.y;

            lr.SetPosition(i, new Vector3(x, y, z));

            angle += (360f / segments);
        }
    }

    public override void RemoveCircle() {
        lr.positionCount = 0;
    }

    // Protected Methods

    protected virtual bool ValidTarget(Pathogen p) {
        return true;
    }

    protected void Awake() {
        lr = GetComponent<LineRenderer>();
    }

    protected void Target() {
        LinkedList<Pathogen> att = handler.attackers;
        LinkedListNode<Pathogen> curr = null;

        if (att.Count == 0) {
            return;
        }

        do {
            if (curr == null) { curr = att.First; }
            else { curr = curr.Next; }

            if (curr.Value == null) { continue; }

            if (Vector3.Distance(curr.Value.transform.position, transform.position) <= radius) {
                if (ValidTarget(curr.Value)) {
                    target = curr.Value;
                    return;
                }
            }

        } while (curr != att.Last);
    }

    protected override void SetStats(Projectile p) {
        p.damage = DamageCalculation();
        p.target = target.gameObject;
        p.sender = this;
        p.speed = projectileSpeed;
    }

    protected override void Shoot() {
        Target();
        if(target != null) {
            GameObject proj = GameObject.Instantiate(projectile, transform.position, transform.rotation);
            Projectile p = proj.GetComponent<Projectile>();
            SetStats(p);

            timer = 0;
            target = null;
        }
    }
}
