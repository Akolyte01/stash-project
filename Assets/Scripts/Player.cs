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

    public GameObject droppableItem;
    public AudioClip dropSound;

    [HideInInspector] public bool stealing = false;
    [HideInInspector] public bool caught = false;
    [HideInInspector] public bool sprinting = false;
    [HideInInspector] public AudioSource audio;


	bool ragdollMode = false;

	// Use this for initialization
	void Start () {
        playerAnimator = GetComponent<Animator>();
		boneRig = GetComponentsInChildren<Rigidbody> ();
        playerCollider = GetComponent<CapsuleCollider>();
        playerController = GetComponent<CharacterController>();
        mouseLook = GetComponent<MouseLook>();
        audio = GetComponent<AudioSource>();
        HandleRagdoll();
    }
	
	// Update is called once per frame
	void Update () {
        HandleMovement();
        HandleScaling();

        if (Input.GetKeyDown("e") || Input.GetMouseButtonDown(0)) 
        {
            stealing = true;
        }

		//if (Input.GetKeyDown("r"))
		//{
  //          ragdollMode = !ragdollMode;
  //          HandleRagdoll();
		//}
    }

    public void DropItem() {
        Vector3 velocity = new Vector3(Random.value*2-1, Random.value*2, Random.value*2-1);
        velocity.Normalize();
        Vector3 offset = velocity/10;
        velocity = velocity * (.2f + .3f*Mathf.Sqrt(Random.value)); 
        //Vector3 offset = new Vector3((Random.value-.5f) / 10, (Random.value-.5f) / 10, (Random.value-.5f) / 10);
        velocity = velocity * 10;
        GameObject droppedItem = (GameObject) Instantiate(droppableItem, transform.position + Vector3.up*1.2f + offset, Quaternion.identity);
        droppedItem.GetComponent<Rigidbody>().velocity = velocity;
        audio.PlayOneShot(dropSound);
    }


    void HandleMovement()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        playerAnimator.SetFloat("vSpeed", v);
        playerAnimator.SetFloat("hSpeed", h);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            sprinting = true;
            playerAnimator.SetBool("sprinting", true);
        }
        else
        {
            sprinting = false;
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

    public void ActivateRagdoll() {
        ragdollMode = true;
        HandleRagdoll();
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
