using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TjuckeFlyEndingScene : MonoBehaviour
{
    public GameObject endMenu;

    private Rigidbody rigidBody;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        rigidBody.AddForce(10, 20, 10);

        StartCoroutine(nameof(WaitForEnding));
    }

    IEnumerator WaitForEnding()
    {
        yield return new WaitForSeconds(7);
        endMenu.gameObject.SetActive(true);
    }

}
