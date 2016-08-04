using UnityEngine;
using System.Collections;

public class GateSound : MonoBehaviour {
    AudioSource audio;

	// Use this for initialization
	void Start () {
	    audio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        float target = GetComponent<Rigidbody>().angularVelocity.magnitude / 10.0f;
	    audio.volume = Mathf.Lerp(audio.volume, target, Time.deltaTime*3.0f);
	}
}
