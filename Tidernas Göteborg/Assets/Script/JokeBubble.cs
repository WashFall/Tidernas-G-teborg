using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.InputSystem;

public class JokeBubble : MonoBehaviour
{
    public GameObject speechBubble;

    private List<GameObject> jokes, punchLines;
    private List<int> usedJokes;

    void Awake()
    {
        usedJokes = new List<int>();
        jokes = Resources.LoadAll<GameObject>("Jokes/").ToList();
        punchLines = Resources.LoadAll<GameObject>("PunchLines/").ToList();
    }

    private void OnEnable()
    {
        MoneyCounter.tjuckeGrow += TellJoke;
    }

    private async void TellJoke()
    {
        if(usedJokes.Count == 10)
        {
            usedJokes.Clear();
        }

        int randomJoke = Random.Range(0, 10);
        if (usedJokes.Contains(randomJoke))
        {
            TellJoke();
            return;
        }
        usedJokes.Add(randomJoke);
        await AwaitJoke(randomJoke);
        await GracePeriod();
        await AwaitPunchLine(randomJoke);
    }

    private async Task AwaitJoke(int index)
    {
        float endTime = Time.time + 3;
        speechBubble.SetActive(true);
        GameObject text = Instantiate(jokes[index], speechBubble.transform);
        while(Time.time < endTime)
        {
            await Task.Yield();
        }
        Destroy(text);
        speechBubble.SetActive(false);
    }

    private async Task GracePeriod()
    {
        float endTime = Time.time + 1;

        while (Time.time < endTime)
        {
            await Task.Yield();
        }
    }

    private async Task AwaitPunchLine(int index)
    {
        float endTime = Time.time + 3;
        speechBubble.SetActive(true);
        GameObject text = Instantiate(punchLines[index], speechBubble.transform);
        while (Time.time < endTime)
        {
            await Task.Yield();
        }
        Destroy(text);
        speechBubble.SetActive(false);
    }

    private void OnDisable()
    {
        MoneyCounter.tjuckeGrow -= TellJoke;
    }
}
