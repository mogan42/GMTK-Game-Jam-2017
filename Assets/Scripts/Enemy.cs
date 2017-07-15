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

    private float YTransform;

    public float health = 100f;
    private ScoreKeeper score;
    public float scoreToGive;
    public GameObject[] disable;
    public GameObject explosion;
    private BasicEnemyMovment enemy;
    private Collider col;
    private bool deadAlready = false;
    public bool beenHit = false;
    private AudioSource aSource;
    public AudioSource aSource2;
    public AudioClip explosionSound;
    public AudioClip hitSound;

    public BasicEnemyMovment basic;

    //is Osu
    public bool isOsu;
    public float osuYPoss = -4.3f;

    //is hikari kyun
    public bool iskyun;
    public float kyunsYPoss = 10f;
    private float ranRange;
   

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        currentSpeed = rb.velocity.z;
        score = GameObject.Find("GameController").GetComponent<ScoreKeeper>();
        enemy = GetComponent<BasicEnemyMovment>();
        col = GetComponent<Collider>();
        aSource = GetComponent<AudioSource>();
        basic = GetComponent<BasicEnemyMovment>();

        if (isOsu)
        {
            YTransform = osuYPoss;
            StartCoroutine(Evade());
        }
        if (iskyun)
        {
            YTransform = kyunsYPoss;
           ranRange = Random.Range(-1,1);
        }


	}
    private void Update()
    {
        Debug.Log(ranRange);
        if (beenHit)
        {
            aSource2.PlayOneShot(hitSound, 0.5f);
            beenHit = false;
        }
    }

    void FixedUpdate () {

        if (isOsu)
        {
            float newManeuver = Mathf.MoveTowards(rb.velocity.x, targetManover, Time.deltaTime * smothing);
            rb.velocity = new Vector3(newManeuver, 0.0f, currentSpeed);
            rb.position = new Vector3
                (Mathf.Clamp(rb.position.x, bounds.xMin, bounds.xMax), YTransform, Mathf.Clamp(rb.position.z, bounds.zMin, bounds.zMax));
            rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x * -tilt);
        }
        if (iskyun)
        {
            if (ranRange == 0)
            {
                rb.velocity = transform.right * basic.speed + transform.forward * basic.speed;
            }
            else if (ranRange >= 0)
            {
                rb.velocity = -transform.right * basic.speed + transform.forward * basic.speed;
            }

        }


        if (health <= 0f)
        {
            if (!deadAlready)
            {
                foreach (GameObject obj in disable)
                {
                obj.SetActive(false);
                }
                score.score = score.score + scoreToGive;
                enemy.enemyShoot = false;
                explosion.SetActive(true);
                col.isTrigger = true;
                aSource.PlayOneShot(explosionSound, 0.3f);
                deadAlready = true;
            }

            Destroy(gameObject, 2f);
        }

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
