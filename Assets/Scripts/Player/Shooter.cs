using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {
    // External References
    public GameObject  shotPointer;                // Where the Projecile will shoot out of
    public GameObject  bullet;                     // Reference to the Bullet Shot
    public float       bulletSpeed = 20.0f;
    public float       minCooldownTime;
    public float       cooldownIncrease;
    public float       currentCooldownDecrease;
    public float       stashedCooldownDecrease;

    public bool        isCurrentWeapon;

    private float      currentCooldownTime;
    private float      cooldown;

    void Start() {
        currentCooldownTime = minCooldownTime;
        cooldown = 0.0f;
    }

    void Update() {
        if (cooldown >= 0.0f) {
            cooldown -= Time.deltaTime;
        }
        if (currentCooldownTime > minCooldownTime) {
            currentCooldownTime = System.Math.Max(minCooldownTime, currentCooldownTime
		 - (isCurrentWeapon ? currentCooldownDecrease
                                    : stashedCooldownDecrease));
        }
    }

    /**
     * Method that invokes a Shot in the direction
     *  of the Shot Pointer
     */
    public void Shoot() {
        if (cooldown <= 0.0f) {
            // Create Object
            GameObject gameObject = Instantiate(bullet, shotPointer.transform.position, shotPointer.transform.rotation);
        
            // Get RigidBody
            Rigidbody rb = gameObject.GetComponent<Rigidbody>();

            // Verify RigidBody Exists
            if (!rb) {
                Debug.LogAssertion("Shooter: Bullet does not have a Rigidbody Component");
            }

            // Send it!!
            rb.velocity = shotPointer.transform.TransformDirection( new Vector3(0, 0, bulletSpeed) );

            cooldown = currentCooldownTime;
            currentCooldownTime += cooldownIncrease;
        }
    }

    public void setCurrent(bool cur) {
        isCurrentWeapon = cur;
    }
}
