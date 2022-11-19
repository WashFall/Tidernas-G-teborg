using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class JokeBubble : MonoBehaviour
{
    public GameObject speechBubble;

    private List<GameObject> jokes, punchLines;
    private List<int> usedJokes;
    void Start()
    {
        usedJokes = new List<int>();
        jokes = Resources.LoadAll<GameObject>("/Jokes/").ToList();
        punchLines = Resources.LoadAll<GameObject>("/PunchLines/").ToList();
    }

    private void TellJoke()
    {
        float randomJoke = Random.Range(0, 11);


    }
}
