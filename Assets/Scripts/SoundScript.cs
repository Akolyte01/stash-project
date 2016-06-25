using UnityEngine;
using System.Collections;

public class SoundScript : MonoBehaviour {

	bool isgrounded = true;
	public AudioSource audio;
	public AudioClip[] regular;
	public AudioClip[] water;
	public AudioClip[] sand;
    public AudioClip[] carpet;
    public AudioClip[] blood;
	bool step = true;
	float audioStepLengthWalk = 0.45f;
	float audioStepLengthRun = 0.25f;

	void Start() {
		step = true;
	}
		
	void Update () {

	}

	IEnumerator OnControllerColliderHit(ControllerColliderHit hit) {
		CharacterController controller = GetComponent<CharacterController>();

		if (controller.isGrounded && controller.velocity.magnitude < 7
			&& controller.velocity.magnitude > 1 && hit.gameObject.tag == "Floor"  && step == true) {
			//WalkOnFloor(); //not getting called for some reason... guess I will just not put it in its own function...
			step = false;
			audio.clip = regular[Random.Range(0, 3)]; //3 is the length of the array
			audio.volume = .1f;
			audio.Play();
			yield return new WaitForSeconds(audioStepLengthWalk);
			step = true;
		}
		if (controller.isGrounded && controller.velocity.magnitude < 7
			&& controller.velocity.magnitude > 1 && hit.gameObject.tag == "WetFloor"  && step == true) {
			step = false;
			audio.clip = water[Random.Range(0, 7)];
			audio.volume = .1f;
			audio.Play();
			yield return new WaitForSeconds(audioStepLengthWalk);
			step = true;
		}
		if (controller.isGrounded && controller.velocity.magnitude < 7
			&& controller.velocity.magnitude > 1 && hit.gameObject.tag == "SandyFloor"  && step == true) {
			step = false;
			audio.clip = sand[Random.Range(0, 10)];
			audio.volume = .1f;
			audio.Play();
			yield return new WaitForSeconds(audioStepLengthWalk);
			step = true;
		}
        if (controller.isGrounded && controller.velocity.magnitude < 7
            && controller.velocity.magnitude > 1 && hit.gameObject.tag == "Carpet" && step == true)
        {
            step = false;
            audio.clip = carpet[Random.Range(0, 2)];
            audio.volume = .1f;
            audio.Play();
            yield return new WaitForSeconds(audioStepLengthWalk);
            step = true;
        }
        if (controller.isGrounded && controller.velocity.magnitude < 7
            && controller.velocity.magnitude > 1 && hit.gameObject.tag == "Blood" && step == true)
        {
            step = false;
            audio.clip = blood[Random.Range(0, 7)];
            audio.volume = .1f;
            audio.Play();
            yield return new WaitForSeconds(audioStepLengthWalk);
            step = true;
        }
    }
		

}
