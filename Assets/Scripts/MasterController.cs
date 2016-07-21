//Team Hindenburg
//Jeffrey, Olivia, Scott, Stephanie

using UnityEngine;
using System.Collections;

public class MasterController : MonoBehaviour {

    public Player player;
    public NPC[] NPCs;
    public GameObject stealablesHolder;
    Stealable[] stealables;
    // Use this for initialization

    public float suspicionLevel;
    public float score;

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
                    foreach(NPC npc in NPCs)
                    {
                        if (npc.CanSee(player.gameObject) != -1.0f)
                        {
                            suspicionLevel += npc.penaltyMult;
                            npc.suspicious = true; 
                        }
                    }
                    DestroyObject(stealable.gameObject);
                    break;
                }
            }

            player.stealing = false;
        }

        if (suspicionLevel >= 25) {
            foreach(NPC npc in NPCs) {
                npc.alerted = true;
            }
        }

        if(score >= 100) {
            Debug.Log("WIN");
        }

        if(player.caught) {
            player.ActivateRagdoll();
            Debug.Log("LOSE");
        }
	}
}
