//Team Hindenburg
//Jeffrey, Olivia, Scott, Stephanie

using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    Animator playerAnimator;
	Rigidbody[] boneRig;
    CapsuleCollider playerCollider;
    CharacterController playerController;
    MouseLook mouseLook;
    bool stealing = false;

	bool ragdollMode = false;

	// Use this for initialization
	void Start () {
        playerAnimator = GetComponent<Animator>();
		boneRig = GetComponentsInChildren<Rigidbody> ();
        playerCollider = GetComponent<CapsuleCollider>();
        playerController = GetComponent<CharacterController>();
        mouseLook = GetComponent<MouseLook>();
        HandleRagdoll();
    }
	
	// Update is called once per frame
	void Update () {
        HandleMovement();
        HandleScaling();

        if (Input.GetKeyDown("f"))
        {
            StartSteal();
        }

		if (Input.GetKeyDown("r"))
		{
            ragdollMode = !ragdollMode;
            HandleRagdoll();
		}
    }

    public void StartSteal()
    {
        stealing = true;
    }

    public void StopSteal()
    {
        stealing = false;
    }

    public bool IsStealing()
    {
        return stealing;
    }

    void HandleMovement()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        playerAnimator.SetFloat("vSpeed", v);
        playerAnimator.SetFloat("hSpeed", h);

        if (Input.GetKey("q"))
        {
            if (h == 0f && v == 0f)
            {
                playerAnimator.SetBool("turningLeft", true);
            }
            else
            {
                transform.Rotate(Vector3.up * Time.deltaTime * -70.0f);
            }
        }
        else
        {
            playerAnimator.SetBool("turningLeft", false);
        }

        if (Input.GetKey("e"))
        {
            if (h == 0f && v == 0f)
            {
                playerAnimator.SetBool("turningRight", true);
            }
            else
            {
                transform.Rotate(Vector3.up * Time.deltaTime * 70.0f);
            }
        }
        else
        {
            playerAnimator.SetBool("turningRight", false);
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            playerAnimator.SetBool("sprinting", true);
        }
        else
        {
            playerAnimator.SetBool("sprinting", false);
        }
    }

    void HandleRagdoll()
    {
        if (ragdollMode)
        {
            playerAnimator.enabled = false;
            playerCollider.enabled = false;
            playerController.enabled = false;
            mouseLook.enabled = false;
            foreach (Rigidbody bone in boneRig)
            {
                bone.isKinematic = false;
            }
            
        }
        else
        {
            foreach (Rigidbody bone in boneRig)
            {
                bone.isKinematic = true;
            }
            playerAnimator.enabled = true;
            playerController.enabled = true;
            mouseLook.enabled = true;
            playerCollider.enabled = true;
        }
    }

    void HandleScaling()
    {
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
