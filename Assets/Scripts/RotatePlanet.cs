using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlanet : MonoBehaviour
{
    public RectTransform target;
    public float degreesPerSecond = 20;

    // Update is called once per frame
    void Update()
    {

        transform.RotateAround(target.transform.position, -Vector3.forward, degreesPerSecond * Time.deltaTime);
    }
}
