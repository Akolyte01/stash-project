using UnityEngine;
using System.Collections;

public class ItemSpawner : MonoBehaviour {

    public GameObject item;
    public int numItems;
    public float distanceBetween;

    void Awake() {
        for(int i = 0; i < numItems; i++) {
            Instantiate(item, transform.position + transform.forward * (i * distanceBetween), Quaternion.identity);
            Debug.Log(i* distanceBetween);
            Debug.Log(transform.position + transform.forward * (i * distanceBetween));
        }
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
