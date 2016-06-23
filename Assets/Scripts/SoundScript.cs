using UnityEngine;
using System.Collections;

public class SoundScript : MonoBehaviour {

	bool isgrounded = true;


	void Start() {
		
	}
		
	void Update () {
	
	}

	void OnCollisionEnter (Collision col) {
		if(col.gameObject.tag == "Floor" || col.gameObject.tag == "Stairs")
		{
			isgrounded = true;
			Debug.Log (isgrounded);
		}
	}

	void OnCollisionExit (Collision col) {
		if(col.gameObject.tag == "Floor" || col.gameObject.tag == "Stairs")
		{
			isgrounded = false;
			Debug.Log (isgrounded);
		}
	}

}
