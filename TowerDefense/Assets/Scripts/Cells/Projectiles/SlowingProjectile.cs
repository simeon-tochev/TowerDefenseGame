using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowingProjectile : Projectile
{
    public float slowTime;
    public float slowPercentage;

    public override void ApplyEffects(Pathogen p) {
        p.Slow(slowPercentage, slowTime);
        sender.IncrementKillCount();
        audioSource.Play();
        Destroy(gameObject);
    }

    protected override void FindAudio() {
        audioSource = GameObject.Find("SlowSound").GetComponent<AudioSource>();
    }
}
