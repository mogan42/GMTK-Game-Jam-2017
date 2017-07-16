using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamagePlayer : MonoBehaviour {
    
    public float healthToTake;
    private PlayerController cHealth;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            cHealth = other.GetComponent<PlayerController>();
            cHealth.currentHealth = cHealth.currentHealth - healthToTake;
            cHealth.beenhit = true;
            Destroy(gameObject);
            
        }
    }
}
