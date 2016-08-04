using UnityEngine;
using System.Collections;

public class CartSound : MonoBehaviour {
    AudioSource audio;

	// Use this for initialization
	void Start () {
	    audio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
	    audio.volume = Mathf.Pow(GetComponent<Rigidbody>().velocity.magnitude / 2.0f, 2) ;
	}
}
