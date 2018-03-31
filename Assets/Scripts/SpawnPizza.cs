using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class Wave
{
    public GameObject pizzaPrefab;
    public float spawnInterval = 1;
    public int maxPizzas = 20;
}
public class SpawnPizza : MonoBehaviour {
    public Wave[] waves;
    public int timeBetweenWaves = 5;
    public GameObject[] waypoints;
    private int enemiesSpawned = 0;
    private float lastSpawnTime;

    void Start () {
        lastSpawnTime = Time.time;
	}
	
	void Update () {
        int currentWave = GameManager.wave;
        if (currentWave <= waves.Length)
        {
            float timeInterval = Time.time - lastSpawnTime;
            float spawnInterval = waves[currentWave - 1].spawnInterval;
            if (((enemiesSpawned == 0 && timeInterval > timeBetweenWaves) || timeInterval > spawnInterval) && enemiesSpawned < waves[currentWave - 1].maxPizzas)
            {
                lastSpawnTime = Time.time;
                GameObject newPizza = Instantiate(waves[currentWave - 1].pizzaPrefab);
                newPizza.GetComponent<movePizza>().waypoints = waypoints;
                enemiesSpawned++;
            }
        }
        if ((GameObject.FindGameObjectWithTag("Pizza") == null && enemiesSpawned == waves[currentWave - 1].maxPizzas) || GameManager.health < 1)
        {
            if (GameManager.health < 1)
            {
                GameManager.Won = false;
                GameManager.GameOver();
            }
            else if (GameManager.health >= 1 && currentWave == 3)
            {
                GameManager.Won = true;
                GameManager.GameOver();
            }
            else
            {
                lastSpawnTime = Time.time;
                enemiesSpawned = 0;
                GameManager.LevelManagement();
            }
        }
    }
}

