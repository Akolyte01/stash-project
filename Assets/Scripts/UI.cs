﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UI : MonoBehaviour {
    public Text suspicionText;
    public MasterController masterController;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        suspicionText.text = "Suspicion: " + Mathf.Round(masterController.suspicionLevel);
	}
}
