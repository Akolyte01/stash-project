//Team Hindenburg
//Jeffrey, Olivia, Scott, Stephanie

using UnityEngine;
using System.Collections;
using System;

public class PursueState : NPCState{
    private readonly NPC npc;
    private float secondsInAdvance = 3;
    GameObject player = GameObject.FindGameObjectWithTag("Player");

    public PursueState(NPC npc) {
        this.npc = npc;
    }

    public void UpdateState()
    {

        npc.npcAnimator.SetBool("sprinting", true);
        Vector3 finalPos = player.transform.position;
        Vector3 velocity = player.GetComponent<Rigidbody>().velocity;
        velocity *= secondsInAdvance;
        finalPos += velocity;

        npc.nav.SetDestination(finalPos);

        npc.nav.speed = 1.5f;
        
        npc.nav.updatePosition = false;
        npc.nav.updateRotation = true;

        npc.nav.nextPosition = npc.transform.position;
        
        Vector3 desiredVelocity = npc.transform.InverseTransformDirection(npc.nav.desiredVelocity.normalized);
        desiredVelocity.Normalize();

        float lastVSpeed = npc.npcAnimator.GetFloat("vSpeed");
        float lastHSpeed = npc.npcAnimator.GetFloat("hSpeed");

                
        float vSpeed = Mathf.Lerp(lastVSpeed, desiredVelocity.z, 1f * Time.deltaTime/Mathf.Abs(lastVSpeed-desiredVelocity.z));
        float hSpeed = Mathf.Lerp(lastHSpeed, desiredVelocity.x, 2 * Time.deltaTime/Mathf.Abs(lastHSpeed-desiredVelocity.x));

        npc.npcAnimator.SetFloat("vSpeed",vSpeed);
        npc.npcAnimator.SetFloat("hSpeed",hSpeed);
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
        Debug.Log("boop");
        npc.npcAnimator.SetBool("sprinting", false);
        npc.player.caught = true;
        ToIdleState();
    }
}