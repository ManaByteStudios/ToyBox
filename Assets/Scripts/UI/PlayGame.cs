using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayGame : MonoBehaviour
{
    public static PlayGame Instance;

    [SerializeField] List<RotateBrick> rotateBrick = new List<RotateBrick>();
    [SerializeField] GameObject player;
    [SerializeField] GameObject titleScreen;
    [SerializeField] GameObject onScreenCountDown;
    [SerializeField] GameObject brickCollectedText;
    [SerializeField] AudioClip clickButtonSFX;

    AudioSource audioSource;

    void Awake()
    {
        DisableRotateBrick();
        DisablePlayerGameObject();
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void EnableScripts()
    {
        foreach (RotateBrick brick in rotateBrick)
        {
            brick.enabled = true;
        }
        player.SetActive(true);
        titleScreen.SetActive(false);
        onScreenCountDown.SetActive(true);
        brickCollectedText.SetActive(true);
        audioSource.PlayOneShot(clickButtonSFX);
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
