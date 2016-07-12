using UnityEngine;
using System.Collections;

public class IdleState : NPCState{
    private readonly NPC npc;

    private float idleTimer;

    public IdleState(NPC npc) {
        this.npc = npc;
    }

    public void UpdateState()
    {
        Debug.Log("Idle");
        idleTimer += Time.deltaTime;
        if (idleTimer > 4.0f) {
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
}