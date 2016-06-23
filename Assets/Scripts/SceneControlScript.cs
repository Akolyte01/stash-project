using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneControlScript : MonoBehaviour {


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
		//Level Loading
		if (Input.GetKeyDown (KeyCode.Alpha0)) {
			Application.LoadLevel (0); //this index is determined by the order scenes were added to build settings (File -> Build Settings...)
		}
		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			Application.LoadLevel (1);
		}
		if (Input.GetKeyDown (KeyCode.Alpha2)) {
			Application.LoadLevel (2);
		}
		if (Input.GetKeyDown (KeyCode.Alpha3)) {
			Application.LoadLevel (3);
		}
		if (Input.GetKeyDown (KeyCode.Alpha4)) {
			Application.LoadLevel (4);
		}
		if (Input.GetKeyDown (KeyCode.Alpha5)) {
			Application.LoadLevel (5);
		}

	}
}
