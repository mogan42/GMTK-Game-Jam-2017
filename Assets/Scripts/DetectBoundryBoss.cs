using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectBoundryBoss : MonoBehaviour {

    public Enemy enemy;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.name == "DestroySpillOver")
        {
            enemy.inRange = true;
        }
    }
}
