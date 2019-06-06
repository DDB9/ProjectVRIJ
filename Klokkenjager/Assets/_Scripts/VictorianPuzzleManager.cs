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

    public GameObject eToInteract;
    public GameObject victorianOverlay;

    private List<GameObject> selectedCards = new List<GameObject>();
    private List<GameObject> completedCards = new List<GameObject>();

    // Start is called before the first frame update
    void Start() {
        CreateTagList();    // Create the first tag list.

        for (int i = 0; i < 10; i++) {
            firstHalf[i].tag = tags[i];     // Set the tag.

            int currentCardFace = int.Parse(tags[i]);
            firstHalf[i].GetComponent<SpriteRenderer>().sprite = cardFaces[currentCardFace];    // Set the card face.
        }

        CreateTagList();    // Clear the tag list and create it again.

        for (int i = 0; i < 10; i++) {
            secondHalf[i].tag = tags[i];    // Set the tag.

            int currentCardFace = int.Parse(tags[i]);
            secondHalf[i].GetComponent<SpriteRenderer>().sprite = cardFaces[currentCardFace];    // Set the card face.
        }

    }

    // Update is called once per frame
    void Update() {
        if (victorianLockOn) {
            eToInteract.SetActive(true);
            if (Input.GetKeyDown("e")) {
                victorianOverlay.SetActive(true);
            }

            if (selectedCards.Count == 2) {
                if (selectedCards[0].tag == selectedCards[1].tag) {
                    foreach (GameObject crd in selectedCards) {
                        crd.transform.rotation = crd.transform.rotation;
                        crd.SetActive(false); // DEBUG 
                        completedCards.Add(crd);
                    }
                }
                else {
                    foreach (GameObject crd in selectedCards) {
                        crd.transform.Rotate(0, 180, 0);
                    }
                    selectedCards.Clear();
                }
            }
            if (selectedCards.Count > 2) {
                selectedCards.Clear();
            }
            if (selectedCards.Count >= 20) {
                GameManager.victorianPuzzleComplete = true;
            }

            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.TransformDirection(Vector3.forward), out RaycastHit hit, 10f)) {
                if (tags.Contains(hit.collider.tag) && Input.GetMouseButtonDown(0)) {
                    //hit.transform.Rotate(0, 180, 0);
                    if (!selectedCards.Contains(hit.transform.gameObject)) {
                        selectedCards.Add(hit.transform.gameObject);
                    }
                    // Quaternion Slerp if card transition looks like shit.
                }
            }
        }


    }

    void CreateTagList() {
        tags.Clear();                   // clear the tag list first
        for (int i = 0; i < 10; i++) {  // then create it from scratch.
            string _tag = Random.Range(0, 10).ToString();
            if (tags.Contains(_tag)) {
                i--;
                continue;
            }
            tags.Add(_tag);
        }
    }
}
