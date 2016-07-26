using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class HUDScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void restart() {
        SceneManager.LoadScene("StartScene");
    }
}
