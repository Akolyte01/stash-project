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

        npc.nav.updatePosition = false;
        npc.nav.updateRotation = false;

        npc.nav.nextPosition = npc.transform.position;

        float lastVSpeed = npc.npcAnimator.GetFloat("vSpeed");
        float lastHSpeed = npc.npcAnimator.GetFloat("hSpeed");

                
        float vSpeed = Mathf.Lerp(lastVSpeed, 0, .5f * Time.deltaTime/Mathf.Abs(lastVSpeed));
        float hSpeed = Mathf.Lerp(lastHSpeed, 0, 2 * Time.deltaTime/Mathf.Abs(lastHSpeed));

        npc.npcAnimator.SetFloat("vSpeed",vSpeed);
        npc.npcAnimator.SetFloat("hSpeed",hSpeed);

        Vector3 directionToPlayer = npc.player.transform.position - npc.transform.position;
        float angle = Vector3.Angle(npc.transform.forward, directionToPlayer);
        if(Vector3.Cross(npc.transform.forward, directionToPlayer).y < 0) {
            angle = -angle;
        }

        npc.npcAnimator.SetBool("turningLeft", false);
        npc.npcAnimator.SetBool("turningRight", false);

        if(Mathf.Abs(angle) > 15.0f) {
            if(angle > 0) {
                npc.npcAnimator.SetBool("turningRight", true);
                
            } else{
                npc.npcAnimator.SetBool("turningLeft", true);
            }
        }

        if(!npc.player.caught) {
            checkLOS();
            checkAlerted();
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
            npc.npcAnimator.SetBool("turningLeft", false);
            npc.npcAnimator.SetBool("turningRight", false);
            ToPatrolState();
        }
    }
    
    private void checkAlerted() {
        if(npc.alerted && npc.willPursue) {
            npc.npcAnimator.SetBool("turningLeft", false);
            npc.npcAnimator.SetBool("turningRight", false);
            ToPursueState();
        }
    }

    public void TouchedPlayer() {

    }
}
