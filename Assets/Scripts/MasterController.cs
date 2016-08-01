//Team Hindenburg
//Jeffrey, Olivia, Scott, Stephanie

using UnityEngine;
using System.Collections;

public class MasterController : MonoBehaviour {

    public Player player;
    public NPC[] NPCs;
    public GameObject stealablesHolder;
    public Animator gameEndAnimator;
    Stealable[] stealables;

	public Texture2D cursorTexture;
	public CursorMode cursorMode = CursorMode.Auto;
	public Vector2 hotSpot = Vector2.zero;

    public float suspicionLevel;
    public float score;
    public AudioClip stealClip;
    public AudioClip enoughPointsClip;
    public AudioClip winClip;
    public AudioClip loseClip;

    bool gotEnough = false;
    bool lost = false;


	void Start () {
        suspicionLevel = 0.0f;
        score = 0.0f;
        //stealables = stealablesHolder.GetComponentsInChildren<Stealable>();
        stealables = FindObjectsOfType<Stealable>();
        //Debug.Log(stealables[0]);
	}
	
	// Update is called once per frame
	void Update () {
        if (player.stealing)
        {
            foreach(Stealable stealable in stealables) {
                if (stealable != null && stealable.canBeStolen()){
                    score += stealable.points;
                    player.audio.PlayOneShot(stealClip,.7f);
                    foreach(NPC npc in NPCs)
                    {
                        if (npc.CanSee(player.gameObject) != -1.0f)
                        {
                            suspicionLevel += npc.penaltyMult;
                            npc.suspicious = true;
                            npc.playAlertSound(); 
                        }
                    }
                    DestroyObject(stealable.gameObject);
                    break;
                }
            }

            player.stealing = false;
        }





		//casting rays at where player is looking to find cans, then display grab cursor icon
		RaycastHit hit;
		//Debug.DrawRay(player.transform.FindChild("EyeLevel").transform.position, player.transform.forward, Color.red);
		if (Physics.Raycast (player.transform.FindChild("EyeLevel").transform.position, player.transform.forward, out hit)) {
			print ("Found an object - distance: " + hit.distance);
			//Debug.Log (hit.transform.gameObject);
			if (hit.transform.gameObject.tag == "Stealable") {
				if (hit.distance < 1.3) { //the can's grabdistance attribute, I'm being lazy by not getting it directly
					Debug.Log ("HAND");


					Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
					
				}
				else {
					Debug.Log ("no");
					Cursor.SetCursor(null, Vector2.zero, cursorMode);
				}
			} else {
				Debug.Log ("no");
				Cursor.SetCursor(null, Vector2.zero, cursorMode);
			}
		} else {
			Debug.Log ("no");
			Cursor.SetCursor(null, Vector2.zero, cursorMode);
		}






        if (score < 100) {
            gotEnough = false;
        }
        else if(!gotEnough) {
            gotEnough = true;
            player.audio.PlayOneShot(enoughPointsClip,.7f);
        }

        if (suspicionLevel >= 25) {
            foreach(NPC npc in NPCs) {
                npc.alerted = true;
            }
        }

        if(player.caught && !lost) {
            player.ActivateRagdoll();
            Lose();
        }
	}

    void OnTriggerExit(Collider other) {

        if (other.gameObject == player.gameObject) {
            if(gotEnough) {
                Win();
            }
        }
    }

    void Win() {
        player.audio.PlayOneShot(winClip,.9f);
        gameEndAnimator.SetTrigger("GameWin");
    }

    void Lose() {
        lost = true;
        player.audio.PlayOneShot(loseClip,.8f);
        gameEndAnimator.SetTrigger("GameOver");
    }

    public static void dicks() {

    }
}
