using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SolarSystemManager : MonoBehaviour {
    public static SolarSystemManager instance = null;

    public GameObject eToInteract;
    public GameObject cameraBase;
    public Camera solarCamera;

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
    private bool ranOnce;
    private int planetSelection;
    private int planetRotationSelection;
    private int currentPlanetRotation1;
    private int currentPlanetRotation2;
    private int currentPlanetRotation3;
    private int currentPlanetRotation4;

    private Material planetOneMat, planetTwoMat, planetThreeMat, planetFourMat;


    // Start is called before the first frame update
    void Start() {
        Camera.main.enabled = true;
        solarCamera.enabled = false;

        playerController = FindObjectOfType<CharacterControls>();
        player = GameObject.Find("Kronos");

        planetOneMat = GameObject.Find("Planet 1").transform.GetChild(1).GetComponent<Renderer>().material;
        planetTwoMat = GameObject.Find("Planet 2").transform.GetChild(1).GetComponent<Renderer>().material;
        planetThreeMat = GameObject.Find("Planet 3").transform.GetChild(1).GetComponent<Renderer>().material;
        planetFourMat = GameObject.Find("Planet 4").transform.GetChild(1).GetComponent<Renderer>().material;
    }

    void Update() {
        if (solarSystemActive && solarControls){
            if (planetSelection == 0) {
                GameObject planet = GameObject.Find("Planet 1");
                planet.transform.GetChild(1).GetComponent<Renderer>().material = outlineMat; // change selection material for  selected planet.

                if (!ranOnce) { // check if current planet rotation has been assigned.
                    planetRotationSelection = currentPlanetRotation1;
                    ranOnce = true;
                }

                if (planetRotationSelection == 0) {
                    planet.transform.rotation = Quaternion.Slerp(planet.transform.rotation,
                                                                 planetRotations[0].rotation,
                                                                 Time.deltaTime * rotationSpeed);
                    currentPlanetRotation1 = planetRotationSelection;
                }

                if (planetRotationSelection == 1) {
                    planet.transform.rotation = Quaternion.Slerp(planet.transform.rotation,
                                                                 planetRotations[1].rotation,
                                                                 Time.deltaTime * rotationSpeed);
                    currentPlanetRotation1 = planetRotationSelection;
                }
                if (planetRotationSelection == 2) {
                    planet.transform.rotation = Quaternion.Slerp(planet.transform.rotation,
                                                                 planetRotations[2].rotation,
                                                                 Time.deltaTime * rotationSpeed);
                    currentPlanetRotation1 = planetRotationSelection;
                }
                if (planetRotationSelection == 3) {
                    planet.transform.rotation = Quaternion.Slerp(planet.transform.rotation,
                                                                 planetRotations[3].rotation,
                                                                 Time.deltaTime * rotationSpeed);
                    currentPlanetRotation1 = planetRotationSelection;
                }
            }
            else {
                GameObject.Find("Planet 1").transform.GetChild(1).GetComponent<Renderer>().material = planetTwoMat;
            }

            if (planetSelection == 1) {
                GameObject planet = GameObject.Find("Planet 2");
                planet.transform.GetChild(1).GetComponent<Renderer>().material = outlineMat; // change selection material for  selected planet.

                if (!ranOnce) { // check if current planet rotation has been assigned.
                    planetRotationSelection = currentPlanetRotation2;
                    ranOnce = true;
                }

                if (planetRotationSelection == 0){
                    planet.transform.rotation = Quaternion.Slerp(planet.transform.rotation, 
                                                                 planetRotations[0].rotation, 
                                                                 Time.deltaTime * rotationSpeed);
                    currentPlanetRotation2 = planetRotationSelection;
                }

                if (planetRotationSelection == 1) {
                    planet.transform.rotation = Quaternion.Slerp(planet.transform.rotation,
                                                                 planetRotations[1].rotation,
                                                                 Time.deltaTime * rotationSpeed);
                    currentPlanetRotation2 = planetRotationSelection;
                }
                if (planetRotationSelection == 2) {
                    planet.transform.rotation = Quaternion.Slerp(planet.transform.rotation,
                                                                 planetRotations[2].rotation,
                                                                 Time.deltaTime * rotationSpeed);
                    currentPlanetRotation2 = planetRotationSelection;
                }
                if (planetRotationSelection == 3) {
                    planet.transform.rotation = Quaternion.Slerp(planet.transform.rotation,
                                                                 planetRotations[3].rotation,
                                                                 Time.deltaTime * rotationSpeed);
                    currentPlanetRotation2 = planetRotationSelection;
                }
            }
            else {
                GameObject.Find("Planet 2").transform.GetChild(1).GetComponent<Renderer>().material = planetTwoMat;
            }

            if (planetSelection == 2) {
                GameObject planet = GameObject.Find("Planet 3");
                planet.transform.GetChild(1).GetComponent<Renderer>().material = outlineMat;

                if (!ranOnce) {
                    planetRotationSelection = currentPlanetRotation3;
                    ranOnce = true;
                }

                if (planetRotationSelection == 0) {
                    planet.transform.rotation = Quaternion.Slerp(planet.transform.rotation, 
                                                                 planetRotations[0].rotation, 
                                                                 Time.deltaTime * rotationSpeed);
                    currentPlanetRotation3 = planetRotationSelection;
                }

                if (planetRotationSelection == 1) {
                    planet.transform.rotation = Quaternion.Slerp(planet.transform.rotation,
                                                                 planetRotations[1].rotation,
                                                                 Time.deltaTime * rotationSpeed);
                    currentPlanetRotation3 = planetRotationSelection;
                }

                if (planetRotationSelection == 2) {
                    planet.transform.rotation = Quaternion.Slerp(planet.transform.rotation,
                                                                 planetRotations[2].rotation,
                                                                 Time.deltaTime * rotationSpeed);
                    currentPlanetRotation3 = planetRotationSelection;
                }

                if (planetRotationSelection == 3) {
                    planet.transform.rotation = Quaternion.Slerp(planet.transform.rotation,
                                                                 planetRotations[3].rotation,
                                                                 Time.deltaTime * rotationSpeed);
                    currentPlanetRotation3 = planetRotationSelection;
                }
            }
            else {
                GameObject.Find("Planet 3").transform.GetChild(1).GetComponent<Renderer>().material = planetThreeMat;
            }

            if (planetSelection == 3) {
                GameObject planet = GameObject.Find("Planet 4");
                planet.transform.GetChild(1).GetComponent<Renderer>().material = outlineMat;

                if (!ranOnce) { // check if current planet rotation has been assigned.
                    planetRotationSelection = currentPlanetRotation4;
                    ranOnce = true;
                }

                if (planetRotationSelection == 0) {
                    planet.transform.rotation = Quaternion.Slerp(planet.transform.rotation, 
                                                                 planetRotations[0].rotation, 
                                                                 Time.deltaTime * rotationSpeed);
                    currentPlanetRotation4 = planetRotationSelection;
                }

                if (planetRotationSelection == 1) {
                    planet.transform.rotation = Quaternion.Slerp(planet.transform.rotation,
                                                                 planetRotations[1].rotation,
                                                                 Time.deltaTime * rotationSpeed);
                    currentPlanetRotation4 = planetRotationSelection;
                }

                if (planetRotationSelection == 2) {
                    planet.transform.rotation = Quaternion.Slerp(planet.transform.rotation,
                                                                 planetRotations[2].rotation,
                                                                 Time.deltaTime * rotationSpeed);
                    currentPlanetRotation4 = planetRotationSelection;
                }

                if (planetRotationSelection == 3) {
                    planet.transform.rotation = Quaternion.Slerp(planet.transform.rotation,
                                                                 planetRotations[3].rotation,
                                                                 Time.deltaTime * rotationSpeed);
                    currentPlanetRotation4 = planetRotationSelection;
                }
            }
            else {
                GameObject.Find("Planet 4").transform.GetChild(1).GetComponent<Renderer>().material = planetFourMat;
            }

            if (Input.GetKeyDown("w")) {
                planetSelection += 1;
                ranOnce = false;
            }
            if (Input.GetKeyDown("s")) {
                planetSelection -= 1;
                ranOnce = false;
            }
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