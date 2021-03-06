using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon : MonoBehaviour
{
    [SerializeField] LeaveSheepInPoint leaveSheep;
    [SerializeField] Transform neckPoint;
    [SerializeField] Transform placeToDrink;
    [SerializeField] Transform caveEnter;
    [SerializeField] GameObject sneakingRangeGO;
    [SerializeField] GameObject walkingRangeGO;
    [SerializeField] GameObject runningRangeGO;

    [HideInInspector] public bool sheepEaten = false;
    [HideInInspector] public bool reachedSafePoint = false;

    AudioSource audioSource;
    float dragonRotationSpeed = 0.5f;
    float dragonMovementSpeed = 1.0f;
    float wakeUpTime = 2.5f;
    bool canEatSheep = false;
    bool canGoToRiver = false;
    bool isInRiver = false;
    bool reachedCaveEnterPoint = false;
    bool dragonRoars = false;
    bool rangesGOAreVisible = false;
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
        //HelpController();

        if (!reachedSafePoint)
            DragonHearRange();

        if (leaveSheep.sheepIsOnPlace && !reachedCaveEnterPoint)
        {
            if (wakeUpTime > 0)
                wakeUpTime -= Time.deltaTime;
            else
                wakeUpTime = 0;

            if (wakeUpTime == 0)
            {
                DragonMovement(caveEnter.position);

                float distanceToPoint = Vector3.Distance(caveEnter.position, transform.position);
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
                Time.timeScale = 0.0f;
                GameController.Instance.LoseGameController();
            }
        }

        if (canEatSheep && !sheepEaten)
        {
            DragonLeansDown();
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
        playerInSneakingRange = Physics.OverlapSphere(transform.position, sneakingRange, playerLayerMask);
        playerInWalkingRange = Physics.OverlapSphere(transform.position, walkingRange, playerLayerMask);
        playerInRunningRange = Physics.OverlapSphere(transform.position, runningRange, playerLayerMask);

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
        transform.Translate(Vector3.forward * dragonMovementSpeed * Time.deltaTime);
        Vector3 position = objectPosition;
        Vector3 direction = position - transform.position;
        Quaternion dragonRotation = Quaternion.LookRotation(direction);
        dragonRotation = new Quaternion(0, dragonRotation.y, 0, dragonRotation.w);

        transform.rotation = Quaternion.Lerp(transform.rotation, dragonRotation, dragonRotationSpeed * Time.deltaTime);
    }

    void DragonLeansDown()
    {
        neckPoint.Rotate(0, 0, -16 * Time.deltaTime);
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
        if (neckPoint.localEulerAngles.z >= 255.0f)
            DragonLeansDown();
        
        if (neckPoint.localEulerAngles.z <= 255.0f)
        {
            for (int i = 0; i < 2; i++)
            {
                if (transform.GetChild(i).transform.localScale.x <= 2.7f)
                    transform.GetChild(i).transform.localScale += new Vector3(0.001f, 0.001f, 0.001f);

                if (transform.GetChild(i).transform.localScale.x > 2.7f)
                {
                    GameController.Instance.WinGameController();
                    Time.timeScale = 0.0f;
                }
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

        if (other.gameObject.layer == 12)
        {
            dragonMovementSpeed = 0.0f;
            dragonRotationSpeed = 0.0f;
            isInRiver = true;
        }
    }
}
