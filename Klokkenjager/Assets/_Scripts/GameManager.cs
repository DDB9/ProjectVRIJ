using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public GameObject solarPuzzleEighties;
    public GameObject solarPuzzleMedieval;

    public GameObject solarSolutionEighties;
    public GameObject solarSolutionMedieval;

    public static bool victorianPuzzleComplete;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (victorianPuzzleComplete) {
            Debug.Log("LAST PUZZLE COMPLETE!");
        }
    }
}
