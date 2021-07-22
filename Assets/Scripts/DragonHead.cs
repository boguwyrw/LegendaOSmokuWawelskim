using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonHead : MonoBehaviour
{
    [SerializeField] Dragon dragon;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Equals("StuffedSheep"))
        {
            //dragon.sheepEaten = true;
            //collision.gameObject.SetActive(false);
        }
    }
}
