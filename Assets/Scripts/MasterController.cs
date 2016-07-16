//Team Hindenburg
//Jeffrey, Olivia, Scott, Stephanie

using UnityEngine;
using System.Collections;

public class MasterController : MonoBehaviour {

    public Player player;
    public NPC[] NPCs;
    // Use this for initialization

    public float suspicionLevel;

	void Start () {
        suspicionLevel = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
        if (player.IsStealing())
        {
            foreach(NPC npc in NPCs)
            {
                if (npc.CanSee(player.gameObject) != -1.0f)
                {
                    suspicionLevel += npc.penaltyMult;
                    npc.suspicious = true; 
                }
            }
            player.StopSteal();
        }

        if (suspicionLevel >= 25) {
            foreach(NPC npc in NPCs) {
                npc.alerted = true;
            }
        }
	}
}
