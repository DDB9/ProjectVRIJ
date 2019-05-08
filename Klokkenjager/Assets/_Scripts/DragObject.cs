using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObject : MonoBehaviour {

    Vector3 mOffset;
    float mZCoord;
    Camera solarCamera;

    void Start() {
        solarCamera = GameObject.Find("Solar Camera").GetComponent<Camera>();
    }

    void OnMouseDown() {
        mZCoord = solarCamera.WorldToScreenPoint(gameObject.transform.position).z;

        // Store offset = gameobject world pos - mouse world pos.
        mOffset = gameObject.transform.position = GetMouseWorldPosition();
    }
    
    void OnMouseDrag() {
        transform.position = GetMouseWorldPosition() +  mOffset;
    }

    Vector3 GetMouseWorldPosition() {
 
        // Mouse Position in pixel coordinates.
        Vector3 mPosition = Input.mousePosition;

        // Object's z coordinate.
        mPosition.z = mZCoord;

        return solarCamera.ScreenToWorldPoint(mPosition);
    }
}
