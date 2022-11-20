using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TjuckeFlyEndingScene : MonoBehaviour
{
    private Rigidbody rigidBody;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        rigidBody.AddForce(10, 20, 10);
    }
}
