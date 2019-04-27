using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCollision : MonoBehaviour {

    public float minDistance = 1f;
    public float maxDistance = 4f;
    public float smooth = 10f;
    public float distance;
    public Vector3 dollyDirectionAdjusted;

    Vector3 dollyDirection;


    // Start is called before the first frame update
    void Start() {
        dollyDirection = transform.localPosition.normalized;
        distance = transform.localPosition.magnitude;
    }

    // Update is called once per frame
    void Update() {
        Vector3 desiredCameraPosition = transform.parent.TransformPoint(dollyDirection * maxDistance);
        
        RaycastHit hit;
        if (Physics.Linecast(transform.parent.position, desiredCameraPosition, out hit)) {
            distance = Mathf.Clamp(hit.distance * 0.9f, minDistance, maxDistance);
            
        } else {
            distance = maxDistance;
        }

        transform.localPosition = Vector3.Lerp(transform.localPosition, dollyDirection * distance, Time.deltaTime * smooth);
       
    }
}
