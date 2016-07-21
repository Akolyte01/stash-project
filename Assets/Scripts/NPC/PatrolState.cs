//Team Hindenburg
//Jeffrey, Olivia, Scott, Stephanie
using UnityEngine;
using System.Collections;

public class PatrolState : NPCState {
    private readonly NPC npc;

	private float idleChecker;
    private int curWaypoint = 0;


    public PatrolState(NPC npc) {
        this.npc = npc;
    }


    public void UpdateState()
    {

        checkSuspicious();
        checkAlerted();
	
		//every 5 second or so, check to enter idle
		idleChecker += Time.deltaTime;
		if (idleChecker > 5.0f) {
			idleChecker = 0f;
			checkIdleChance();
		}

        Patrolling();

    }

    public void Patrolling()
    {
        // Set the ai agents movement speed to patrol speed
        npc.nav.speed = npc.walkSpeed;
        // Create two Vector3 variables, one to buffer the ai agents local position, the other to
        // buffer the next waypoints position
        Vector3 tempLocalPosition;
        Vector3 tempWaypointPosition;

        // Agents position (x, set y to 0, z)
        tempLocalPosition = npc.transform.position;
        tempLocalPosition.y = 0f;

        // Current waypoints position (x, set y to 0, z)
        tempWaypointPosition = npc.waypoints[curWaypoint].position;
        tempWaypointPosition.y = 0f;

        // Is the distance between the agent and the current waypoint within the minWaypointDistance?
        if (Vector3.Distance(tempLocalPosition, tempWaypointPosition) <= npc.minWaypointDistance)
        {
            // Have we reached the last waypoint?
            if (curWaypoint == npc.maxWaypoint)
                // If so, go back to the first waypoint and start over again
                curWaypoint = 0;
            else
                // If we haven't reached the Last waypoint, just move on to the next one
                curWaypoint++;
        }

        // Set the destination for the agent
        // The navmesh agent is going to do the rest of the work
        npc.nav.SetDestination(npc.waypoints[curWaypoint].position);
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
            npc.npcAnimator.SetBool("alert", true);
            ToPursueState();
        }
    }

	private void checkIdleChance() {
		if (npc.idleChance > 0) {
			float chance = Random.Range(0f,100f);
			if (npc.idleChance > chance) {
                npc.npcAnimator.SetBool("idle", true);
                npc.nav.velocity = new Vector3(0,0,0);
                ToIdleState ();
			}
		}
	}

    public void TouchedPlayer() { }
}
