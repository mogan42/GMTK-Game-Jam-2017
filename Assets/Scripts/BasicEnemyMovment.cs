using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyMovment : MonoBehaviour{

    public float speed;

    public GameObject goodbullets;
    public GameObject badBullets;

    private GameObject bulletPrefab;
    public Transform firePoint;

    public float bulletSpeed;
    private float shotcounter;
    public float timeBetweenShots;
    public float bulletLifeTime;

    public Vector2 bChangeWait;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;
        bulletPrefab = goodbullets;
        StartCoroutine(ChangeAmmo());
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
    void Update()
    {
        Fire();
    }

    IEnumerator ChangeAmmo()
    {
        yield return new WaitForSeconds(Random.Range(bChangeWait.x, bChangeWait.y));

    }

}
