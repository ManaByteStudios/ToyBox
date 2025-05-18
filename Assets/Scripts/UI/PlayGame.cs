using NUnit.Framework;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class PlayGame : MonoBehaviour
{
    [SerializeField] List<RotateBrick> rotateBrick = new List<RotateBrick>();
    [SerializeField] GameObject player;
    [SerializeField] GameObject titleScreen;
    void Awake()
    {
        foreach (RotateBrick brick in rotateBrick)
        {
            brick.enabled = false; 
        }

        player.SetActive(false);
    }

    public void EnableScripts()
    {
        foreach (RotateBrick brick in rotateBrick)
        {
            brick.enabled = true;
        }
        player.SetActive(true);
        titleScreen.SetActive(false);
    }
}
