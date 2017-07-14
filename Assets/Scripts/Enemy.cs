using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public Vector2 startwait;
    public Vector2 maneuvertime;
    public Vector2 maneuverwait;

    private float targetManover;
    public float doge;
    public float smothing;
    private float currentSpeed;

    private Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        currentSpeed = rb.velocity.z;
        StartCoroutine(Evade());
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        float newManeuver = Mathf.MoveTowards(rb.velocity.x, targetManover, Time.deltaTime * smothing);
        rb.velocity = new Vector3(newManeuver, 0.0f, currentSpeed);
        rb.position = new Vector3
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
