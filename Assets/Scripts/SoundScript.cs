using UnityEngine;
using System.Collections;

public class SoundScript : MonoBehaviour {

	bool isgrounded = true;
	public AudioSource audio;
	public AudioClip[] regular;
	//public AudioClip[] water;
	bool step = true;
	float audioStepLengthWalk = 0.45f;
	float audioStepLengthRun = 0.25f;

	void Start() {
		step = true;
	}
		
	void Update () {

	}

	void OnControllerColliderHit(ControllerColliderHit hit) {
		CharacterController controller = GetComponent<CharacterController>();
		Debug.Log ("hit");

		Debug.Log (controller.isGrounded + " ground");

		Debug.Log (controller.velocity.magnitude < 7);

		//Debug.Log (controller.velocity.magnitude > 5); //FALSE

		Debug.Log ((hit.gameObject.tag == "Floor") + " floor");
		Debug.Log (step + " step");

		if (controller.isGrounded && controller.velocity.magnitude < 7
			//&& controller.velocity.magnitude > 5
			&& hit.gameObject.tag == "Floor"  && step == true
			//|| controller.isGrounded && controller.velocity.magnitude < 7 && controller.velocity.magnitude > 5 && hit.gameObject.tag == "Floor" && step == true
		) {

			Debug.Log ("CALLED");
			WalkOnConcrete();
		
		}
	}

	IEnumerator WalkOnConcrete() {
		step = false;
		audio.clip = regular[Random.Range(0, 3)];
		audio.volume = .1f;
		audio.Play();
		yield return new WaitForSeconds(audioStepLengthWalk);
		step = true;
	}


//
//	void OnCollisionEnter (Collision col) {
//		if(col.gameObject.tag == "Floor")
//		{
//			Debug.Log ("Floor");
//		}
//	}
//
//	void OnCollisionStay (Collision col) {
//		if(col.gameObject.tag == "Floor")
//		{
//			Debug.Log ("Floor STAY");
//		}
//	}

}
