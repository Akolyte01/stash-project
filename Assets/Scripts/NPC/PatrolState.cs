using UnityEngine;
using System.Collections;

public class PatrolState : NPCState {
    private readonly NPC npc;

    public PatrolState(NPC npc) {
        this.npc = npc;
    }


    public void UpdateState()
    {
        Debug.Log("Patrol");
        checkSuspicious();
        checkAlerted();
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
