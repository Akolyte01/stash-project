using UnityEngine;
using System.Collections;

public interface NPCState{
    void UpdateState();

    void ToPatrolState();

    void ToSuspiciousState();

    void ToPursueState();

    void ToIdleState();
}
