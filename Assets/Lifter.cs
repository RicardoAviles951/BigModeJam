using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lifter : MonoBehaviour
{
    private Transform cubeTransform;
    private bool isLifting = false;
    private Vector3 targetPosition;

    void Start()
    {
        cubeTransform = transform;
    }

    void Update()
    {
        if (isLifting)
        {
            // Smoothly move the cube towards the target position
            cubeTransform.position = Vector3.Lerp(cubeTransform.position, targetPosition, Time.deltaTime * 2f);

            // Check if the cube is close enough to the target position
            if (Vector3.Distance(cubeTransform.position, targetPosition) < 0.05f)
            {
                isLifting = false;
            }
        }
    }

    public void Lift(float distance)
    {
        // Set the target position for lifting
        targetPosition = cubeTransform.position + Vector3.up * distance;

        // Start lifting
        isLifting = true;
    }
}
