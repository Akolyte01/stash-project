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
        score = 0f;
        //stealables = stealablesHolder.GetComponentsInChildren<Stealable>();
        stealables = FindObjectsOfType<Stealable>();
        //Debug.Log(stealables[0]);
	}
	
	// Update is called once per frame
	void Update () {

        foreach (Stealable stealable in stealables) {
            if (stealable != null && stealable.canBeStolen()) {
                stealable.isHighlighted = true;
                if (player.stealing) {
                    score += stealable.points;
                    player.audio.PlayOneShot(stealClip, .7f);
                    float maxPenalty = 0f;
                    foreach (NPC npc in NPCs) {
                        float distToPlayerSeen = npc.CanSee(player.gameObject);
                        if (distToPlayerSeen != -1.0f) {
                            float penalty = npc.penaltyMult * Mathf.Sqrt((npc.perceptionDistance - distToPlayerSeen) / npc.perceptionDistance); 
                            Debug.Log(distToPlayerSeen);
                            Debug.Log(npc.perceptionDistance);
                            Debug.Log(npc.penaltyMult);
                            Debug.Log(penalty);
                            if(penalty > maxPenalty) maxPenalty = penalty;
                            //suspicionLevel += npc.penaltyMult;
                            npc.suspicious = true;
                            npc.playAlertSound();
                        }
                    }
                    suspicionLevel += maxPenalty;
                    DestroyObject(stealable.gameObject);
                }
                break;
            } else {
                stealable.isHighlighted = false;
            }
        }
        player.stealing = false;
        
        if(player.sprinting && score > 0) { 
            if(score%5 - 3.5f*Time.deltaTime < 0) {
                player.DropItem();
            }
            score -= 3.5f*Time.deltaTime;
            if (score < 0) score = 0;
        }


        if (score < 100) {
            gotEnough = false;
        }
        else if(!gotEnough) {
            gotEnough = true;
            player.audio.PlayOneShot(enoughPointsClip,.7f);
        }

        //foreach (NPC npc in NPCs) {
        //    if (npc.CanSee(player.gameObject) != -1.0f) {
        //        suspicionLevel += (score + suspicionLevel) / 20 * Time.deltaTime;
        //    }
        //}
        //if(suspicionLevel >= 0) {
        //    suspicionLevel -= 2 * Time.deltaTime;
        //}


        if (score <= 0 && suspicionLevel > 0) {
            suspicionLevel -= 2 * Time.deltaTime;
        }
        suspicionLevel += (score + (score * suspicionLevel / 100)) / 50 * Time.deltaTime;

        if (suspicionLevel >= 100) {
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
        Debug.Log("win");
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
