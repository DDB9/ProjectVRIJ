using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictorianPuzzleManager : MonoBehaviour {

    public List<string> tags = new List<string>();
    public List<GameObject> firstHalf = new List<GameObject>();
    public List<GameObject> secondHalf = new List<GameObject>();

    [Space]

    public Transform cardClosed;
    public Transform cardOpen;

    public float rotationSpeed;

    private bool cardRotated = true;
    public GameObject card;

    // Start is called before the first frame update
    void Start() {
        CreateTagList();

        for (int i = 0; i < 10; i++) {
            firstHalf[i].tag = tags[i];
        }

        CreateTagList();

        for (int i = 0; i < 10; i++) {
            secondHalf[i].tag = tags[i];
        }
    }

    // Update is called once per frame
    void Update() {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.TransformDirection(Vector3.forward), out hit, 10f)) {
            if (tags.Contains(hit.collider.tag) && Input.GetMouseButtonDown(0)) {
                card = hit.transform.gameObject;
                cardRotated = false;
            }
        }

        if (!cardRotated) {
            card.transform.localRotation = Quaternion.Slerp(card.transform.rotation, Quaternion.Euler(0, 180, 0) , rotationSpeed * Time.deltaTime);
            cardRotated = true;
        }
    }

    void CreateTagList() {
        tags.Clear();
        for (int i = 0; i < 10; i++) {
            string _tag = Random.Range(0, 10).ToString();
            if (tags.Contains(_tag)) {
                i--;
                continue;
            }
            tags.Add(_tag);
        }
    }
}
