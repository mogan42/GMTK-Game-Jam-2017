using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    //movment
    CharacterController cC;

    Vector3 moveDirection;
    Vector3 LookDirection;

    public float playerSpeed;
    public float turnSpeed;

    bool isMoving;
    bool isLooking;
    //player health and ammo
    public float health;
    public float currentHealth;
    public float bulletsCost;
    public float screenClearBulletsCost;

    //Shooting
    bool shoot;
    float shotcounter;
    public float timeBetweenShots;
    public float bulletSpeed;
    public GameObject firePoint;
    public GameObject bulletPrefab;
    //Shooting2
    bool screenClear;
    float shotcounter2;
    public float timeBetweenShots2;
    public float bulletSpeed2;
    public GameObject screenClearBulletPrefab;
    public bool notDead = true;

    // Use this for initialization
    void Start () {
        cC = GetComponent<CharacterController>();
        currentHealth = health;
	}
	
	// Update is called once per frame
	void Update () {


        if (notDead)
        {
            PlayerMoveDirection();
            cC.SimpleMove(moveDirection * playerSpeed);
            if (Input.GetButton("Fire1"))
                {
                shoot = true;
                }
                else
                {
                shoot = false;
                }
                if (Input.GetButton("Fire2"))
                {
                screenClear = true;
                }
                else
                {
                screenClear = false;
                }

                if (currentHealth >= health)
                {
                currentHealth = health;
                }

        }
   

        if (shoot)
        {
            shotcounter -= Time.deltaTime;
            if (shotcounter <= 0)
            {
                shotcounter = timeBetweenShots;
                var bullet = Instantiate(bulletPrefab, firePoint.transform.position, firePoint.transform.rotation);
                bullet.GetComponent<Rigidbody>().AddForce(transform.right * bulletSpeed, ForceMode.Impulse);
                currentHealth = currentHealth - bulletsCost;
                Destroy(bullet, 5);
            }
        }
        else
        {
            shotcounter = 0;
        }
        if (screenClear)
        {
            shotcounter2 -= Time.deltaTime;
            if (shotcounter2 <= 0)
            {
                shotcounter2 = timeBetweenShots2;
                var bullet = Instantiate(screenClearBulletPrefab, firePoint.transform.position, firePoint.transform.rotation);
                bullet.GetComponent<Rigidbody>().AddForce(transform.right * bulletSpeed, ForceMode.Impulse);
                currentHealth = currentHealth - screenClearBulletsCost;
                Destroy(bullet, 5);
            }
        }
        else
        {
            shotcounter2 = 0;
        }

    }

    void PlayerMoveDirection()
    {
        moveDirection = new Vector3(-Input.GetAxisRaw("Horizontal"), 0f,-Input.GetAxisRaw("Vertical"));
        
    }

}
