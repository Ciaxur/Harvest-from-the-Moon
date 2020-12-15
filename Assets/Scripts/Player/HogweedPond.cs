using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HogweedPond : MonoBehaviour {
    // External Settings
    public int damage = 1;
    public float impulseAmount = 400;

    private Dictionary<GameObject, float> enemies;

    void Start() {
        enemies = new Dictionary<GameObject, float>();
    }

    void OnTriggerEnter(Collider other) {
        // Collided with Enemy
        if (other.tag == "Enemy") {
            enemies.Add(other.gameObject, 0.0f);
        }
    }

    void OnTriggerStay(Collider other) {
        if (other.tag == "Enemy") {
            float newValue = enemies[other.gameObject] + Time.deltaTime;
            if (newValue > .2f && newValue * damage >= 1.0f)
            {
                other.GetComponent<Attributes>().inflictDamage((int) (newValue * damage));
                newValue -= (int) newValue;
                other.GetComponent<Rigidbody>().AddForce(new Vector3(0, impulseAmount, 0), ForceMode.Impulse);
            }
            enemies[other.gameObject] = newValue;
        }
    }

    void OnTriggerExit(Collider other) {
        if (other.tag == "Enemy") {
            int remainingDamage = (int) (enemies[other.gameObject] * damage);
            if (remainingDamage >= 1)
            {
                other.GetComponent<Attributes>().inflictDamage(remainingDamage);
            }
            enemies.Remove(other.gameObject);
        }
    }
}
