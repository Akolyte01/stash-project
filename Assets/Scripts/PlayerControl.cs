using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

    Animator NPCAnimator;
	Rigidbody[] boneRig;
	bool ragdollMode = false;

	// Use this for initialization
	void Start () {
        NPCAnimator = GetComponent<Animator>();
		boneRig = GetComponentsInChildren<Rigidbody> ();
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

		if (Input.GetKeyDown("r"))
		{
			ragdollMode = !ragdollMode;

		}

		if (ragdollMode) {
			foreach (Rigidbody bone in boneRig) {
				bone.isKinematic = false;
			}
			NPCAnimator.enabled = false;
		} else {
			foreach (Rigidbody bone in boneRig) {
				bone.isKinematic = true;
			}
			NPCAnimator.enabled = true;
		}

        //Handles the scaling
        if (Input.GetKey(KeyCode.G) && transform.localScale.x < 2 && !ragdollMode)
        {
            transform.localScale += new Vector3(0.1F, 0, 0);
        }

        if (Input.GetKey(KeyCode.H) && transform.localScale.x > 1 && !ragdollMode)
        {
            transform.localScale -= new Vector3(0.1F, 0, 0);
        }
        //End of scaling
    }

}
