using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Cell : MonoBehaviour {
    public bool placing;

    public int killCount;
    public int damageDone;
    public int cost;

    public new string name;
    public char type;

    public string upgrade1;
    public string upgrade2;

    public bool upgrade1Done;
    public bool upgrade2Done;

    public int upgrade1Cost;
    public int upgrade2Cost;

    public string info;

    public GameObject circlePrefab;
    public GameObject circle;

    public GameObject projectile;

    public float cooldown;
    public float projectileSpeed;

    public abstract void Upgrade1();
    public abstract void Upgrade2();

    public bool placeable;

    public AttackerHandler handler;

    protected float timer;

    protected SpriteRenderer map;

    protected PlayerHandler player;
    protected UIHandler ui;

    public abstract void CreateCircle();
    public abstract void RemoveCircle();

    protected abstract void Shoot();
    protected abstract int DamageCalculation();

    // Public Methods

    public void IncrementKillCount() {
        killCount++;
    }

    public void IncrementDamageCount(int dmg) {
        damageDone += dmg;
    }

    // Protected Methods

    protected void OnMouseDown() {
        if (placing) {
            Place();
            return;
        }
        ui.SelectCell(this);
    }

    protected void Place() {
        if (!placeable) {
            return;
        }
        placing = false;
        ButtonScript.placing = false;
        RemoveCircle();
        player.AddCell(this);
    }

    public void SellTower() {
        player.AddMoney(cost / 2);
        player.RemoveCell(this);
        Destroy(gameObject);
    }

    protected abstract void SetStats(Projectile p);

    protected void OnTriggerStay2D(Collider2D col) {
        if (col.gameObject.tag == "Cell" || col.gameObject.tag == "Road") {
            placeable = false;
        }
    }

    protected void OnTriggerExit2D(Collider2D col) {
        if (col.gameObject.tag == "Cell" || col.gameObject.tag == "Road") {
            placeable = true;
        }
    }

    protected void Start() {
        handler = GameObject.Find("AttackerHandler").GetComponent<AttackerHandler>();
        ui = GameObject.Find("UIHandler").GetComponent<UIHandler>();
        player = GameObject.Find("PlayerHandler").GetComponent<PlayerHandler>();
        map = GameObject.Find("Map").GetComponent<SpriteRenderer>();
        timer = cooldown;
    }

    protected void Update() {
        if (placing) {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(
                Mathf.Clamp(mousePos.x, map.bounds.center.x - map.bounds.extents.x,  map.bounds.center.x + map.bounds.extents.x),
                Mathf.Clamp(mousePos.y, map.bounds.center.y - map.bounds.extents.y, map.bounds.center.y + map.bounds.extents.y), 
                1);
        } else {
            if (handler.waveStarted) {
                timer += Time.deltaTime;
                if (timer >= cooldown) {
                    Shoot();
                }
            }
        }

        if( placing && !placeable) {
            GetComponent<SpriteRenderer>().color = Color.red;
        } else {
            GetComponent<SpriteRenderer>().color = Color.white;
        }
    }
}

