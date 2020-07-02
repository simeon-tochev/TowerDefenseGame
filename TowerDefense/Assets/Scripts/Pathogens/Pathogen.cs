using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathogen : MonoBehaviour {
    public bool slowed;
    public char type;

    public int reward;
    public int damage;
    public int health;
    public float speed;

    private AttackerHandler att;
    private Transform nextWayPoint;
    private Path path;
    private AudioSource audioSource;

    private int navigator = 0;

    // Public Methods

    public void Slow(float percentage, float time) {
        StartCoroutine(StartSlow(percentage, time));
    }

    public bool DealDamage(int dmg) {
        health -= dmg;
        return (health <= 0);
    }

    public void Kill() {
        att.GiveReward(reward);
        audioSource.Play();
        Die();
    }

    public void Die() {
        att.RemoveAttackerFromList(this);
        GameObject.Destroy(gameObject);
    }

    // Private Methods

    private void Navigate() {
        nextWayPoint = path.waypoints[navigator];
    }

    private void ReachWaypoint() {
        navigator++;
        Navigate();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        GameObject hit = other.gameObject;
        if (hit.tag == "Waypoint") {
            ReachWaypoint();
        }

        if (hit.tag == "Targeted Projectile") {
            Projectile p = hit.GetComponent<Projectile>();
            if (p.target == gameObject) {
                HitProjectile(p);
            }
        }

        if (hit.tag == "Projectile") {
            HitProjectile(hit.GetComponent<Projectile>());
        }

        if (hit.tag == "Target") {
            ReachEnd();
        }
    }

    private void ReachEnd() {
        att.DealDamage(damage);
        Die();
    }   

    protected void HitProjectile(Projectile p) {
        p.ApplyEffects(this);
    }

    private void Awake()
    {
        att = GameObject.Find("AttackerHandler").GetComponent<AttackerHandler>();
        audioSource = GameObject.Find("DeathSound").GetComponent<AudioSource>();
        path = att.path;
        nextWayPoint = path.waypoints[0];
    }

    private void LateUpdate()
    {
        if (health <= 0) {
            Kill();
        }
        transform.Translate(Vector3.Normalize(nextWayPoint.position - transform.position) * speed * Time.deltaTime);
    }

    // Coroutines

    private IEnumerator StartSlow(float percentage, float time) {
        slowed = true;
        speed *= percentage / 100f;
        yield return new WaitForSeconds(time);
        slowed = false;
        speed /= percentage / 100f;
        yield return null;
    }
}
