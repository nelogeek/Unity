using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    Quaternion originRotation;
    float Angle;

    // Start is called before the first frame update
    void Start()
    {
        originRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        Angle++;
        Quaternion rotationY = Quaternion.AngleAxis(Angle, Vector3.up);
        Quaternion rotationX = Quaternion.AngleAxis(Angle, Vector3.right);
        transform.rotation = originRotation * rotationY * rotationX;

    }
}
