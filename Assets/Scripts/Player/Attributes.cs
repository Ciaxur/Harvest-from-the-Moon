using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attributes : MonoBehaviour {
    // External Settings
    public int health = 25;
    public bool isPlayer = false;           // If Main Player
    

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
        if (isPlayer) {
            World world = FindObjectOfType<World>();    // Should only be One
            world.GameOver();
        }
        else {
            // Indicate to world your death :(
            World world = FindObjectOfType<World>();
            world.totalEnemies--;
            Destroy(gameObject);
        }
    }
}
