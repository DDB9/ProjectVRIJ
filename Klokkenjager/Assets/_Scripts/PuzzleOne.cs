using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleOne : MonoBehaviour {

    public static PuzzleOne instance = null;

    public GameObject doorLeft;
    public GameObject doorRight;

    public Transform doorLeftOpenRotation;
    public Transform doorRightOpenRotation;

    public float openingSpeed;

    public static bool planetOneInPlace;
    public static bool planetTwoInPlace;
    public static bool planetThreeInPlace;
    public static bool planetFourInPlace;

    void Update() { // Opens de first door. Maybe add screenshake later?
        if (planetOneInPlace && planetTwoInPlace && planetThreeInPlace && planetFourInPlace) {
            doorLeft.transform.rotation = Quaternion.Slerp(doorLeft.transform.rotation, 
                                                           doorLeftOpenRotation.rotation,
                                                           Time.deltaTime * openingSpeed);
            doorRight.transform.rotation = Quaternion.Slerp(doorRight.transform.rotation,
                                                            Quaternion.Euler(0f, 120f, -180f),
                                                            Time.deltaTime * openingSpeed);                                            
        }
    }
}
