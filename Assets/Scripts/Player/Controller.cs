using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {
    // Settings
    public float movementSpeed = 4.0f;
    public float maxVelocity = 10.0f;
    public float jumpForce = 5.0f;


    // Internal References
    Rigidbody rbody;
    Shooter shooter;
    Inventory inventory;

    // Internal Key Presses
    float   inputMoveHorz   = 0.0f;
    float   inputMoveVert   = 0.0f;
    bool    inputJump       = false;
    bool    vertKeyDown     = false;
    bool    shootBullet     = false;
    bool    cycleWeapons    = false;
    bool    plantSeed       = false;

    // Internal Data
    float rotationAngle = 0.0f;


    // Store Internal Objects
    void Start() {
        rbody = GetComponent<Rigidbody>();
//        shooter = GetComponent<Shooter>();
        inventory = GetComponent<Inventory>();
    }
    
    // Physics Update
    void FixedUpdate() {
        // Update Player Movement
        Vector3 pVel = rbody.velocity;
        float jumpForce = 0.0f;

        // Check Jump
        if (inputJump) {
            inputJump = false;
            jumpForce = this.jumpForce;
        }
        
        Vector3 playerForce = new Vector3(inputMoveHorz, jumpForce, inputMoveVert);

        // Apply Force!
        rbody.AddForce(playerForce);

        // Limit Velocity
        pVel.x = Mathf.Clamp(pVel.x, -maxVelocity, maxVelocity);
        pVel.z = Mathf.Clamp(pVel.z, -maxVelocity, maxVelocity);
        rbody.velocity = pVel;


        // Update Rotation Angle with Offset
        transform.rotation =  Quaternion.AngleAxis(rotationAngle - 90.0f, Vector3.down);

        // Shoot Bullet!
        if ( shootBullet ) {
//            shooter.Shoot();
            inventory.Shoot();
            shootBullet = false;
        }

        if ( cycleWeapons ) {
            inventory.cycleWeapons();
            cycleWeapons = false;
        }

        if ( plantSeed ) {
            plantSeed = false;
            if (!vertKeyDown) {
                inventory.plantSeed(inventory.currentSeed);
            }
        }
    }
    
    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "Floor" && vertKeyDown) {
            vertKeyDown = false;
        }
    }

    // Update is called once per frame
    void LateUpdate() {
        // Update Movement
        inputMoveHorz = Input.GetAxisRaw("Horizontal") * movementSpeed;
        inputMoveVert = Input.GetAxisRaw("Vertical") * movementSpeed;
        
        // Update Vertical Movement
        if (!vertKeyDown && (Input.GetAxisRaw("Jump") > 0)) {
            inputJump = true;
            vertKeyDown = true;
        }

        // Fire Input
        if (!shootBullet && Input.GetButton("Fire1")) {
            shootBullet = true;
        }

        if (!cycleWeapons && Input.GetButtonDown("Fire2")) {
            cycleWeapons = true;
        }

        if (!plantSeed && Input.GetButtonDown("Fire3")) {
            plantSeed = true;
        }

        Vector3 dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        rotationAngle = Mathf.Atan2( dir.y, dir.x ) * Mathf.Rad2Deg;
    }
}
