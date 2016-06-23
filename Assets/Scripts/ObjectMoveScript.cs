using UnityEngine;
using System.Collections;

public class ObjectMoveScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter (Collision col) {
		Debug.Log ("CALLED " + col.gameObject.name + " " + col.gameObject.tag);
		if(col.gameObject.tag == "Player") {
			Debug.Log ("Is Player");
		}
	}
}
