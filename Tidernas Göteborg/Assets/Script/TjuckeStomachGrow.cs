using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TjuckeStomachGrow : MonoBehaviour
{
    public GameObject[] tjuckeMeshes;
    private Rigidbody rb;

    private int index = 0;

    private void Start()
    {
        tjuckeMeshes[index].gameObject.SetActive(true);
        rb = GetComponentInParent<Rigidbody>();
    }

    void GrowStomach()
    {
        index++;

        index = Mathf.Clamp(index, 0, tjuckeMeshes.Length - 1);

        tjuckeMeshes[index].gameObject.SetActive(true);
        tjuckeMeshes[index - 1].gameObject.SetActive(false);

        if (tjuckeMeshes[10].activeSelf)
        {
            rb.AddForce(10, 20, 10);
            StartCoroutine(nameof(SwitchScene));
        }
    }

    IEnumerator SwitchScene()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(2);
    }

    private void OnEnable()
    {
        MoneyCounter.tjuckeGrow += GrowStomach;
    }

    private void OnDisable()
    {
        MoneyCounter.tjuckeGrow -= GrowStomach;
    }
}
