﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public GameObject[] enemys;
    public Vector3 enemySpawnLocations;
    public int noOfEnemies;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    private float timer;
    public float timerTarget;
	// Use this for initialization
	void Start () {

        StartCoroutine(SpawnWave());
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if (timer >= timerTarget)
        {
            noOfEnemies++;
            //Debug.Log("Game is harder");
            timer = 0;
        }
	}

    IEnumerator SpawnWave()
    {
        yield return new WaitForSeconds(startWait);
        while (true) {
            for (int i = 0; i < noOfEnemies; i++)
            {
                GameObject enemy = enemys[Random.Range(0, enemys.Length)];
                Vector3 spawnPosition = new Vector3(Random.Range(-enemySpawnLocations.x, enemySpawnLocations.x), enemySpawnLocations.y, enemySpawnLocations.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(enemy, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
        }
    }
}
