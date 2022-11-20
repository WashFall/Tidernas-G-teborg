using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField]
    List<GameObject> players = new List<GameObject>();

    public void ActivateRespawnPlayer()
    {
        if(players.Count <= 0)
        {
            return;
        }
        GameObject respawnPlayer = players[players.Count - 1];
        respawnPlayer.SetActive(true);
        players.Remove(respawnPlayer);
    }
}
