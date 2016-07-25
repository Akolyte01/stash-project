using UnityEngine;
using System.Collections;
using System;

public class SuspiciousState : NPCState
{
    private readonly NPC npc;

    public SuspiciousState(NPC npc) {
        this.npc = npc;
    }

    public void UpdateState()
    {

        Vector3 directionToPlayer = npc.player.transform.position - npc.transform.position;
        float angle = Vector3.Angle(npc.transform.forward, directionToPlayer);
        if(Vector3.Cross(npc.transform.forward, directionToPlayer).y < 0) {
            angle = -angle;
        }

        npc.npcAnimator.SetBool("turningLeft", false);
        npc.npcAnimator.SetBool("turningRight", false);

        checkLOS();
        checkAlerted();

        if(Mathf.Abs(angle) > 15.0f) {
            if(angle > 0) {
                npc.npcAnimator.SetBool("turningRight", true);
                
            } else{
                npc.npcAnimator.SetBool("turningLeft", true);
            }
        }

        
    }

    public void ToPatrolState()
    {
        npc.currentState = npc.patrolState;
        npc.suspicious = false;
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

    private void checkLOS() {
        if(npc.CanSeePlayer() == -1f) {
            ToPatrolState();
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
