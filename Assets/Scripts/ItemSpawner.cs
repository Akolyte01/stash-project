using UnityEngine;
using System.Collections;

public class ItemSpawner : MonoBehaviour {

    public GameObject item;
    public int numItems;
    public float distanceBetween;

    void Awake() {
        for(int i = 0; i < numItems; i++) {
            if(Random.value > .5) {
                Instantiate(item, transform.position + transform.forward * (i * distanceBetween), Quaternion.identity);
            }            
        }
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
