using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyMovment : MonoBehaviour{

    public float speed;

    public GameObject[] pickBullets;

    private GameObject bulletPrefab;
    public Transform[] firePoints;

    public float bulletSpeed;
    private float shotcounter;
    public float timeBetweenShots;
    public float bulletLifeTime;

    public Vector2 bChangeWait;

    private Rigidbody rb;

    public bool enemyShoot = true;

    private Enemy enemy;


    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        enemy = GetComponent<Enemy>();
        bulletPrefab = pickBullets[Random.Range (0,pickBullets.Length)];

        if (!enemy.isBoss)
        {
            rb.velocity = transform.forward * speed;
            StartCoroutine(ChangeAmmo());
        }


    }

    void Update()
    {

        Fire();
    }

    void Fire()
    {
        if (enemyShoot)
        {
            foreach (Transform firePoint in firePoints)
            {
                    shotcounter -= Time.deltaTime;
                if (shotcounter <= 0)
                {
                    shotcounter = timeBetweenShots;
                    var bullet = Instantiate(bulletPrefab, firePoint.transform.position, firePoint.transform.rotation);
                    bullet.GetComponent<Rigidbody>().AddForce(transform.forward * bulletSpeed, ForceMode.Impulse);
                    Destroy(bullet, 5);
                }
            }

        }
        else
        {
            shotcounter = 0;
        }

    }

    IEnumerator ChangeAmmo()
    {
        yield return new WaitForSeconds(Random.Range(bChangeWait.x, bChangeWait.y));
        while (true)
        {
            bulletPrefab = pickBullets[Random.Range(0, pickBullets.Length)];
            yield return new WaitForSeconds(Random.Range (bChangeWait.x, bChangeWait.y));
        }
        

    }

}
