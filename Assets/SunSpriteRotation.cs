using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunSpriteRotation : MonoBehaviour
{
    public float rotationSpeed;

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(0,0,rotationSpeed);
    }
}
