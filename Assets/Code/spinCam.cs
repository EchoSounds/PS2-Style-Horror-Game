using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spinCam : MonoBehaviour
{
    public float rotationSpeed = 10f; // the speed of the rotation in degrees per second

    void Update()
    {
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);
    }
}
