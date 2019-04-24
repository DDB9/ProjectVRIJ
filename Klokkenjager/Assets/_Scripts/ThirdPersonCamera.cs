using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour {

    private const float Y_ANGLE_MIN = -5.0f;
    private const float Y_ANGLE_MAX = 75.0f;

    public Transform lookAt;
    public Transform cameraTransform;
    public GameObject player;

    private Camera cam;

    private float distance = 10.0f;
    private float currentX = 0.0f;
    private float currentY = 0.0f;
    private float sensitivityX = 4.0f;
    private float sensitivityY = 1.0f;

    private void Start() {
        Cursor.lockState = CursorLockMode.Locked;
        
        cameraTransform = transform;
        cam = Camera.main;
    }

    private void Update() {
        currentX += Input.GetAxis("Mouse X") * sensitivityX;
        currentY -= Input.GetAxis("Mouse Y") * sensitivityY;

        currentY = Mathf.Clamp(currentY, Y_ANGLE_MIN, Y_ANGLE_MAX);
    }

    void LateUpdate() {
        Vector3 direction = new Vector3(0, 0, -distance);
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
        player.transform.rotation = Quaternion.Euler(0, currentX, 0);
        cameraTransform.position = lookAt.position + rotation * direction;
        cameraTransform.LookAt(lookAt.position);
    }
}
