using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {
    // External References
    public GameObject  shotPointer;                // Where the Projecile will shoot out of
    public GameObject  bullet;                     // Reference to the Bullet Shot
    public float       bulletSpeed = 20.0f;

    /**
     * Method that invokes a Shot in the direction
     *  of the Shot Pointer
     */
    public void Shoot() {
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
    }
}
