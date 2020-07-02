using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class GameSaveMono : MonoBehaviour
{
    private string destination;

    private GameSave currentSave;

    private PlayerHandler playerHandler;
    private WaveHandler waveHanler;

    public void Save() {
        currentSave = new GameSave(playerHandler, waveHanler);

        FileStream file;

        if (File.Exists(destination)) { file = File.OpenWrite(destination); }
        else { file = File.Create(destination); }

        BinaryFormatter bf = new BinaryFormatter();
        bf.Serialize(file, currentSave);
        file.Close();
    }

    private void Start()
    {
        playerHandler = GameObject.Find("PlayerHandler").GetComponent<PlayerHandler>();
        waveHanler = GameObject.Find("WaveHandler").GetComponent<WaveHandler>();
        destination = Application.dataPath + "/save.dat";
    }
}
