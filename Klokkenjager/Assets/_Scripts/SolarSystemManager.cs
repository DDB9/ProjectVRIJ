using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarSystemManager : MonoBehaviour {

    public GameObject[] planets;

    [System.NonSerialized]
    public bool lockOnP1;
    [System.NonSerialized]
    public bool lockOnP2;
    [System.NonSerialized]
    public bool lockOnP3;
    [System.NonSerialized]
    public bool lockOnP4;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (lockOnP1) {
        }
    }
}