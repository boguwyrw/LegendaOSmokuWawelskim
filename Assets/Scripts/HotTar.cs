using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HotTar : MonoBehaviour
{
    [SerializeField] GameObject PileOfSulphurPref;
    [SerializeField] GameObject promptPanel;
    [SerializeField] GameObject sulphur;
    [SerializeField] PlayerSkubaInteraction playerSkubaInteraction;

    bool startInteraction = false;
    bool pileOfSulphurCreated = false;
    bool itemWasPickedUp = false;
    Vector3 hotTarPosition;
    Quaternion hotTarRotation;
    Vector3 pileOfSulphurPrefPosition;

    void Update()
    {
        if (!itemWasPickedUp && !Inventory.Instance.playerItemsName.Any(item => item.name.Equals(sulphur.name)))
            HelpfulAdvice();
        else if (Inventory.Instance.playerItemsName.Any(item => item.name.Equals(sulphur.name)))
            itemWasPickedUp = true;

        startInteraction = GetComponent<Interaction>().objectCanInteract;
        if (startInteraction && !pileOfSulphurCreated)
        {
            hotTarPosition = transform.position;
            hotTarRotation = transform.rotation;
            pileOfSulphurPrefPosition = new Vector3(hotTarPosition.x, hotTarPosition.y + 0.1f, hotTarPosition.z);
            GameObject pileOfSulphurClone =  Instantiate(PileOfSulphurPref, pileOfSulphurPrefPosition, hotTarRotation);
            pileOfSulphurClone.transform.parent = Inventory.Instance.sheepToStuffGO.transform;
            pileOfSulphurCreated = true;
        }
    }

    void HelpfulAdvice()
    {
        if (playerSkubaInteraction.pointedObjectName.Equals(gameObject.name))
        {
            promptPanel.SetActive(true);
        }
        else
            promptPanel.SetActive(false);
    }
}
