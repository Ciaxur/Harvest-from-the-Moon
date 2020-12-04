using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseObject : MonoBehaviour {
    // External References & Settings
    public GameObject target;                    // Reference to the Object to Chase
    public float velocity = 5.0f;               // Speed of the Object
    
    // Internal References

    // TODO: A* Path
    // Vector3 getChasePath() { }


    void Start() {
        // Validate Object Reference Given
        if (!target) {
            // Try and find the Player
            target = GameObject.FindGameObjectWithTag("Player");
            
            if (!target)
                Debug.LogAssertion("ChaseObject: No Reference Object to Chase");
        }
    }

     void Update() {
         // Chase that Path
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, velocity * Time.deltaTime);
     }
    
}
