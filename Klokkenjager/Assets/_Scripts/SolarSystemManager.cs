using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SolarSystemManager : MonoBehaviour {
    public static SolarSystemManager instance = null;

    public GameObject eToInteract;
    public GameObject cameraBase;
    public Camera solarCamera;

    public Material standardMat;
    public Material outlineMat;

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
    private bool solarSystemActive;
    private bool solarControls;
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
        if (solarSystemActive && solarControls){
            if (planetSelection == 0) {
                GameObject planet = GameObject.Find("Planet 1");
                planet.GetComponent<Renderer>().material = outlineMat;
                
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
                GameObject.Find("Planet 1").GetComponent<Renderer>().material = standardMat;
            }

            if (planetSelection == 1) {
                GameObject planet = GameObject.Find("Planet 2");
                planet.GetComponent<Renderer>().material = outlineMat;

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
                GameObject.Find("Planet 2").GetComponent<Renderer>().material = standardMat;
            }

            if (planetSelection == 2) {
                GameObject planet = GameObject.Find("Planet 3");
                planet.GetComponent<Renderer>().material = outlineMat;

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
                GameObject.Find("Planet 3").GetComponent<Renderer>().material = standardMat;
            }

            if (planetSelection == 3) {
                GameObject planet = GameObject.Find("Planet 4");
                planet.GetComponent<Renderer>().material = outlineMat;

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
                GameObject.Find("Planet 4").GetComponent<Renderer>().material = standardMat;
            }

            if (Input.GetKeyDown("w")) planetSelection += 1;
            if (Input.GetKeyDown("s")) planetSelection -= 1;      
            if (planetSelection >= 4) planetSelection = 0;
            if (planetSelection <= -1) planetSelection = 3;

            if (Input.GetKeyDown("d")) planetRotationSelection += 1;
            if (Input.GetKeyDown("a")) planetRotationSelection -= 1;
            if (planetRotationSelection >= 4) planetRotationSelection = 0;
            if (planetRotationSelection <= -1) planetRotationSelection = 3;
        }
            
    }

    // Update is called once per frame
    void LateUpdate() {
        var CameraFollowScript = cameraBase.GetComponent<CameraFollow>();
        if (lockOnSolarSystem && !cameraInPosition){
            eToInteract.SetActive(true);
            if (Input.GetKeyDown("e")) {

                playerController.enabled = false;
                player.GetComponent<Rigidbody>().velocity = Vector3.zero;
                solarControls = true;
               
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
            if (Input.GetKeyDown("q")) {

                solarControls = false;
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