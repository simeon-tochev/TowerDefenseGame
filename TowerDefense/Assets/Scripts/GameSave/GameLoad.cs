using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class GameLoad : MonoBehaviour
{
    public List<GameObject> cellPrefabs;

    private string destination;

    private GameSave loadedSave;

    private WaveHandler waveHandler;
    private PlayerHandler playerHandler;
    private SceneHandler sceneHandler;

    public void LoadFile() {

        FileStream file;

        if (File.Exists(destination)) file = File.OpenRead(destination);
        else {
            print("File not found");
            return;
        }

        BinaryFormatter bf = new BinaryFormatter();
        loadedSave = (GameSave)bf.Deserialize(file);
        file.Close();
        StartCoroutine("LoadGame");
    }

    private void Start() {
        sceneHandler = GameObject.Find("SceneHandler").GetComponent<SceneHandler>();
        destination = Application.dataPath + "/save.dat";
    }

    IEnumerator LoadGame() {
        DontDestroyOnLoad(gameObject);
        sceneHandler.LoadScene(1 + loadedSave.level);

        while (waveHandler == null || playerHandler == null) {
            yield return new WaitForSeconds(0.5f);
            waveHandler = GameObject.Find("WaveHandler").GetComponent<WaveHandler>();
            playerHandler = GameObject.Find("PlayerHandler").GetComponent<PlayerHandler>();
        }

        waveHandler.currentWave = loadedSave.waveNumber;
        waveHandler.spawnDelay = loadedSave.spawnDelay;
        waveHandler.LoadWave();

        playerHandler.money = loadedSave.money;
        playerHandler.health = loadedSave.health;

        foreach (CellWrapper cell in loadedSave.cells) {
            float posX = cell.posX;
            float posY = cell.posY;
            GameObject g = null;
            switch (cell.type) {
                case 'n':
                    g = Instantiate(cellPrefabs[0], new Vector3(posX, posY, 1), transform.rotation);
                    break;
                case 'm':
                    g = Instantiate(cellPrefabs[1], new Vector3(posX, posY, 1), transform.rotation);
                    break;
                case 'l':
                    g = Instantiate(cellPrefabs[2], new Vector3(posX, posY, 1), transform.rotation);
                    break;
                case 'b':
                    g = Instantiate(cellPrefabs[3], new Vector3(posX, posY, 1), transform.rotation);
                    break;
                case 't':
                    g = Instantiate(cellPrefabs[4], new Vector3(posX, posY, 1), transform.rotation);
                    break;
            }
            Cell cellScript = g.GetComponent<Cell>();
            if (cell.upgrade1) {
                cellScript.Upgrade1();
            }
            if (cell.upgrade2) {
                cellScript.Upgrade2();
            }
            cellScript.killCount = cell.killCount;
            cellScript.damageDone = cell.dmgCount;
            playerHandler.AddCell(cellScript);
        }

        Destroy(gameObject);
        yield return null;
    }
}
