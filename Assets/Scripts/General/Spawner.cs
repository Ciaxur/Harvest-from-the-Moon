using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    // Public Settings
    public GameObject   entity;               // Entity to Spawn
    [Range(0.0f, 1.0f)]
    public float        spawnRate = 0.5f;     // Percentage Likelyhood of Spawning
    [Range(0, 100)]
    public int          total = 10;           // Total Entities to spawn
    [Range(0.0f, 10.0f)]
    public float        interval = 1.0f;      // Second Interval Checks
    

    void Start() {
        if (!entity) {
            Debug.LogError("Spawner: No Entity to Spawn");
            Debug.Break();
        }
    }


    // Spawn Checks & Issue Spawn
    float lastSpawn = 0.0f;             // Keep track of when last spawn was
    int totalEntities = 0;
    
    void Update() {
        if (Time.time - lastSpawn >= interval) {
            lastSpawn = Time.time;

            // Spawn the Object
            if (Random.Range(0.0f, 1.0f) > spawnRate) {
                Instantiate(entity, transform.position, Quaternion.identity);
                totalEntities++;
            }

            // End?
            if (totalEntities >= total) {
                Destroy(this.gameObject);
            }
        }
    }
}
