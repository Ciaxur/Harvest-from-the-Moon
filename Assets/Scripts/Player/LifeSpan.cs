using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeSpan : MonoBehaviour {
    
    // External
    public float secondsTillDeath = 5.0f;
    
    // Internal
    float creationTime;
    
    // Store Init Time
    void Start() {
        creationTime = Time.time;
    }

    // DEATH after Life Span runs out
    void Update() {
        if (Time.time - creationTime >= secondsTillDeath) {
            Destroy(this.gameObject);
        }
    }
}
