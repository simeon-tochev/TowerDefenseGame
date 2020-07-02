using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
    public Cell sender;
    public GameObject target;
    public int damage;

    public float speed;

    private Rigidbody2D rb;

    protected AudioSource audioSource;

    public virtual void ApplyEffects(Pathogen p) {
        if (p.DealDamage(damage)) {
            sender.IncrementKillCount();
        }
        sender.IncrementDamageCount(damage);
        audioSource.Play();
        Destroy(gameObject);
    }

    public void TargetKilled() {
        sender.killCount++;
    }

    public void SetDirection(Vector3 d) {
        rb.velocity = Vector3.Normalize(d) * speed;
    }

    public void FindRigidBody() {
        rb = GetComponent<Rigidbody2D>();
    }

    protected virtual void FindAudio() {
        audioSource = GameObject.Find("ProjectileSound").GetComponent<AudioSource>();
    }

    protected void Start() {
        FindAudio();
        FindRigidBody();
    }

    protected void Update()
    {
        if (target == null && tag == "Targeted Projectile") {
            tag = "Projectile";
        }

        if (target != null && tag == "Targeted Projectile") {
            rb.velocity = ((Vector3.Normalize(target.transform.position - transform.position)) * speed);
        }

        if (!sender.handler.waveStarted) {
            Destroy(gameObject);
        }
    }
}
