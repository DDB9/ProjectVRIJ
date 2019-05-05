using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]

public class CharacterControls : MonoBehaviour {

    public static CharacterControls instance = null;

    public Camera mainCamera;
    public float speed = 7.0f;
    public float gravity = 20.0f;
    public float maxVelocityChange = 10.0f;
    public bool canJump = true;
    public float jumpHeight = 1.0f;

    private bool grounded = false;
    private float sprintSpeed;
    private float walkSpeed;
    private SolarSystemManager solarSystem;

    void Awake() {
        sprintSpeed = speed * 1.75f;
        GetComponent<Rigidbody>().freezeRotation = true;
        GetComponent<Rigidbody>().useGravity = false;
        walkSpeed = speed;

        solarSystem = FindObjectOfType<SolarSystemManager>();   
    }

    private void Update() {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, mainCamera.transform.TransformDirection(Vector3.forward), out hit)) {
            if (hit.collider.CompareTag("Planet") && solarSystem.cameraInPosition == false) {
                solarSystem.lockOnSolarSystem = true;

                if (Input.GetMouseButton(0) && solarSystem.cameraInPosition) {
                    if (hit.collider.name == "Planet1") {
                        solarSystem.lockOnP1 = true;
                    }
                    if (hit.collider.name == "Planet2") {
                        solarSystem.lockOnP2 = true;
                    }
                    if (hit.collider.name == "Player3") {
                        solarSystem.lockOnP3 = true;
                    }
                    if (hit.collider.name == "Planet4") {
                        solarSystem.lockOnP4 = true;
                    }
                }
                else {
                    solarSystem.lockOnP1 = false;
                    solarSystem.lockOnP2 = false;
                    solarSystem.lockOnP3 = false;
                    solarSystem.lockOnP4 = false;
                }
            }
            else {
                solarSystem.lockOnSolarSystem = false;
            }
        }
    }

    void FixedUpdate() {
        if (grounded) {
            // Calculate how fast we should be moving
            Vector3 targetVelocity = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            targetVelocity = transform.TransformDirection(targetVelocity);
            targetVelocity *= speed;
           
            // Apply a force that attempts to reach our target velocity
            Vector3 velocity = GetComponent<Rigidbody>().velocity;
            Vector3 velocityChange = (targetVelocity - velocity);
            velocityChange.x = Mathf.Clamp(velocityChange.x, -maxVelocityChange, maxVelocityChange);
            velocityChange.z = Mathf.Clamp(velocityChange.z, -maxVelocityChange, maxVelocityChange);
            velocityChange.y = 0;
            GetComponent<Rigidbody>().AddForce(velocityChange, ForceMode.VelocityChange);

            // Jump
            if (canJump && Input.GetButton("Jump")) {
                GetComponent<Rigidbody>().velocity = new Vector3(velocity.x, CalculateJumpVerticalSpeed(), velocity.z);
            }
        }

        // We apply gravity manually for more tuning control
        GetComponent<Rigidbody>().AddForce(new Vector3(0, -gravity * GetComponent<Rigidbody>().mass, 0));

        grounded = false;
    }

    void OnCollisionStay() {
        grounded = true;
    }

    float CalculateJumpVerticalSpeed() {
        // From the jump height and gravity we deduce the upwards speed 
        // for the character to reach at the apex.
        return Mathf.Sqrt(2 * jumpHeight * gravity);
    }
}