using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerHandler : MonoBehaviour
{
    public GameObject escherichiaColi;
    public GameObject tuberculosis;
    public GameObject influenza;
    public GameObject coronavirus;
    public GameObject tetanus;
    public GameObject malaria;
    public GameObject plague;
    public GameObject ebola;

    public Path path;
    public LinkedList<Pathogen> attackers;

    public PlayerHandler player;
 
    public bool waveStarted;

    private WaveHandler waveHandler;

    // Public Methods

    public void KillAttacker(Pathogen p) {
        p.Die();
    }
    
    public void AddAttackersToList(Pathogen p) {
        if(p == null) {
            return;
        }
        if(attackers.Count == 0) {
            attackers.AddFirst(p);
        } else {
            attackers.AddLast(p);
        }
    }

    public void RemoveAttackerFromList(Pathogen p) {
        attackers.Remove(p);
        if (attackers.Count == 0 && waveHandler.remaining == 0) {
            EndWave();
        }
    }

    public void DealDamage(int damage) {
        player.DealDamage(damage);
    }

    public void StartWave() {
        waveStarted = true;

     ///   GetComponent<AudioSource>().Play();
    }

    public void EndWave() {
        waveHandler.EndWave();
        waveStarted = false;

     ///   GetComponent<AudioSource>().Stop();
    }

    public void GiveReward(int r) {
        player.AddMoney(r);
    }

    public void Spawn(char c) {
        GameObject g = null;
        switch (c) {
            case 'e':
                g = GameObject.Instantiate(escherichiaColi, path.startPoint.position, transform.rotation);
                if(g == null) { print("Prankd"); }
                break;
            case 't':
                g = GameObject.Instantiate(tuberculosis, path.startPoint.position, transform.rotation);
                break;
            case 'i':
                g = GameObject.Instantiate(influenza, path.startPoint.position, transform.rotation);
                break;
            case 'c':
                g = GameObject.Instantiate(coronavirus, path.startPoint.position, transform.rotation);
                break;
            case 'm':
                g = GameObject.Instantiate(malaria, path.startPoint.position, transform.rotation);
                break;
            case 'n':
                g = GameObject.Instantiate(tetanus, path.startPoint.position, transform.rotation);
                break;
            case 'p':
                g = GameObject.Instantiate(plague, path.startPoint.position, transform.rotation);
                break;
            case 'b':
                g = GameObject.Instantiate(ebola, path.startPoint.position, transform.rotation);
                break;
            default: return;
        }
        Pathogen p = g.GetComponent<Pathogen>();
        attackers.AddLast(p);
    }

    // Private Methods

    private void Start()
    {
        attackers = new LinkedList<Pathogen>();
        waveHandler = GameObject.Find("WaveHandler").GetComponent<WaveHandler>();
        player = GameObject.Find("PlayerHandler").GetComponent<PlayerHandler>();
        path = GameObject.Find("Path").GetComponent<Path>();
    }
}
