using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WawelskiDragon : MonoBehaviour
{
    [SerializeField] LeaveSheepInPoint leaveSheep;
    [SerializeField] Transform neckPoint;
    [SerializeField] Transform placeToDrink;
    [SerializeField] Transform caveEnter;
    [SerializeField] Transform stomach;
    [SerializeField] GameObject sneakingRangeGO;
    [SerializeField] GameObject walkingRangeGO;
    [SerializeField] GameObject runningRangeGO;
    [SerializeField] AudioClip dragonEating;
    [SerializeField] Text cautionInfoText;

    [HideInInspector] public bool sheepEaten = false;
    [HideInInspector] public bool reachedSafePoint = false;

    AudioSource audioSource;
    float dragonRotationSpeed = 0.5f;
    float dragonMovementSpeed = 1.0f;
    float wakeUpTime = 3.5f;
    bool canEatSheep = false;
    bool canGoToRiver = false;
    bool isInRiver = false;
    bool reachedCaveEnterPoint = false;
    bool dragonRoars = false;
    bool rangesGOAreVisible = false;
    bool dragonIsDying = false;
    LayerMask playerLayerMask = 1 << 6;
    Collider[] playerInSneakingRange;
    Collider[] playerInWalkingRange;
    Collider[] playerInRunningRange;
    float sneakingRange = 14.0f;
    float walkingRange = 26.0f;
    float runningRange = 38.0f;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        if (!rangesGOAreVisible)
        {
            sneakingRangeGO.SetActive(false);
            walkingRangeGO.SetActive(false);
            runningRangeGO.SetActive(false);
        }
    }

    void Update()
    {
        HelpController();

        if (!reachedSafePoint)
            DragonHearRange();
        else
            CautionInformation();

        if (leaveSheep.sheepIsOnPlace && !reachedCaveEnterPoint)
        {
            if (wakeUpTime > 0)
                wakeUpTime -= Time.deltaTime;
            else
                wakeUpTime = 0;

            if (wakeUpTime == 0)
            {
                DragonMovement(caveEnter.position);

                float distanceToPoint = Vector3.Distance(caveEnter.position, transform.root.position);
                if (distanceToPoint < 5)
                {
                    reachedCaveEnterPoint = true;
                }
            }
        }

        if (reachedCaveEnterPoint && !sheepEaten)
        {
            if (reachedSafePoint)
                DragonMovement(leaveSheep.gameObject.transform.position);
            else
            {
                if (!dragonRoars)
                {
                    audioSource.Play();
                    dragonRoars = true;
                }

                if (!audioSource.isPlaying && dragonRoars)
                {
                    Time.timeScale = 0.0f;
                    GameController.Instance.LoseGameController();
                }
            }
        }

        if (canEatSheep && !sheepEaten)
        {
            DragonLeansDown();
        }

        if (sheepEaten && !canGoToRiver)
        {
            audioSource.clip = dragonEating;
            audioSource.Play();

            neckPoint.Rotate(-16 * Time.deltaTime, 0, 0);

            if (neckPoint.localEulerAngles.x > 277.75f && neckPoint.localEulerAngles.x < 278.25f)
            {
                neckPoint.localEulerAngles = new Vector3(278.0f, neckPoint.localEulerAngles.y, neckPoint.localEulerAngles.z);
                canGoToRiver = true;
            }
        }

        DragonGoesToRiver();

        if (isInRiver)
            DragonDrinksWater();
    }

    void HelpController()
    {
        if (Input.GetKeyDown(KeyCode.H))
            rangesGOAreVisible = !rangesGOAreVisible;

        if (!rangesGOAreVisible)
        {
            sneakingRangeGO.SetActive(false);
            walkingRangeGO.SetActive(false);
            runningRangeGO.SetActive(false);
        }
        else
        {
            sneakingRangeGO.SetActive(true);
            walkingRangeGO.SetActive(true);
            runningRangeGO.SetActive(true);
        }
    }

    void DragonHearRange()
    {
        playerInSneakingRange = Physics.OverlapSphere(transform.root.position, sneakingRange, playerLayerMask);
        playerInWalkingRange = Physics.OverlapSphere(transform.root.position, walkingRange, playerLayerMask);
        playerInRunningRange = Physics.OverlapSphere(transform.root.position, runningRange, playerLayerMask);

        foreach (Collider player in playerInSneakingRange)
        {
            if (player.GetComponent<PlayerSkubaMove>().playerSpeed > 0.0f)
            {
                ContactWithDragon();
            }
        }

        foreach (Collider player in playerInWalkingRange)
        {
            if (player.GetComponent<PlayerSkubaMove>().playerSpeed > 2.4f)
            {
                ContactWithDragon();
            }
        }

        foreach (Collider player in playerInRunningRange)
        {
            if (player.GetComponent<PlayerSkubaMove>().playerSpeed > 6.0f)
            {
                ContactWithDragon();
            }
        }
    }

    void CautionInformation()
    {
        playerInSneakingRange = Physics.OverlapSphere(transform.root.position, sneakingRange, playerLayerMask);

        if (playerInSneakingRange.Length > 0 && Time.timeScale > 0.0f)
            cautionInfoText.gameObject.SetActive(true);
        else
            cautionInfoText.gameObject.SetActive(false);
    }

    void ContactWithDragon()
    {
        if (!dragonRoars)
        {
            audioSource.Play();
            dragonRoars = true;
        }

        if (dragonRoars)
            transform.Translate(Vector3.forward * dragonMovementSpeed * Time.deltaTime);

        if (!audioSource.isPlaying && dragonRoars)
        {
            Time.timeScale = 0.0f;
            GameController.Instance.LoseGameController();
        }
    }

    void DragonMovement(Vector3 objectPosition)
    {
        transform.root.Translate(Vector3.forward * dragonMovementSpeed * Time.deltaTime);
        Vector3 position = objectPosition;
        Vector3 direction = position - transform.root.position;
        Quaternion dragonRotation = Quaternion.LookRotation(direction);
        dragonRotation = new Quaternion(0, dragonRotation.y, 0, dragonRotation.w);

        transform.root.rotation = Quaternion.Lerp(transform.root.rotation, dragonRotation, dragonRotationSpeed * Time.deltaTime);
    }

    void DragonLeansDown()
    {
        neckPoint.Rotate(16 * Time.deltaTime, 0, 0);
    }

    void DragonGoesToRiver()
    {
        if (canGoToRiver && !isInRiver)
        {
            dragonRotationSpeed = 0.5f;
            dragonMovementSpeed = 1.0f;
            DragonMovement(placeToDrink.position);
        }
    }

    void DragonDrinksWater()
    {
        if (neckPoint.localEulerAngles.x < 32.75f || neckPoint.localEulerAngles.x > 33.25f)
            DragonLeansDown();
        else if (neckPoint.localEulerAngles.x <= 33.25f && neckPoint.localEulerAngles.x >= 32.75f)
            dragonIsDying = true;
        
        if (dragonIsDying)
        {
            if (stomach.localScale.x <= 1.0f)
                stomach.localScale += new Vector3(0.001f, 0.001f, 0.001f);

            if (stomach.localScale.x > 1.0f)
            {
                GameController.Instance.WinGameController();
                Time.timeScale = 0.0f;
            }
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

        if (other.gameObject.layer == 13)
        {
            dragonMovementSpeed = 0.0f;
            dragonRotationSpeed = 0.0f;
            isInRiver = true;
        }
    }
}
