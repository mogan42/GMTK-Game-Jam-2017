using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEnemys : MonoBehaviour {
    
    public float healthToTake;
    private Enemy cHealth;
    public bool isScreenClear;
    private float lifeTime = 200f;
    private AudioSource aSource;
    public Vector2 pitchRange;
    // Use this for initialization
    private void Awake()
    {
        aSource = GetComponent<AudioSource>();
        aSource.pitch = Random.Range(pitchRange.x, pitchRange.y);
    }

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
            cHealth.beenHit = true;
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
