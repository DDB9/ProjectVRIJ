using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    void OnTriggerEnter(Collider other) {
        if (this.name == "Planet 1 Collider" && other.name == "Planet 1") PuzzleOne.planetOneInPlace = true;
        if (this.name == "Planet 2 Collider" && other.name == "Planet 2") PuzzleOne.planetTwoInPlace = true;
        if (this.name == "Planet 3 Collider" && other.name == "Planet 3") PuzzleOne.planetThreeInPlace = true;
        if (this.name == "Planet 4 Collider" && other.name == "Planet 4") PuzzleOne.planetFourInPlace = true;
    }
}
