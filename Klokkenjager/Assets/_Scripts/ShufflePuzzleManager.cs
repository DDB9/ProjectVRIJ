using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShufflePuzzleManager : MonoBehaviour {
    public static ShufflePuzzleManager instance = null;

    public Camera medievalCamera;
    public Camera mainCamera;
    public GameObject player;
    public GameObject eToInteract;
    public GameObject cameraBase;

    public AudioClip[] stoneSounds = new AudioClip[7];
    public AudioSource stoneSource;
    
    public static bool shuffleLockOn = false;

    private CharacterControls playerController;

    // Start is called before the first frame update
    void Start() {
        playerController = FindObjectOfType<CharacterControls>();
    }

    // Update is called once per frame
    void Update() {
        if (shuffleLockOn) {
            eToInteract.SetActive(true);
            if (Input.GetKeyDown("e")) {
                playerController.enabled = false;
                cameraBase.SetActive(false);
                player.GetComponent<Rigidbody>().velocity = Vector3.zero;
                medievalCamera.enabled = true;
                mainCamera.enabled = false;
            }

            if (shuffleLockOn && Input.GetKeyDown("q")) {
                playerController.enabled = true;
                cameraBase.SetActive(true);
                medievalCamera.enabled = false;
                mainCamera.enabled = true;
            }
        }
        else {
            eToInteract.SetActive(false);
        }
    }

    // Directionairy sound output.
    public void PlayUpSound() {
        stoneSource.clip = stoneSounds[Random.Range(0, stoneSounds.Length)];
        stoneSource.Play();
    }
    public void PlayDownSound() {
        stoneSource.clip = stoneSounds[Random.Range(0, stoneSounds.Length)];
        stoneSource.Play();
    }
    public void PlayRightSound() {
        stoneSource.clip = stoneSounds[Random.Range(0, stoneSounds.Length)];
        stoneSource.Play();
    }
    public void PlayLeftSound() {
        stoneSource.clip = stoneSounds[Random.Range(0, stoneSounds.Length)];
        stoneSource.Play();
    }

}
