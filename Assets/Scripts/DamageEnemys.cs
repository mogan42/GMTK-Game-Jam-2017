using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEnemys : MonoBehaviour {
    
    public float healthToTake;
    private Enemy cHealth;
    public bool isScreenClear;
    private float lifeTime = 200f;
	// Use this for initialization
	void Start () {
        if (isScreenClear == true)
        {
        Destroy(gameObject, lifeTime);
        }

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            cHealth = other.GetComponent<Enemy>();
            cHealth.health = cHealth.health - healthToTake;
            if (!isScreenClear)
            {
            Destroy(gameObject);
            }

            
        }
        if (isScreenClear == true)
        {
            if (other.gameObject.tag == "Bullet")
            {
                Destroy(other.gameObject);
            }
        }

    }
}
