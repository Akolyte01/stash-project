using UnityEngine;
using System.Collections;

public class PatrolState : NPCState {
    private readonly NPC npc;

	private float idleChecker;

    public PatrolState(NPC npc) {
        this.npc = npc;
    }


    public void UpdateState()
    {
        Debug.Log("Patrol");
        checkSuspicious();
        checkAlerted();
	
		//every 5 second or so, check to enter idle
		idleChecker += Time.deltaTime;
		if (idleChecker > 5.0f) {
			idleChecker = 0f;
			checkIdleChance();
		}


    }

    public void ToPatrolState()
    {
        npc.currentState = npc.patrolState;
    }

    public void ToSuspiciousState()
    {
        npc.currentState = npc.suspiciousState;
    }

    public void ToPursueState()
    {
        npc.currentState = npc.pursueState;
    }

    public void ToIdleState()
    {
        npc.currentState = npc.idleState;
    }
    
    private void checkSuspicious() {
        if(npc.suspicious) {
            ToSuspiciousState();
        }
    } 

    private void checkAlerted() {
        if(npc.alerted && npc.willPursue) {
            ToPursueState();
        }
    }

	private void checkIdleChance() {
		if (npc.idleChance > 0) {
			float chance = Random.Range(0f,100f);
			Debug.Log ("Could idle if > than " + chance);
			if (npc.idleChance > chance) {
				ToIdleState ();
			}
		}
	}
}
