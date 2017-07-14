using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    CharacterController cC;

    Vector3 moveDirection;
    Vector3 LookDirection;

    public float playerSpeed;
    public float turnSpeed;


    bool isMoving;
    bool isLooking;

    //Quaternion lookDirection;
    //Quaternion curentLookDirection;


	// Use this for initialization
	void Start () {
        cC = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {

        PlayerMoveDirection();
        //curentLookDirection = Quaternion.LookRotation(moveDirection);
        //lookDirection = Quaternion.RotateTowards(curentLookDirection, lookDirection, Time.deltaTime * turnSpeed);
        
        cC.SimpleMove(moveDirection * playerSpeed);

	}

    void PlayerMoveDirection()
    {
        moveDirection = new Vector3(-Input.GetAxisRaw("Horizontal"), 0f,-Input.GetAxisRaw("Vertical"));
        
    }

}
