using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

    Animator NPCAnimator;

	// Use this for initialization
	void Start () {
        NPCAnimator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        NPCAnimator.SetFloat("vSpeed", v);
        NPCAnimator.SetFloat("hSpeed", h);

        if (Input.GetKey("q")) {
            if (h == 0f && v == 0f) {
                NPCAnimator.SetBool("turningLeft", true);
            }
            else
            {
                transform.Rotate(Vector3.up * Time.deltaTime * -70.0f);
            }
        }
        else
        {
            NPCAnimator.SetBool("turningLeft", false);
        }

        if (Input.GetKey("e"))
        {
            if (h == 0f && v == 0f)
            {
                NPCAnimator.SetBool("turningRight", true);
            }
            else
            {
                transform.Rotate(Vector3.up * Time.deltaTime * 70.0f);
            }
        }
        else
        {
            NPCAnimator.SetBool("turningRight", false);
        }

        if (Input.GetKey(KeyCode.LeftShift)){
            NPCAnimator.SetBool("sprinting", true);
        }
        else
        {
            NPCAnimator.SetBool("sprinting", false);
        }
    }
}
