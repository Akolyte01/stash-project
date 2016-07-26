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
    // Use this for initialization

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
