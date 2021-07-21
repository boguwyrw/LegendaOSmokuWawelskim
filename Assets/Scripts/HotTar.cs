using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotTar : MonoBehaviour
{

    [SerializeField] GameObject PileOfSulphurPref;

    bool startInteraction = false;
    bool pileOfSulphurCreated = false;
    Vector3 hotTarPosition;
    Quaternion hotTarRotation;
    Vector3 pileOfSulphurPrefPosition;

    void Update()
    {
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
}
