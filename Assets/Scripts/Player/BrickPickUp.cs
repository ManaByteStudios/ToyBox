using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BrickPickUp : MonoBehaviour
{
    public static BrickPickUp Instance;

    [SerializeField] List<GameObject> bricks = new List<GameObject>();
    [SerializeField] GameObject endGameScreen;
    [SerializeField] GameObject onScreenCountDown;
    [SerializeField] GameObject bricksCollectedText;
    [SerializeField] private float startTime = 30f;

    public int brickCount = 0;

    public float currentTime;

    float addedTime = 5f;

    public bool isSuccessful;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Debug.LogWarning("Destroying extra BrickPickUp instance.");
            Destroy(gameObject); // Prevents multiple instances
        }
    }

    private void Start()
    {
        currentTime = startTime;
    }

    private void Update()
    {
        currentTime -= Time.deltaTime;

        if (currentTime <= 0)
        {
            isSuccessful = false;
            EnableEndGameScene();
            DisableOnScreenCountDown();
            DisableBrickCollectedTxt();
            PlayGame.Instance.DisableRotateBrick();
            PlayGame.Instance.DisablePlayerGameObject();            
        }
        else if (brickCount == bricks.Count)
        {
            isSuccessful = true;
            EnableEndGameScene();
            DisableOnScreenCountDown();
            DisableBrickCollectedTxt();
            PlayGame.Instance.DisableRotateBrick();
            PlayGame.Instance.DisablePlayerGameObject();            
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "BrickPickUp")
        {
            brickCount++;

            currentTime += addedTime;

            Destroy(other.gameObject);
        }
    }

    public void EnableEndGameScene()
    {
        endGameScreen.SetActive(true);
    }

    private void DisableOnScreenCountDown()
    {
        onScreenCountDown.SetActive(false);
    }
    private void DisableBrickCollectedTxt()
    {
        bricksCollectedText.SetActive(false);
    }


    public float TimeInGame()
    {
        float timeInGame = 0;
        timeInGame += Time.time;

        return timeInGame;
    }

    public static string GameOverMessage(string message)
    {
        if(message == "Success")
        {
            return "Success";
        }
        else if (message == "Game Over")
        {
            return "Game Over";
        }
        return message;
    }
}
