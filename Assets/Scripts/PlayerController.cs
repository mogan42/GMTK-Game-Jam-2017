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
    public float health = 100f;
    public float currentHealth;
    public float bulletsCost;

    //Shooting
    bool shoot;
    float shotcounter;
    public float timeBetweenShots;
    public float bulletSpeed;
    public GameObject firePoint;
    public GameObject bulletPrefab;


	// Use this for initialization
	void Start () {
        cC = GetComponent<CharacterController>();
        currentHealth = health;
	}
	
	// Update is called once per frame
	void Update () {

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

	}

    void PlayerMoveDirection()
    {
        moveDirection = new Vector3(-Input.GetAxisRaw("Horizontal"), 0f,-Input.GetAxisRaw("Vertical"));
        
    }

}
