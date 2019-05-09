using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public float rotationSpeed;
    public float dampAmount;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate((Vector3.forward * rotationSpeed) * (Time.deltaTime * dampAmount), Space.Self);
    }
}
