using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    // External Settings
    public int damage = 1;
    public bool persist = false;

    void OnTriggerEnter(Collider other) {
        // Collided with Enemy
        if (other.tag == "Enemy") {
            Attributes attrb = other.GetComponent<Attributes>();
            attrb.inflictDamage(damage);
        }

        // DIE
        if (!persist) {
            Destroy(gameObject);
        }
    }
    
}
