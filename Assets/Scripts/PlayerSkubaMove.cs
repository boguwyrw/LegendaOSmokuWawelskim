using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkubaMove : MonoBehaviour
{
    float playerSpeed = 0.0f;
    float sneakingSpeed = 1.2f;
    float walkingSpeed = 2.5f;
    float runningSpeed = 6.0f;

    bool playerIsSneaking = false;

    void Start()
    {
        playerSpeed = walkingSpeed;
    }

    void Update()
    {
        PlayerMovement();

        PlayerSneaking();

        PlayerRunning();
    }

    void PlayerMovement()
    {
        if (Input.GetKey(KeyCode.W))
            transform.Translate(Vector3.forward * playerSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.S))
            transform.Translate(Vector3.back * playerSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.D))
            transform.Translate(Vector3.right * playerSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.A))
            transform.Translate(Vector3.left * playerSpeed * Time.deltaTime);
    }

    void PlayerSneaking()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            playerIsSneaking = !playerIsSneaking;

            if (playerIsSneaking)
                playerSpeed = sneakingSpeed;
            else if (!playerIsSneaking && !Input.GetKey(KeyCode.LeftShift))
                playerSpeed = walkingSpeed;
        }
    }

    void PlayerRunning()
    {
        if (Input.GetKey(KeyCode.LeftShift))
            playerSpeed = runningSpeed;
        else if (!playerIsSneaking)
            playerSpeed = walkingSpeed;
    }
}
