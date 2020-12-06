using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChaseObject : MonoBehaviour {
    // External References & Settings
    public GameObject target;                    // Reference to the Object to Chase
    
    // Internal References
    NavMeshAgent navMeshAgent;
    
    void Start() {
        // Validate Object Reference Given
        if (!target) {
            // Try and find the Player
            target = GameObject.FindGameObjectWithTag("Player");
            
            if (!target)
                Debug.LogAssertion("ChaseObject: No Reference Object to Chase");
        }

        // Find Navmesh Agent
        navMeshAgent = GetComponent<NavMeshAgent>();
        if (!navMeshAgent) {
            Debug.LogAssertion("ChaseObject: No NavMeshAgent Component");
            Debug.DebugBreak();
        }
    }

    // Update the Target
    void FixedUpdate() {
        navMeshAgent.SetDestination( target.transform.position );
    }
    
}
