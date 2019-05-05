using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SolarSystemManager : MonoBehaviour {

    public GameObject eToInteract;
    public GameObject cameraBase;
    public Camera solarCamera;

    [System.NonSerialized]
    public bool lockOnP1;
    [System.NonSerialized]
    public bool lockOnP2;
    [System.NonSerialized]
    public bool lockOnP3;
    [System.NonSerialized]
    public bool lockOnP4;

    public bool cameraInPosition;

    [System.NonSerialized]
    public bool lockOnSolarSystem;

    private CharacterControls playerController;

    // Start is called before the first frame update
    void Start() {
        Camera.main.enabled = true;
        solarCamera.enabled = false;

        playerController = FindObjectOfType<CharacterControls>();
    }

    // Update is called once per frame
    void Update() {
        var CameraFollowScript = cameraBase.GetComponent<CameraFollow>();
        if (lockOnSolarSystem){
            eToInteract.SetActive(true);
            if (Input.GetKeyDown("e")) {
               
                solarCamera.enabled = !solarCamera.enabled;
                cameraBase.SetActive(false);

                cameraInPosition = true;

                Cursor.lockState = CursorLockMode.None;
		        Cursor.visible = true;
            }
        }
        else {
            eToInteract.SetActive(false);
        }

        if (cameraInPosition) {
                // Reset the camera after the player is done with the solar system.
                if (Input.GetKeyDown("o")){

                    solarCamera.enabled = !solarCamera.enabled;
                    cameraBase.SetActive(true);

                    cameraInPosition = false;

                    Cursor.lockState = CursorLockMode.Locked;
		            Cursor.visible = false;
                }
            }
        if (lockOnP1) {

        }
    }
}