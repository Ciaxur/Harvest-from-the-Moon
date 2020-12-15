using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {
    // External Properties
    public int damage = 1;                                  // Hit damage
    [Range(0.0f, 5.0f)] public float hitRate = 1.0f;        // Every x Seconds

    // Internal State
    float lastHit = 0f;     // Keep track of when last hit was    
    
    
    void OnCollisionEnter(Collision other) {
        // Enemy Collided with Player
        if (other.transform.tag == "Player") {
            float currTime = Time.time;
            if (currTime - lastHit >= hitRate) {
                Attributes attrib = other.transform.GetComponent<Attributes>();
                attrib.inflictDamage(damage);
                lastHit = currTime;
            }
        }
    }
}
