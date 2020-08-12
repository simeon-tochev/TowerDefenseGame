using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandler : MonoBehaviour
{
    public List<Cell> cells;

    public int health;
    public int money;

    private SceneHandler sceneHandler;

    public bool godMode;

    // Public Methods

    public void AddCell(Cell c) {
        cells.Add(c);
    }

    public void RemoveCell(Cell c) {
        cells.Remove(c);
    }

    public void AddMoney(int m) {
        money += m;
    }

    public void AddHealth(int h) {
        health += h;
    }

    public void DealDamage(int d) {
        AddHealth(-d);
    }

    // Private Methods

    private void Start()
    {
        sceneHandler = GameObject.Find("SceneHandler").GetComponent<SceneHandler>();
    }

    private void Update()
    {
        if (godMode) {
            money = 99999;
            health = 9999;
        }

        if(health <= 0) {
            sceneHandler.LoadScene(5);
        }

    }
}
