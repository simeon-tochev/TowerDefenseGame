using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Level : MonoBehaviour
{
    protected List<string> waves;
    protected abstract void WaveSetup();
    protected int numWaves;

    protected WaveHandler waveHandler;

    protected void Start() {
        waveHandler = GameObject.Find("WaveHandler").GetComponent<WaveHandler>();
        WaveSetup();
    }

}
