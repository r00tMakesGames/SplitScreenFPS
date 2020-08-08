using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class tumbler : MonoBehaviour
{
    public float angularVelocity = 10.0f;
    private Vector3 axisOfRotation;
    void Start()
    {
        axisOfRotation = Random.onUnitSphere;
    }
    void Update()
    {
        transform.Rotate(axisOfRotation, angularVelocity * Time.smoothDeltaTime);
    }
}
