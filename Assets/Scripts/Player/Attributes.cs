using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attributes : MonoBehaviour {
    // External Settings
    public int health = 25;
    

    /**
     * Increases health by given increment
     */
    public void increaseHealth(int plus) {
        this.health += plus;
    }

    /**
     * Decreases health by given damage points
     */
    public void inflictDamage(int damageValue) {
        this.health -= damageValue;

        if (this.health <= 0) {
            this.die();
        }
    }

    // Sets health to given Amount
    public void setHealth(int newHealth) {
        this.health = newHealth;
    }

    // Kills GameObject ;(
    public void die() {
        Destroy(gameObject);
    }
}
