using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    // Settings
    public float movementSpeed = 4.0f;
    public float maxVelocity = 10.0f;
    public float jumpForce = 5.0f;


    // Internal References
    Rigidbody rbody;

    // Internal Key Presses
    private float   inputMoveHorz      = 0.0f;
    private float   inputMoveVert      = 0.0f;
    private bool    inputJump       = false;
    private bool    vertKeyDown     = false;


    // Store Internal Objects
    void Start() {
        rbody = GetComponent<Rigidbody>();
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
    }
    
    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "Floor" && vertKeyDown) {
            vertKeyDown = false;
        }
    }

    // Update is called once per frame
    void Update() {
        // Update Movement
        inputMoveHorz = Input.GetAxisRaw("Horizontal") * movementSpeed;
        inputMoveVert = Input.GetAxisRaw("Vertical") * movementSpeed;
        
        // Update Vertical Movement
        if (!vertKeyDown && (Input.GetAxisRaw("Jump") > 0)) {
            inputJump = true;
            vertKeyDown = true;
        }
    }
}
