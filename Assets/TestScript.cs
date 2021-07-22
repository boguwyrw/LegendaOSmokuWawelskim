using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    Rigidbody testRig;

    void Start()
    {
        testRig = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (transform.localScale.x <= 2.5f)
            transform.localScale += new Vector3(0.001f, 0.001f, 0.001f);

        if (transform.localScale.x > 2.5f)
        {
            testRig.isKinematic = false;
            testRig.useGravity = true;
        }
    }
}
