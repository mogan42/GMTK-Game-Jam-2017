using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public GameObject enemys;
    public Vector3 enemySpawnLocations;

	// Use this for initialization
	void Start () {
        SpawnWave();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void SpawnWave()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(-enemySpawnLocations.x, enemySpawnLocations.x) ,enemySpawnLocations.z,enemySpawnLocations.z);
        Quaternion spawnRotation = Quaternion.identity;
        Instantiate(enemys, spawnPosition, spawnRotation);
    }
}
