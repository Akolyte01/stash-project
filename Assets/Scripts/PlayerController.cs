using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	private Animator anim;
	private CharacterController charController;
	private float speed = 6.0f;
	private float gravity = -9.8f;

	void Start () {
		anim = GetComponent<Animator> ();
		charController = GetComponent<CharacterController> ();
	}

	void Update () {
		float groundDistance = Mathf.Abs (transform.position.y);
		float deltaZ = Input.GetAxis ("Vertical") * speed;
		anim.SetFloat ("forward", deltaZ);
		Vector3 movement = new Vector3 (0, 0, deltaZ);
		movement = Vector3.ClampMagnitude (movement, speed);
		movement.y = gravity;
		movement *= Time.deltaTime;
		movement = transform.TransformDirection (movement);
		charController.Move (movement);
	}
}
