using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameSave
{
    public GameSave(PlayerHandler ph, WaveHandler wh) {
        level = wh.level;

        waveNumber = wh.currentWave;
        spawnDelay = wh.spawnDelay;

        money = ph.money;
        health = ph.health;

        cells = new CellWrapper[ph.cells.Count];

        for (int i = 0; i < ph.cells.Count; i++) {
            cells[i] = new CellWrapper(ph.cells[i]);
        }
    }

    // Level
    public int level;

    // Wave Stats
    public int waveNumber;
    public float spawnDelay;

    // Player Stats
    public int money;
    public int health;

    // Cells
    public CellWrapper[] cells;
}
