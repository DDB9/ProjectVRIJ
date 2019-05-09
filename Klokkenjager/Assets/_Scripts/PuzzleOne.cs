using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleOne : MonoBehaviour {

    public static PuzzleOne instance = null;

    public Image puzzleComplete;

    public static bool planetOneInPlace;
    public static bool planetTwoInPlace;
    public static bool planetThreeInPlace;
    public static bool planetFourInPlace;

    void Update() {
        if (planetOneInPlace && planetTwoInPlace && planetThreeInPlace && planetFourInPlace) {
            puzzleComplete.color = Color.green;
        }
    }
}
