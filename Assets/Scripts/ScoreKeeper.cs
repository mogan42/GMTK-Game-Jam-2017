using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour {

    public float score;

    public string writenText;
    private Text text;
    public GameObject displayText;


	// Use this for initialization
	void Start () {
        text = displayText.GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        text.text = writenText + score;
	}
}
