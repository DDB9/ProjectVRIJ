using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    void OnTriggerEnter(Collider other) {
        // SOLAR SYSTEM PUZZLE
        if (this.name == "Planet 1 Collider" && other.name == "Planet 1") PuzzleOne.planetOneInPlace = true;
        if (this.name == "Planet 2 Collider" && other.name == "Planet 2") PuzzleOne.planetTwoInPlace = true;
        if (this.name == "Planet 3 Collider" && other.name == "Planet 3") PuzzleOne.planetThreeInPlace = true;
        if (this.name == "Planet 4 Collider" && other.name == "Planet 4") PuzzleOne.planetFourInPlace = true;

        // 80'S PUZZLE
        if (this.name == "80's Finish" && other.CompareTag("Player")) {
            // Give access to box?
            Debug.Log("CORRECT");
        }

    }

    void OnCollisionEnter(Collision other) {
        if (this.name == "Normal Tile" && other.transform.CompareTag("Player")) {
            // Put player back?
            Debug.Log("INCORRECT");
        }
    }
}
