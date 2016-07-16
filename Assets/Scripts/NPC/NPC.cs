﻿//Team Hindenburg
//Jeffrey, Olivia, Scott, Stephanie

using UnityEngine;
using System.Collections;

[RequireComponent (typeof(NavMeshAgent))]
public class NPC : MonoBehaviour {


    public Animator npcAnimator;
    public float perceptionDistance;
    public float fieldOfView;
    public float walkSpeed;
    public float penaltyMult;
    public bool willPursue;
    public float idleChance; //should be between 0 and 100
    public Transform[] waypoints;

    public float minWaypointDistance = 0.1f;

    public Player player;


    [HideInInspector] public NPCState currentState;
    [HideInInspector] public PatrolState patrolState;
    [HideInInspector] public IdleState idleState;
    [HideInInspector] public PursueState pursueState;
    [HideInInspector] public SuspiciousState suspiciousState;

    [HideInInspector] public bool alerted;
    [HideInInspector] public bool suspicious;
    [HideInInspector] public NavMeshAgent nav;
    [HideInInspector] public int maxWaypoint;


    // Use this for initialization
    void Awake() {
        patrolState = new PatrolState(this);
        idleState = new IdleState(this);
        pursueState = new PursueState(this);
        suspiciousState = new SuspiciousState(this);

        nav = GetComponent<NavMeshAgent>();
        maxWaypoint = waypoints.Length - 1;
        npcAnimator = GetComponent<Animator>();
    }

    void Start() {
        currentState = patrolState;
        alerted = false;
    }
	
	// Update is called once per frame
	void Update () {
	    currentState.UpdateState();
	}

    // returns -1 if no sight to object, otherwise returns distance to object.
    public float CanSee(GameObject theObject)
    {
        Vector3 vectorToObject = (theObject.transform.position + (1.6f * Vector3.up)) - (transform.position + (1.6f * Vector3.up));
        Vector3 outerPoint = transform.position + (1.6f * Vector3.up) + (.25f * vectorToObject.normalized);
        float angle = Vector3.Angle(transform.forward, vectorToObject);
        RaycastHit hit;
        if(-fieldOfView / 2.0f < angle && angle < fieldOfView / 2.0f)
        {
            
            if (Physics.Raycast(outerPoint, vectorToObject, out hit, perceptionDistance))
            {
                Transform rootTransform = hit.transform;
                while(rootTransform.parent != null)
                {
                    rootTransform = rootTransform.parent;
                }

                if (rootTransform.gameObject == theObject)
                {
                    Debug.DrawRay(outerPoint,vectorToObject);
                    return hit.distance;
                    
                } else { Debug.Log(rootTransform.gameObject); } 
            }
        }
        Debug.DrawRay(outerPoint,vectorToObject,Color.white, 99, false);
        return -1.0f;
    }

    public float CanSeePlayer() {
        return CanSee(player.gameObject);
    }

    public float getPenalty()
    {
        return penaltyMult;
    }

}
