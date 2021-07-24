using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonFlame : MonoBehaviour
{
    ParticleSystem dragonFlame;

    void Start()
    {
        dragonFlame = transform.GetChild(0).GetComponent<ParticleSystem>();
    }

    public void StartFireFlame()
    {
        dragonFlame.Play();
    }

    public void StopFireFlame()
    {
        dragonFlame.Stop();
    }
}
