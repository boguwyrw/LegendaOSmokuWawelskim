using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepSkin : MonoBehaviour
{
    [HideInInspector] public bool isOnTable = false;

    [SerializeField] GameObject hotTarPref;
    [SerializeField] Cauldron cauldron;

    bool startInteraction = false;
    bool hotTarCreated = false;
    Vector3 sheepSkinPosition;
    Quaternion sheepSkinRotation;
    Vector3 hotTarPrefPosition;

    void Update()
    {
        if (isOnTable)
        {
            sheepSkinPosition = transform.position;
            sheepSkinRotation = transform.rotation;

            if (cauldron.tarIsHot)
                gameObject.layer = 9;

            startInteraction = GetComponent<Interaction>().objectCanInteract;
            if (startInteraction && !hotTarCreated)
            {
                hotTarPrefPosition = new Vector3(sheepSkinPosition.x, sheepSkinPosition.y + 0.05f, sheepSkinPosition.z);
                GameObject hotTarClone = Instantiate(hotTarPref, hotTarPrefPosition, sheepSkinRotation);
                hotTarClone.transform.parent = Inventory.Instance.sheepToStuffGO.transform;
                hotTarCreated = true;
            }
        } 
    }
}
