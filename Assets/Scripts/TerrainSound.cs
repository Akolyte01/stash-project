using UnityEngine;
using System.Collections;

public class TerrainSound : MonoBehaviour {

	void OnTriggerEnter(Collider col)
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.Play();
    }
}
