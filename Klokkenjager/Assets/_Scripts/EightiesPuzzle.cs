using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EightiesPuzzle : MonoBehaviour {

    public Material[] normalTileColors;
    public Material[] correctTileColors;

    public float raveSpeed;

    bool memberInvoked;

    void Update() {
        if (memberInvoked == false)
            StartCoroutine("ChangeTileMaterial");
    }

    IEnumerator ChangeTileMaterial() {
        memberInvoked = true;
        foreach (Transform tile in transform)
        {
            if (tile.CompareTag("80sCorrectTile")) {
                tile.GetComponent<Renderer>().material = correctTileColors[Random.Range(0, correctTileColors.Length)];
            }
            else {
                tile.GetComponent<Renderer>().material = normalTileColors[Random.Range(0, normalTileColors.Length)];
            }
        }
        yield return new WaitForSeconds(raveSpeed);
        memberInvoked = false;
    }

}
