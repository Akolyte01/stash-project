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
        
        npc.nav.updatePosition = false;
        npc.nav.updateRotation = false;

        npc.nav.nextPosition = npc.transform.position;

        float lastVSpeed = npc.npcAnimator.GetFloat("vSpeed");
        float lastHSpeed = npc.npcAnimator.GetFloat("hSpeed");

                
        float vSpeed = Mathf.Lerp(lastVSpeed, 0, .5f * Time.deltaTime/Mathf.Abs(lastVSpeed));
        float hSpeed = Mathf.Lerp(lastHSpeed, 0, 2 * Time.deltaTime/Mathf.Abs(lastHSpeed));

        npc.npcAnimator.SetFloat("vSpeed",vSpeed);
        npc.npcAnimator.SetFloat("hSpeed",hSpeed);

        //Debug.Log(npc);
        //Debug.Log(vSpeed);
        //Debug.Log(hSpeed);

        //npc.npcAnimator.speed = 0;
        idleTimer += Time.deltaTime;
		//goes back into Patrol after 4 seconds, unless IdleChance is 100% (always idling, for shoppers)
		if (idleTimer > npc.idleTime && ( npc.idleChance < 100) ) {
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
            ToPursueState();
        }
    }

    public void TouchedPlayer() {

    }
}