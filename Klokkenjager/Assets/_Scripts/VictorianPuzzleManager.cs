using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VictorianPuzzleManager : MonoBehaviour {

    public List<string> tags = new List<string>();
    public List<Sprite> cardFaces = new List<Sprite>();
    public List<GameObject> firstHalf = new List<GameObject>();
    public List<GameObject> secondHalf = new List<GameObject>();

    [Space]

    public bool victorianLockOn;

    public CameraFollow cameraFollow;
    public GameObject eToInteract;
    public GameObject victorianOverlay;
    public LayerMask uiLayer;

    private List<GameObject> selectedCards = new List<GameObject>();
    private List<GameObject> completedCards = new List<GameObject>();

    private bool firstHalfInactive = true;
    private bool secondHalfInactive = true;

    // Start is called before the first frame update
    void Start() {
        CreateTagList();    // Create the first tag list.

        for (int i = 0; i < 8; i++) {
            firstHalf[i].tag = tags[i];     // Set the tag.

            int currentCardFace = int.Parse(tags[i]);
            firstHalf[i].GetComponent<Image>().sprite = cardFaces[currentCardFace];    // Set the card face.
        }

        CreateTagList();    // Clear the tag list and create it again.

        for (int i = 0; i < 8; i++) {
            secondHalf[i].tag = tags[i];    // Set the tag.

            int currentCardFace = int.Parse(tags[i]);
            secondHalf[i].GetComponent<Image>().sprite = cardFaces[currentCardFace];    // Set the card face.
        }

        completedCards.Clear();
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown("q")) {
            cameraFollow.enabled = true;
            victorianOverlay.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
        }

        if (selectedCards.Count == 2) {
            if (selectedCards[0].tag == selectedCards[1].tag) {
                foreach (GameObject crd in selectedCards) {
                    crd.transform.rotation = crd.transform.rotation;
                    crd.SetActive(false); // DEBUG 
                }
                completedCards.Add(selectedCards[0]);
                completedCards.Add(selectedCards[1]);

                selectedCards.Clear();
            }
            else {
                foreach (GameObject crd in selectedCards) {
                    crd.transform.Rotate(0, 180, 0);
                }
                selectedCards.Clear();
            }
        }
        
        if (completedCards.Count >= 16) {
            GameManager.victorianPuzzleComplete = true;
        }
    }
    

    void CreateTagList() {
        tags.Clear();                   // clear the tag list first
        for (int i = 0; i < 8; i++) {  // then create it from scratch.
            string _tag = Random.Range(0, 8).ToString();
            if (tags.Contains(_tag)) {
                i--;
                continue;
            }
            tags.Add(_tag);
        }
    }

    void OnTriggerStay(Collider other) {
        eToInteract.SetActive(true);
        if (Input.GetKeyDown("e")) {
            victorianOverlay.SetActive(true);
            eToInteract.SetActive(false);
            cameraFollow.enabled = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    void OnTriggerExit(Collider other) {
        eToInteract.SetActive(false);
    }

    public void OnClick(GameObject card) {
        if (tags.Contains(card.transform.tag)) {
            card.transform.Rotate(0, 180, 0);
            if (!selectedCards.Contains(card.transform.gameObject)) {
                selectedCards.Add(card.transform.gameObject);
            }
        }
    }
}
