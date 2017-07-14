﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RaidialHealthBar : MonoBehaviour {
    Image fillImg;
    private PlayerController pController;
    public float healthTimeMultiplier;
	// Use this for initialization
	void Start () {
        fillImg = this.GetComponent<Image>();
        pController = GameObject.Find("Character/Bike").GetComponent<PlayerController>();
     
	}
	
	// Update is called once per frame
	void Update () {
        if (pController.currentHealth > 0)
        {
            pController.currentHealth -= Time.deltaTime * healthTimeMultiplier;
            fillImg.fillAmount = pController.currentHealth / pController.health;
        }
	}
}
