﻿using UnityEngine;
using System.Collections;

public class PursueState : NPCState{
    private readonly NPC npc;
    private float secondsInAdvance = 3;
    GameObject player = GameObject.FindGameObjectWithTag("Player");

    public PursueState(NPC npc) {
        this.npc = npc;
    }

    public void UpdateState()
    {
        Vector3 finalPos = player.transform.position;
        Vector3 velocity = player.GetComponent<Rigidbody>().velocity;
        velocity *= secondsInAdvance;
        finalPos += velocity;

        npc.nav.SetDestination(finalPos);
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
}