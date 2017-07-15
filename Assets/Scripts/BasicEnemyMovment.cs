using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyMovment : MonoBehaviour{

    public float speed;

    public GameObject[] pickBullets;

    private GameObject bulletPrefab;
    public Transform firePoint;

    public float bulletSpeed;
    private float shotcounter;
    public float timeBetweenShots;
    public float bulletLifeTime;

    public Vector2 bChangeWait;

    private Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;
        bulletPrefab = pickBullets[Random.Range (0,pickBullets.Length)];
        StartCoroutine(ChangeAmmo());
    }

    void Update()
    {

        Fire();
    }

    void Fire()
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
