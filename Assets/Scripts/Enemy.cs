using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}


public class Enemy : MonoBehaviour {

    public Vector2 startwait;
    public Vector2 maneuvertime;
    public Vector2 maneuverwait;

    private float targetManover;
    public float doge;
    public float smothing;
    private float currentSpeed;
    public float tilt;

    private Rigidbody rb;
    public Boundary bounds;

    public float health = 100f;
    private ScoreKeeper score;
    public float scoreToGive;
    public Renderer[] rend;
    public GameObject explosion;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        currentSpeed = rb.velocity.z;
        score = GameObject.Find("GameController").GetComponent<ScoreKeeper>();
        StartCoroutine(Evade());
	}

    void Update()
    {
        if (health <= 0f)
        {
            score.score = score.score + scoreToGive;
            rend[0].enabled = false;
            rend[1].enabled = false;
            explosion.SetActive(true);
            Destroy(gameObject, 3f);
        }
    }

    // Update is called once per frame
    void FixedUpdate () {
        float newManeuver = Mathf.MoveTowards(rb.velocity.x, targetManover, Time.deltaTime * smothing);
        rb.velocity = new Vector3(newManeuver, 0.0f, currentSpeed);
        rb.position = new Vector3
            (Mathf.Clamp(rb.position.x, bounds.xMin, bounds.xMax), -4.3f, Mathf.Clamp(rb.position.z, bounds.zMin, bounds.zMax));
        rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x * -tilt);
	}
    IEnumerator Evade()
    {
        yield return new WaitForSeconds (Random.Range(startwait.x, startwait.y));
        while (true)
        {
            targetManover = Random.Range(1, doge) * -Mathf.Sign (transform.position.x);
            yield return new WaitForSeconds(Random.Range (maneuvertime.x, maneuvertime.y));
            targetManover = 0;
            yield return new WaitForSeconds (Random.Range (maneuverwait.x, maneuverwait.y));
        }
    }
}
