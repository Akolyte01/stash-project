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
        idleChecker -= Time.deltaTime;
        if (idleChecker <= 0.0f) {
            idleChecker = Random.Range(1.0f,5.0f);
            checkIdleChance();
        }

        Patrolling();

    }


    public void Patrolling()
    {
        npc.nav.SetDestination(npc.waypoints[curWaypoint].position);

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
        
        //Debug.Log(npc);
        //Debug.Log(vSpeed);
        //Debug.Log(hSpeed);

        //// Create two Vector3 variables, one to buffer the ai agents local position, the other to
        //// buffer the next waypoints position
        Vector3 tempLocalPosition;
        Vector3 tempWaypointPosition;

        // Agents position (x, set y to 0, z)
        tempLocalPosition = npc.transform.position;
        tempLocalPosition.y = 0f;

        // Current waypoints position (x, set y to 0, z)
        tempWaypointPosition = npc.waypoints[curWaypoint].position;
        tempWaypointPosition.y = 0f;

        // Is the distance between the agent and the current waypoint within the minWaypointDistance?
        if (Vector3.Distance(tempLocalPosition, tempWaypointPosition) <= npc.minWaypointDistance) {
            // Have we reached the last waypoint?
            if (curWaypoint == npc.maxWaypoint)
                // If so, go back to the first waypoint and start over again
                curWaypoint = 0;
            else
                // If we haven't reached the Last waypoint, just move on to the next one
                curWaypoint++;

            if (npc.pausesAtWaypoints)
                ToIdleState();
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

                ToIdleState ();
			}
		}
	}

    public void TouchedPlayer() { }
}
