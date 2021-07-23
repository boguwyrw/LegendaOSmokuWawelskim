using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkubaMove : MonoBehaviour
{
    [SerializeField] AudioClip[] movementAudioClips;

    AudioSource audioSource;
    AudioClip currentClip;
    float playerSpeed = 0.0f;
    float sneakingSpeed = 2.4f;
    float walkingSpeed = 6.0f;
    float runningSpeed = 13.0f;

    bool playerIsSneaking = false;
    bool canPlayClip = false;
    bool clipIsPlaying = false;
    bool runningClipIsPlaying = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        PlayerMovement();

        PlayerSneaking();

        PlayerRunning();

        MovementsClipsArePlaying();
    }

    void PlayerMovement()
    {
        if (Input.GetKey(KeyCode.W))
        {
            if (!Input.GetKey(KeyCode.LeftShift) && !playerIsSneaking)
                playerSpeed = walkingSpeed;
            transform.Translate(Vector3.forward * playerSpeed * Time.deltaTime);
            canPlayClip = true;
        }
        else if (!Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
        {
            TurnOffClips();
        }

        if (Input.GetKey(KeyCode.S))
        {
            if (!Input.GetKey(KeyCode.LeftShift) && !playerIsSneaking)
                playerSpeed = walkingSpeed;
            transform.Translate(Vector3.back * playerSpeed * Time.deltaTime);
            canPlayClip = true;
        }
        else if(!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
        {
            TurnOffClips();
        }

        if (Input.GetKey(KeyCode.D))
        {
            if (!Input.GetKey(KeyCode.LeftShift) && !playerIsSneaking)
                playerSpeed = walkingSpeed;
            transform.Translate(Vector3.right * playerSpeed * Time.deltaTime);
            canPlayClip = true;
        }
        else if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.A))
        {
            TurnOffClips();
        }

        if (Input.GetKey(KeyCode.A))
        {
            if (!Input.GetKey(KeyCode.LeftShift) && !playerIsSneaking)
                playerSpeed = walkingSpeed;
            transform.Translate(Vector3.left * playerSpeed * Time.deltaTime);
            canPlayClip = true;
        }
        else if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.D))
        {
            TurnOffClips();
        }
    }

    void PlayerSneaking()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            playerIsSneaking = !playerIsSneaking;
            clipIsPlaying = !clipIsPlaying;


            if (playerIsSneaking)
            {
                playerSpeed = sneakingSpeed;
            }
            else if (!playerIsSneaking && !Input.GetKey(KeyCode.LeftShift))
                playerSpeed = walkingSpeed;
        }
    }

    void PlayerRunning()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            playerSpeed = runningSpeed;
            playerIsSneaking = false;
            if (!runningClipIsPlaying)
            {
                clipIsPlaying = false;
                runningClipIsPlaying = true;
            }
        }
        else if (!playerIsSneaking)
        {
            playerSpeed = walkingSpeed;
            if (runningClipIsPlaying)
            {
                clipIsPlaying = false;
                runningClipIsPlaying = false;
            }
        }
    }

    void MovementsClipsArePlaying()
    {
        if (canPlayClip && !clipIsPlaying)
        {
            if (playerSpeed == sneakingSpeed)
            {
                currentClip = movementAudioClips[0];
                audioSource.clip = currentClip;
                audioSource.Play();
                clipIsPlaying = true;
            }
            else if (playerSpeed == walkingSpeed)
            {
                currentClip = movementAudioClips[1];
                audioSource.clip = currentClip;
                audioSource.Play();
                clipIsPlaying = true;
            }
            else if (playerSpeed == runningSpeed)
            {
                currentClip = movementAudioClips[2];
                audioSource.clip = currentClip;
                audioSource.Play();
                clipIsPlaying = true;
            }
        }
        //else
            //audioSource.Stop();
    }

    void TurnOffClips()
    {
        playerSpeed = 0;
        canPlayClip = false;
        audioSource.Stop();
        clipIsPlaying = false;
    }
}
