using UnityEngine;
using System.Collections;

public class PursueState : NPCState{
    private readonly NPC npc;

    public PursueState(NPC npc) {
        this.npc = npc;
    }

    public void UpdateState()
    {
        Debug.Log("Pursue");
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