using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon : MonoBehaviour
{
    [SerializeField] LeaveSheepInPoint leaveSheep;

    float dragonRotationSpeed = 0.5f;
    float dragonMovementSpeed = 1.0f;

    void Update()
    {
        if (leaveSheep.sheepIsOnPlace)
        {
            transform.Translate(Vector3.forward * dragonMovementSpeed * Time.deltaTime);
            Vector3 sheepPosition = leaveSheep.gameObject.transform.position;
            Vector3 sheepDirection = sheepPosition - transform.position;
            Quaternion dragonRotation = Quaternion.LookRotation(sheepDirection);
            dragonRotation = new Quaternion(0, dragonRotation.y, 0, dragonRotation.w);

            transform.rotation = Quaternion.Lerp(transform.rotation, dragonRotation, dragonRotationSpeed * Time.deltaTime);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 11)
        {
            dragonMovementSpeed = 0.0f;
            dragonRotationSpeed = 0.0f;
        }
    }
}
