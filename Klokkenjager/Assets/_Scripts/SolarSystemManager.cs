using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SolarSystemManager : MonoBehaviour {

    public static SolarSystemManager instance = null;

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

    public Transform[] planetRotations;
    public float rotationSpeed;

    [System.NonSerialized]
    public bool lockOnSolarSystem;

    private CharacterControls playerController;
    private GameObject player;
    private bool solarSystemActive = false;
    private int planetSelection;
    private int planetRotationSelection;

    // Start is called before the first frame update
    void Start() {
        Camera.main.enabled = true;
        solarCamera.enabled = false;

        playerController = FindObjectOfType<CharacterControls>();
        player = GameObject.Find("Player");
    }

    void Update() {
        if (solarSystemActive){
            Material planetOneMaterial = GameObject.Find("Planet 1").GetComponent<Renderer>().material;
            Material planetTwoMaterial = GameObject.Find("Planet 2").GetComponent<Renderer>().material;
            Material planetThreeMaterial = GameObject.Find("Planet 3").GetComponent<Renderer>().material;
            Material planetFourMaterial = GameObject.Find("Planet 4").GetComponent<Renderer>().material;

            if (planetSelection == 0) {
                GameObject planet = GameObject.Find("Planet 1");
                
                if (planetRotationSelection == 0) planet.transform.rotation = Quaternion.Slerp(planet.transform.rotation, 
                                                                                               planetRotations[0].rotation, 
                                                                                               Time.deltaTime * rotationSpeed);
                if (planetRotationSelection == 1) planet.transform.rotation = Quaternion.Slerp(planet.transform.rotation, 
                                                                                               planetRotations[1].rotation, 
                                                                                               Time.deltaTime * rotationSpeed);
                if (planetRotationSelection == 2) planet.transform.rotation = Quaternion.Slerp(planet.transform.rotation, 
                                                                                               planetRotations[2].rotation, 
                                                                                               Time.deltaTime * rotationSpeed);
                if (planetRotationSelection == 3) planet.transform.rotation = Quaternion.Slerp(planet.transform.rotation, 
                                                                                               planetRotations[3].rotation, 
                                                                                               Time.deltaTime * rotationSpeed);
            }
            else {
                planetOneMaterial.color = Color.gray; // Doesn't work yet.
            }
            if (planetSelection == 1) {
                GameObject planet = GameObject.Find("Planet 2");
                
                if (planetRotationSelection == 0) planet.transform.rotation = Quaternion.Slerp(planet.transform.rotation, 
                                                                                               planetRotations[0].rotation, 
                                                                                               Time.deltaTime * rotationSpeed);
                if (planetRotationSelection == 1) planet.transform.rotation = Quaternion.Slerp(planet.transform.rotation, 
                                                                                               planetRotations[1].rotation, 
                                                                                               Time.deltaTime * rotationSpeed);
                if (planetRotationSelection == 2) planet.transform.rotation = Quaternion.Slerp(planet.transform.rotation, 
                                                                                               planetRotations[2].rotation, 
                                                                                               Time.deltaTime * rotationSpeed);
                if (planetRotationSelection == 3) planet.transform.rotation = Quaternion.Slerp(planet.transform.rotation, 
                                                                                               planetRotations[3].rotation, 
                                                                                               Time.deltaTime * rotationSpeed);
            }
            if (planetSelection == 2) {
                GameObject planet = GameObject.Find("Planet 3");

                if (planetRotationSelection == 0) planet.transform.rotation = Quaternion.Slerp(planet.transform.rotation, 
                                                                                               planetRotations[0].rotation, 
                                                                                               Time.deltaTime * rotationSpeed);
                if (planetRotationSelection == 1) planet.transform.rotation = Quaternion.Slerp(planet.transform.rotation, 
                                                                                               planetRotations[1].rotation, 
                                                                                               Time.deltaTime * rotationSpeed);
                if (planetRotationSelection == 2) planet.transform.rotation = Quaternion.Slerp(planet.transform.rotation, 
                                                                                               planetRotations[2].rotation, 
                                                                                               Time.deltaTime * rotationSpeed);
                if (planetRotationSelection == 3) planet.transform.rotation = Quaternion.Slerp(planet.transform.rotation, 
                                                                                               planetRotations[3].rotation, 
                                                                                               Time.deltaTime * rotationSpeed);
            }
            if (planetSelection == 3) {
                GameObject planet = GameObject.Find("Planet 4");

                if (planetRotationSelection == 0) planet.transform.rotation = Quaternion.Slerp(planet.transform.rotation, 
                                                                                               planetRotations[0].rotation, 
                                                                                               Time.deltaTime * rotationSpeed);
                if (planetRotationSelection == 1) planet.transform.rotation = Quaternion.Slerp(planet.transform.rotation, 
                                                                                               planetRotations[1].rotation, 
                                                                                               Time.deltaTime * rotationSpeed);
                if (planetRotationSelection == 2) planet.transform.rotation = Quaternion.Slerp(planet.transform.rotation, 
                                                                                               planetRotations[2].rotation, 
                                                                                               Time.deltaTime * rotationSpeed);
                if (planetRotationSelection == 3) planet.transform.rotation = Quaternion.Slerp(planet.transform.rotation, 
                                                                                               planetRotations[3].rotation, 
                                                                                               Time.deltaTime * rotationSpeed);
            }

            if (Input.GetKeyDown("w")) planetSelection += 1;
            if (Input.GetKeyDown("s")) planetSelection -= 1;      
            if (planetSelection >= 4) planetSelection = 0;
            if (planetSelection <= -1) planetSelection = 3;

            if (Input.GetKeyDown("d")) planetRotationSelection += 1;
            if (Input.GetKeyDown("a")) planetRotationSelection -= 1;
            if (planetRotationSelection >= 4) planetRotationSelection = 0;
            if (planetRotationSelection <= -1) planetRotationSelection = 3;

            Debug.Log(planetSelection);
        }
            
    }

    // Update is called once per frame
    void LateUpdate() {
        var CameraFollowScript = cameraBase.GetComponent<CameraFollow>();
        if (lockOnSolarSystem && cameraInPosition == false){
            eToInteract.SetActive(true);
            if (Input.GetKeyDown("e")) {

                player.transform.position = player.transform.position;
                playerController.enabled = false;
               
                solarCamera.enabled = !solarCamera.enabled;
                cameraBase.SetActive(false);

                cameraInPosition = true;

                Cursor.lockState = CursorLockMode.None;
		        Cursor.visible = true;

                solarSystemActive = true;
            }
        }
        else {
            eToInteract.SetActive(false);
        }

        if (cameraInPosition) {
            // Reset the camera after the player is done with the solar system.
            if (Input.GetKeyDown(KeyCode.Return)){

                playerController.enabled = true;

                solarCamera.enabled = !solarCamera.enabled;
                cameraBase.SetActive(true);

                cameraInPosition = false;

                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }
    }
}