using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveHandler : MonoBehaviour
{
    public int level;
    public int remaining;
    public float spawnDelay;
    public int waveReward;

    public List<string> waves;
    public int currentWave;
    public bool waveStarted;
    public int numwaves;

    private AudioSource audioSource;

    private AttackerHandler attackerHandler;
    private PlayerHandler playerHandler;
    private GameSaveMono gameSaver;
    private SceneHandler sceneHandler;

    // Public Methods

    public void Setup(List<string> w, int n) {
        waves = w;
        numwaves = n;
    }

    public void StartWave() {
        if (!audioSource.isPlaying) {
            audioSource.Play();
        }
        waveStarted = true;
        attackerHandler.StartWave();
        StartCoroutine("SpawnEnemy", waves[currentWave]);
    }

    public void EndWave() {
        waveStarted = false;
        currentWave++;
        if (currentWave % 10 == 0) {
            spawnDelay *= 0.8f;
        }

        if (currentWave == numwaves) {
            sceneHandler.LoadScene(6);
        }

        remaining = waves[currentWave].Length;
        StopCoroutine("SpawnEnemy");
        Reward();
        gameSaver.Save();
    }

    public void LoadWave() {
        remaining = waves[currentWave].Length;
    }

    // Private Methods

    private void Reward() {
        playerHandler.AddMoney(waveReward + currentWave*10);
    }

    private void Start() {
        attackerHandler = GameObject.Find("AttackerHandler").GetComponent<AttackerHandler>();
        playerHandler = GameObject.Find("PlayerHandler").GetComponent<PlayerHandler>();
        gameSaver = GameObject.Find("GameSave").GetComponent<GameSaveMono>();
        sceneHandler = GameObject.Find("SceneHandler").GetComponent<SceneHandler>();
        audioSource = GameObject.Find("BackgroundSong").GetComponent<AudioSource>();
        LoadWave();
    }

    // Coroutines

    private IEnumerator SpawnEnemy(string wave) {
        for (int i = 0; i < wave.Length; i++) {
            attackerHandler.Spawn(wave[i]);
            remaining--;
            yield return new WaitForSeconds(spawnDelay);
        }
        yield return null;
    }

}
