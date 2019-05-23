using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShufflePuzzleManager : MonoBehaviour {
    public static ShufflePuzzleManager instance = null;

    public Camera medievalCamera;
    public Camera mainCamera;
    public GameObject player;
    
    public static bool shuffleLockOn = false;

    private bool cameraInPlace;
    private CharacterControls playerController;

    // Start is called before the first frame update
    void Start() {
        playerController = FindObjectOfType<CharacterControls>();
    }

    // Update is called once per frame
    void Update() {
        if (shuffleLockOn) {
            if (Input.GetKeyDown("e")) {
                cameraInPlace = true;
                playerController.enabled = false;
                player.GetComponent<Rigidbody>().velocity = Vector3.zero;
                medievalCamera.enabled = true;
                Camera.main.enabled = false;
            }

            if (shuffleLockOn && Input.GetKeyDown("q")) {
                playerController.enabled = true;
                medievalCamera.enabled = false;
                mainCamera.enabled = true;
            }
        }
    }
}
