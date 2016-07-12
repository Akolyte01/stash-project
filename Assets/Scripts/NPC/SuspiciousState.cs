using UnityEngine;
using System.Collections;

public class SuspiciousState : NPCState
{
    private readonly NPC npc;

    public SuspiciousState(NPC npc) {
        this.npc = npc;
    }

    public void UpdateState()
    {
        Debug.Log("suspicious");
        checkLOS();
        checkAlerted();
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
}
