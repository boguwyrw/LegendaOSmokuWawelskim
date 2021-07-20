using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkubaLook : MonoBehaviour
{
    float sensitivity = 130.0f;
    float playerXRotation = 0.0f;
    float rotationRange = 65.0f;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float playerAxisX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float playerAxisY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        playerXRotation -= playerAxisY;
        playerXRotation = Mathf.Clamp(playerXRotation, -rotationRange, rotationRange);

        transform.parent.Rotate(Vector3.up * playerAxisX);
        transform.localRotation = Quaternion.Euler(playerXRotation, 0.0f, 0.0f);
    }
}
