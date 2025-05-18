using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayGame : MonoBehaviour
{
    public static PlayGame Instance;

    [SerializeField] List<RotateBrick> rotateBrick = new List<RotateBrick>();
    [SerializeField] GameObject player;
    [SerializeField] GameObject titleScreen;
    void Awake()
    {
        DisableRotateBrick();
        DisablePlayerGameObject();
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

    public void DisableRotateBrick()
    {
        foreach (RotateBrick brick in rotateBrick)
        {
            brick.enabled = false;
        }
    }

    public void DisablePlayerGameObject()
    {
        player.SetActive(false);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

}
