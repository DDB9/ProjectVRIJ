using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SolarSystemManager : MonoBehaviour {

    public GameObject[] planets;
    public GameObject eToInteract;
    public Transform solarSystemCameraTransform;
    public GameObject cameraBase, cameraFollow;

    [System.NonSerialized]
    public bool lockOnP1;
    [System.NonSerialized]
    public bool lockOnP2;
    [System.NonSerialized]
    public bool lockOnP3;
    [System.NonSerialized]
    public bool lockOnP4;

    [System.NonSerialized]
    public bool lockOnSolarSystem;

    private float cameraTransitionSpeed = 5f;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (lockOnSolarSystem){
            eToInteract.SetActive(true);
            if (Input.GetKeyDown("e")) {
                cameraFollow.transform.position = Vector3.Lerp(transform.position, solarSystemCameraTransform.position, cameraTransitionSpeed * Time.deltaTime);
                cameraFollow.transform.rotation = Quaternion.Slerp(transform.rotation, solarSystemCameraTransform.rotation, cameraTransitionSpeed * Time.deltaTime);

                Delay(1.5f);
                cameraBase.GetComponent<CameraFollow>().enabled = false;
            }
        }
        else {
            eToInteract.SetActive(false);
        }
        if (lockOnP1) {

        }
    }

    IEnumerator Delay(float seconds) {
        yield return new WaitForSeconds(seconds);
    }
}