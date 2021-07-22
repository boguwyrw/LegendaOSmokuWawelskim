using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon : MonoBehaviour
{
    [SerializeField] LeaveSheepInPoint leaveSheep;
    [SerializeField] Transform neckPoint;
    [SerializeField] Transform placeToDrink;

    [HideInInspector] public bool sheepEaten = false;

    float dragonRotationSpeed = 0.5f;
    float dragonMovementSpeed = 1.0f;
    bool canEatSheep = false;
    bool canGoToRiver = false;

    void Update()
    {
        if (leaveSheep.sheepIsOnPlace && !sheepEaten)
        {
            DragonMovement(leaveSheep.gameObject.transform.position);
        }

        if (canEatSheep && !sheepEaten)
        {
            neckPoint.Rotate(0, 0, -16 * Time.deltaTime);
        }

        if (sheepEaten && !canGoToRiver)
        {
            neckPoint.Rotate(0, 0, 16 * Time.deltaTime);
            if (neckPoint.localEulerAngles.z >= 315)
            {
                canGoToRiver = true;
            }
        }

        DragonGoesToRiver();
    }

    void DragonMovement(Vector3 objectPosition)
    {
        transform.Translate(Vector3.forward * dragonMovementSpeed * Time.deltaTime);
        Vector3 position = objectPosition;
        Vector3 direction = position - transform.position;
        Quaternion dragonRotation = Quaternion.LookRotation(direction);
        dragonRotation = new Quaternion(0, dragonRotation.y, 0, dragonRotation.w);

        transform.rotation = Quaternion.Lerp(transform.rotation, dragonRotation, dragonRotationSpeed * Time.deltaTime);
    }

    void DragonGoesToRiver()
    {
        if (canGoToRiver)
        {
            dragonRotationSpeed = 0.5f;
            dragonMovementSpeed = 1.0f;
            DragonMovement(placeToDrink.position);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 11 && !canEatSheep)
        {
            dragonMovementSpeed = 0.0f;
            dragonRotationSpeed = 0.0f;
            canEatSheep = true;
        }
    }
}
