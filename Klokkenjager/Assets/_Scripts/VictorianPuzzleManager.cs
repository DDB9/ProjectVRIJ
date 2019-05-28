using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictorianPuzzleManager : MonoBehaviour {

    public string[] cardTags = new string[10] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" };
    public GameObject[] firstHalve;
    public GameObject[] secondHalve;

    // BOOL LIST
    bool tagOne;
    bool tagTwo;
    bool tagThree;
    bool tagFour;
    bool tagFive;
    bool tagSix;
    bool tagSeven;
    bool tagEight;
    bool tagNine;
    bool tagTen;

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        do {   
            foreach (GameObject go in firstHalve) {
                var randomTag = cardTags[Random.Range(0, cardTags.Length)];
                Debug.Log(randomTag);

                if (randomTag == "1" && tagOne == false) {
                    go.tag = randomTag;
                    tagOne = true;
                    Debug.Log("Got here");
                    break;
                }
                else {
                    randomTag = cardTags[Random.Range(0, cardTags.Length)];
                }

                if (randomTag == "2" && tagTwo == false) {
                    go.tag = randomTag;
                    tagTwo = true;
                    break;
                }
                else {
                    randomTag = cardTags[Random.Range(0, cardTags.Length)];
                }

                if (randomTag == "3" && tagThree == false) {
                    go.tag = randomTag;
                    tagThree = true;
                    break;
                }
                else {
                    randomTag = cardTags[Random.Range(0, cardTags.Length)];
                }

                if (randomTag == "4" && tagFour == false) {
                    go.tag = randomTag;
                    tagFour = true;
                    break;
                }
                else {
                    randomTag = cardTags[Random.Range(0, cardTags.Length)];
                }

                if (randomTag == "5" && tagFive == false) {
                    go.tag = randomTag;
                    tagFive = true;
                    break;
                }
                else {
                    randomTag = cardTags[Random.Range(0, cardTags.Length)];
                }

                if (randomTag == "6" && tagSix == false) {
                    go.tag = randomTag;
                    tagSix = true;
                    break;
                }
                else {
                    randomTag = cardTags[Random.Range(0, cardTags.Length)];
                }

                if (randomTag == "7" && tagSeven == false) {
                    go.tag = randomTag;
                    tagSeven = true;
                    break;
                }

                else {
                    randomTag = cardTags[Random.Range(0, cardTags.Length)];
                }

                if (randomTag == "8" && tagEight == false) {
                    go.tag = randomTag;
                    tagEight = true;
                    break;
                }
                else {
                    randomTag = cardTags[Random.Range(0, cardTags.Length)];
                }

                if (randomTag == "9" && tagNine == false) {
                    go.tag = randomTag;
                    tagNine = true;
                    break;
                }
                else {
                    randomTag = cardTags[Random.Range(0, cardTags.Length)];
                }

                if (randomTag == "10" && tagTen == false) {
                    go.tag = randomTag;
                    tagTen = true;
                    break;
                }
                else {
                    randomTag = cardTags[Random.Range(0, cardTags.Length)];
                }
            } 
        } while (true);
    }
}
