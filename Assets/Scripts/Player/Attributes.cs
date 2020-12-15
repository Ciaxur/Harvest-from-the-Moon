using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Attributes : MonoBehaviour {
    // External Settings
    public int health = 25;
    public int maxHealth = 25;
    public bool isPlayer = false;           // If Main Player
    public Image healthBar;                 // Modify fill to set bar
   

    /**
     * Increases health by given increment
     */
    public void increaseHealth(int plus) {
        this.health += plus;
        healthBar.fillAmount = (float)health / (float)maxHealth;
        if (health > maxHealth) {
            health = maxHealth;
        }
    }

    /**
     * Decreases health by given damage points
     */
    public void inflictDamage(int damageValue) {
        this.health -= damageValue;

        if (healthBar) {
            healthBar.fillAmount = (float)health / maxHealth;
        }
        
        if (this.health <= 0) {
            this.die();
        } 
    }

    // Sets health to given Amount
    public void setHealth(int newHealth) {
        this.health = newHealth;
        healthBar.fillAmount = (float)health / (float)maxHealth;
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
