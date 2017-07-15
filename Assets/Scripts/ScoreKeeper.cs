using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour {

    public float score;

    public string writenText;
    private Text text;
    public GameObject displayText;

    private PlayerController player;
    public GameObject deathStuff;


	// Use this for initialization
	void Start () {
        player = GameObject.Find("Character/Bike").GetComponent<PlayerController>();
        text = displayText.GetComponent<Text>();

	}
	
	// Update is called once per frame
	void Update () {
        text.text = writenText + score;

        if (player.currentHealth <= 0)
        {
            player.shoot = false;
            player.screenClear = false;
            player.notDead = false;
            //Time.timeScale = 0.2f;
            deathStuff.SetActive(true);
        }
	}
}
