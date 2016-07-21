//Team Hindenburg
//Jeffrey, Olivia, Scott, Stephanie
using UnityEngine;
using System.Collections;
using System;

public class IdleState : NPCState{
    private readonly NPC npc;

    private float idleTimer;

    public IdleState(NPC npc) {
        this.npc = npc;
    }

    public void UpdateState()
    {
        
        //npc.npcAnimator.speed = 0;
        idleTimer += Time.deltaTime;
		//goes back into Patrol after 4 seconds, unless IdleChance is 100% (always idling, for shoppers)
		if (idleTimer > 4.0f && ( npc.idleChance < 100) ) {
            npc.npcAnimator.SetBool("idle", false);
            ToPatrolState();
        }

        checkSuspicious();
        checkAlerted();        
    }

    public void ToPatrolState()
    {
        npc.currentState = npc.patrolState;
        idleTimer = 0f;
    }

    public void ToSuspiciousState()
    {
        npc.currentState = npc.suspiciousState;
        idleTimer = 0f;
    }

    public void ToPursueState()
    {
        npc.currentState = npc.pursueState;
        idleTimer = 0f;
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
            npc.npcAnimator.SetBool("alert", true);
            ToPursueState();
        }
    }

    public void TouchedPlayer() {

    }
}