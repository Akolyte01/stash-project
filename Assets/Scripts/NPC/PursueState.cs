//Team Hindenburg
//Jeffrey, Olivia, Scott, Stephanie

using UnityEngine;
using System.Collections;
using System;

public class PursueState : NPCState{
    private readonly NPC npc;
    private float secondsInAdvance = 3;
    private float countDown = 0.0f;
    GameObject player = GameObject.FindGameObjectWithTag("Player");

    public PursueState(NPC npc) {
        this.npc = npc;
    }

    public void UpdateState()
    {
        handleSound();

        npc.nav.SetDestination(player.transform.position);

        npc.nav.speed = 1.5f;
        
        npc.nav.updatePosition = false;
        npc.nav.updateRotation = true;

        npc.nav.nextPosition = npc.transform.position;
        
        Vector3 desiredVelocity = npc.transform.InverseTransformDirection(npc.nav.desiredVelocity.normalized);
        desiredVelocity.Normalize();

        npc.npcAnimator.SetBool("sprinting", true);

        float lastVSpeed = npc.npcAnimator.GetFloat("vSpeed");
        float lastHSpeed = npc.npcAnimator.GetFloat("hSpeed");

                
        float vSpeed = Mathf.Lerp(lastVSpeed, desiredVelocity.z, 1f * Time.deltaTime/Mathf.Abs(lastVSpeed-desiredVelocity.z));
        float hSpeed = Mathf.Lerp(lastHSpeed, desiredVelocity.x, 2 * Time.deltaTime/Mathf.Abs(lastHSpeed-desiredVelocity.x));

        npc.npcAnimator.SetFloat("vSpeed",vSpeed);
        npc.npcAnimator.SetFloat("hSpeed",hSpeed);
    }

    private void handleSound() {
        countDown -= Time.deltaTime;
        if (countDown < 0) {
            npc.playPursueSound();
            countDown = UnityEngine.Random.Range(1.0f,3.0f);
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

    public void TouchedPlayer() {
        npc.npcAnimator.SetBool("sprinting", false);
        npc.player.caught = true;
        npc.alerted = false;
        ToSuspiciousState();
    }
}